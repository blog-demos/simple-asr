
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
 *          2019/03/25 15:19:14
 * 
 ***********************************************************/

namespace proxy_asr_ifly
{
    internal enum EpStatus
    {
        //ISR_EP_NULL = -1,
        //ISR_EP_LOOKING_FOR_SPEECH = 0,          ///还没有检测到音频的前端点
        //ISR_EP_IN_SPEECH = 1,                   ///已经检测到了音频前端点，正在进行正常的音频处理。
        //ISR_EP_AFTER_SPEECH = 3,                ///检测到音频的后端点，后继的音频会被MSC忽略。
        //ISR_EP_TIMEOUT = 4,                     ///超时
        //ISR_EP_ERROR = 5,                       ///出现错误
        //ISR_EP_MAX_SPEECH = 6                   ///音频过大
    }
}
