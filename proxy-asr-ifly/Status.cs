
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
 *          2019/03/25 17:17:19
 * 
 ***********************************************************/

namespace proxy_asr_ifly
{
    internal enum Status
    {
        MSP_REC_STATUS_SUCCESS = 0,
        MSP_REC_STATUS_NO_MATCH = 1,
        MSP_REC_STATUS_INCOMPLETE = 2,
        MSP_REC_STATUS_NON_SPEECH_DETECTED = 3,
        MSP_REC_STATUS_SPEECH_DETECTED = 4,
        MSP_REC_STATUS_COMPLETE = 5,
        MSP_REC_STATUS_MAX_CPU_TIME = 6,
        MSP_REC_STATUS_MAX_SPEECH = 7,
        MSP_REC_STATUS_STOPPED = 8,
        MSP_REC_STATUS_REJECTED = 9,
        MSP_REC_STATUS_NO_SPEECH_FOUND = 10,
        MSP_REC_STATUS_FAILURE = MSP_REC_STATUS_NO_MATCH,
    }
}
