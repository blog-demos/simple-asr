
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
 *          2019/03/25 15:18:29
 * 
 ***********************************************************/

namespace proxy_asr_ifly
{
    internal enum RecogStatus
    {
        ISR_REC_NULL = -1,
        ISR_REC_STATUS_SUCCESS = 0,             ///识别成功，此时用户可以调用QISRGetResult来获取（部分）结果。
        ISR_REC_STATUS_NO_MATCH = 1,            ///识别结束，没有识别结果
        ISR_REC_STATUS_INCOMPLETE = 2,          ///正在识别中
        ISR_REC_STATUS_NON_SPEECH_DETECTED = 3, ///保留
        ISR_REC_STATUS_SPEECH_DETECTED = 4,     ///发现有效音频
        ISR_REC_STATUS_SPEECH_COMPLETE = 5,     ///识别结束
        ISR_REC_STATUS_MAX_CPU_TIME = 6,        ///保留
        ISR_REC_STATUS_MAX_SPEECH = 7,          ///保留
        ISR_REC_STATUS_STOPPED = 8,             ///保留
        ISR_REC_STATUS_REJECTED = 9,            ///保留
        ISR_REC_STATUS_NO_SPEECH_FOUND = 10     ///没有发现音频
    }
}
