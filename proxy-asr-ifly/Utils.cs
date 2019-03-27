
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
 *          2019/03/25 16:57:33
 * 
 ***********************************************************/

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace proxy_asr_ifly
{
    internal class Utils
    {
        public static string Ptr2Str(IntPtr p)
        {
            try
            {
                IntPtr newp = p;
                List<byte> lb = new List<byte>();
                while (Marshal.ReadByte(p) != 0)
                {
                    lb.Add(Marshal.ReadByte(p));
                    p = p + 1;
                }

                return Encoding.Default.GetString(lb.ToArray());
            }
            catch
            {
                return "";
            }
        }
    }
}
