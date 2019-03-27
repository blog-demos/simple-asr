
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
 *          2019/03/25 15:17:55
 * 
 ***********************************************************/

namespace proxy_asr_ifly
{
    internal enum AudioStatus
    {
        ISR_AUDIO_SAMPLE_INIT = 0x00,
        ISR_AUDIO_SAMPLE_FIRST = 0x01,
        ISR_AUDIO_SAMPLE_CONTINUE = 0x02,
        ISR_AUDIO_SAMPLE_LAST = 0x04,
        ISR_AUDIO_SAMPLE_SUPPRESSED = 0x08,
        ISR_AUDIO_SAMPLE_LOST = 0x10,
        ISR_AUDIO_SAMPLE_NEW_CHUNK = 0x20,
        ISR_AUDIO_SAMPLE_END_CHUNK = 0x40,

        ISR_AUDIO_SAMPLE_VALIDBITS = 0x7f // to validate the value of sample->status 
    }
}
