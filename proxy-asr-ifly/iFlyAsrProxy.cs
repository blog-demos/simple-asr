
/**********************************************************
 * 
 * 命名空间：
 *          proxy_asr_ifly
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
 *          2019/03/25 15:09:35
 * 
 ***********************************************************/

using System;
using System.Collections.Generic;

namespace proxy_asr_ifly
{
    public class iFlyAsrProxy
    {
        private string param = "";
        private uint FRAME_LEN = 640;
        private const int BUFFER_SIZE = 4096;

        private AudioStatus aud_stat = AudioStatus.ISR_AUDIO_SAMPLE_CONTINUE;
        private EpStatus ep_stat = EpStatus.MSP_EP_LOOKING_FOR_SPEECH;
        private RecogStatus rec_stat = RecogStatus.MSP_REC_NULL;
        private string session_id;

        public iFlyAsrProxy(string appId)
        {
            param = String.Format("appid = {0}, work_dir = .", appId);
            Initialize();
        }

        public string Recognition(byte[] data)
        {
            string result = Recognition(GroupData(data));
            iFlyDll.MSPLogout();

            return result;
        }

        private string Recognition(IList<byte[]> data)
        {
            string rec_result = "";
            int error_code = 0;

            // 分组提交数据
            for (int i = 0; i < data.Count; i++)
            {
                aud_stat = AudioStatus.ISR_AUDIO_SAMPLE_CONTINUE;
                if (0 == i) aud_stat = AudioStatus.ISR_AUDIO_SAMPLE_FIRST;
                Console.Write(">");

                error_code = iFlyDll.QISRAudioWrite(session_id, data[i], (uint)data[i].Length, aud_stat, ref ep_stat, ref rec_stat);
                if ((int)ErrorCode.MSP_SUCCESS != error_code)
                {
                    iFlyDll.QISRSessionEnd(session_id, null);
                }
            }

            error_code = iFlyDll.QISRAudioWrite(session_id, null, 0, AudioStatus.ISR_AUDIO_SAMPLE_LAST, ref ep_stat, ref rec_stat);
            if ((int)ErrorCode.MSP_SUCCESS != error_code)
            {
                Log(String.Format("QISRAudioWrite failed! error code: {0}" + error_code));
                return "";
            }

            while (RecogStatus.MSP_REC_STATUS_SPEECH_COMPLETE != rec_stat)
            {
                IntPtr rslt = iFlyDll.QISRGetResult(session_id, ref rec_stat, 0, ref error_code);
                if ((int)ErrorCode.MSP_SUCCESS != error_code)
                {
                    Log(String.Format("QISRGetResult failed, error code: {0}", error_code));
                    break;
                }
                if (IntPtr.Zero != rslt)
                {
                    string tempRes = Utils.Ptr2Str(rslt);

                    rec_result = rec_result + tempRes;
                    if (rec_result.Length >= BUFFER_SIZE)
                    {
                        Log("no enough buffer for rec_result !");
                        break;
                    }
                }

            }
            int errorcode = iFlyDll.QISRSessionEnd(session_id, "end");

            return rec_result;
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
            // STEP 1: LOGIN
            int ret = iFlyDll.MSPLogin(null, null, param);
            Log(String.Format("登录结果：{0}", 0 == ret ? "success" : "fail"));

            // STEP 2: INIT
            int error_code = (int)ErrorCode.MSP_SUCCESS;
            Log("开始语音听写 ...");
            IntPtr begin = iFlyDll.QISRSessionBegin(null, iFlyConfig.SESSION_BEGIN_PARAMS, ref error_code);
            session_id = Utils.Ptr2Str(begin);
            Log(String.Format("听写初始化结果：{0}", (int)ErrorCode.MSP_SUCCESS == error_code ? String.Format("success | session id={0}", session_id) : "fail"));
        }

        private void Log(String msg)
        {
            Console.WriteLine(msg);
        }
    }
}
