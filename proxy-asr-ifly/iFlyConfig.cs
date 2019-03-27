
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
 *          2019/03/25 15:24:53
 * 
 ***********************************************************/

namespace proxy_asr_ifly
{
    internal class iFlyConfig
    {
        //internal const string LOGIN_PARAMS = "appid = 5c9862f2, work_dir = ."; // 登录参数，appid与msc库绑定,请勿随意改动

        /**
	     * sub:             请求业务类型
	     * domain:          领域
	     * language:        语言
	     * accent:          方言
	     * sample_rate:     音频采样率
	     * result_type:     识别结果格式
	     * result_encoding: 结果编码格式
	     */
        internal const string SESSION_BEGIN_PARAMS = "sub = iat, domain = iat, language = zh_cn, accent = mandarin, sample_rate = 16000, result_type = plain, result_encoding = gb2312";
    }
}
