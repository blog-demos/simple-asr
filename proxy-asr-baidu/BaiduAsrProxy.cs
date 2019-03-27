
/**********************************************************
 * 
 * 命名空间：
 *          proxy_asr_baidu
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
 *          2019/03/27 10:18:54
 * 
 ***********************************************************/

using Baidu.Aip.Speech;
using System.Collections.Generic;

namespace proxy_asr_baidu
{
    public class BaiduAsrProxy
    {
        private Asr client;

        public BaiduAsrProxy(string appKey, string appSecret)
        {
            if (null != client) return;
            client = new Asr(appKey, appSecret) { Timeout = 60000 };
        }

        public string Recognition(byte[] data)
        {
            // 可选参数
            var options = new Dictionary<string, object>
            {
                {"dev_pid", 1536}
            };
            client.Timeout = 120000; // 若语音较长，建议设置更大的超时时间. ms
            var result = client.Recognize(data, "pcm", 16000, options);

            return result.ToString();
        }
    }
}
