
/**********************************************************
 * 
 * 命名空间：
 *          proxy_asr_usc
 * 
 * 描述：
 *          N/A
 *          
 * 功能及上下游：
 *          N/A
 *          
 * 人员：
 *          大鱼
 *          
 * 创建时间：
 *          2019/03/27 11:41:20
 * 
 ***********************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace proxy_asr_usc
{
    public class USCAsrProxy
    {
        private string appKey = "";
        private string appSecret = "";
        private uint FRAME_LEN = 640;
        private Int64 handle = 0;

        public USCAsrProxy(string appKey, string appSecret)
        {
            this.appKey = appKey;
            this.appSecret = appSecret;
            Initialize();
        }

        public string Recognition(byte[] data)
        {
            int ret = 0;

            ret = USCDLL.usc_set_option(handle, ParamIdUsc.USC_OPT_INPUT_AUDIO_FORMAT, "");
            if (0 != ret)
            {
                Log(String.Format("set_option[3] -> ret: {0}", ret));
            }

            ret = USCDLL.usc_set_option(handle, ParamIdUsc.USC_OPT_RECOGNITION_FIELD, "");
            if (0 != ret)
            {
                Log(String.Format("set_option[4] -> ret: {0}", ret));
            }

            ret = USCDLL.usc_start_recognizer(handle);
            if ((int)StatusUsc.USC_ASR_OK != ret)
            {
                Log(String.Format("start_recognizer -> ret: {0}", ret));
            }

            return Recognition(GroupData(data));
        }

        private string Recognition(IList<byte[]> data)
        {
            string result = "";
            int ret = 0;
            for (int i = 0; i < data.Count; i++)
            {
                ret = USCDLL.usc_feed_buffer(handle, data[i], data[i].Length);
                if ((int)StatusUsc.USC_RECOGNIZER_PARTIAL_RESULT == ret || (int)StatusUsc.USC_RECOGNIZER_SPEAK_END == ret)
                {
                    // TODO
                    Log(String.Format("中间结果：{0}", USCDLL.usc_get_result(handle)));
                }
                else if (0 > ret)
                {
                    break;
                }

                Thread.Sleep(20);
            }

            // 停止语音输入
            ret = USCDLL.usc_stop_recognizer(handle);
            if (ret == 0)
            {
                // 获取剩余识别结果
                string leftResult = USCDLL.usc_get_result(handle);
                result = leftResult;
            }
            byte[] bl = Encoding.Default.GetBytes(result);
            result = Encoding.UTF8.GetString(bl);

            return result;
        }

        private IList<byte[]> GroupData(byte[] data)
        {
            int groupLen = (int)(10 * FRAME_LEN); // 每次写入200ms音频(16k，16bit)：1帧音频20ms，10帧=200ms。16k采样率的16位音频，一帧的大小为640Byte
            int count = (data.Length / groupLen) + (0 == data.Length % groupLen ? 0 : 1);

            IList<byte[]> result = new List<byte[]>();
            for (int i = 0; i < count; i++)
            {
                result.Add(SubArray(data, i * groupLen, groupLen));
            }

            return result;
        }

        private byte[] SubArray(byte[] data, int start, int count)
        {
            byte[] result = new byte[Math.Min(count, data.Length - start)];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = data[start + i];
            }

            return result;
        }

        private void Initialize()
        {
            int ret = 0;

            ret = USCDLL.usc_create_service(out handle);
            if (ret != Convert.ToInt32(StatusUsc.USC_ASR_OK))
            {
                Log(String.Format("create_service -> error: {0}", ret));
            }
            ret = USCDLL.usc_login_service(handle);
            if (ret != Convert.ToInt32(StatusUsc.USC_ASR_OK))
            {
                Log(String.Format("login_service -> error: {0}", ret));
            }

            // 设置识别AppKey secret
            ret = USCDLL.usc_set_option(handle, ParamIdUsc.USC_OPT_ASR_APP_KEY, appKey);
            if (0 != ret)
            {
                Log(String.Format("set_option[1] -> ret: {0}", ret));
            }
            
            ret = USCDLL.usc_set_option(handle, ParamIdUsc.USC_OPT_USER_SECRET, appSecret);
            if (0 != ret)
            {
                Log(String.Format("set_option[2] -> ret: {0}", ret));
            }
        }

        private void Log(String msg)
        {
            Console.WriteLine(msg);
        }
    }
}
