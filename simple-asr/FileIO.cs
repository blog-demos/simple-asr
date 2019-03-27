
/**********************************************************
 * 
 * 命名空间：
 *          simple_asr
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
 *          2019/03/25 18:06:30
 * 
 ***********************************************************/
 
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace simple_asr
{
    internal class FileIO
    {
        /// <summary>
        /// 读取一个文件的所有字节
        /// </summary>
        /// <param name="fileFullName">文件完整路径</param>
        /// <returns>文件的所有字节</returns>
        internal static byte[] Read(string fileFullName)
        {
            if (String.IsNullOrEmpty(fileFullName)) { return null; }

            byte[] data = null;
            try
            {
                using (FileStream fs = new FileStream(fileFullName, FileMode.Open, FileAccess.Read))
                {
                    data = new byte[fs.Length];
                    fs.Read(data, 0, (int)fs.Length);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("FileIO.Read:{0}{1}", Environment.NewLine, ex.StackTrace));
                return null;
            }

            return data;
        }
    }
}
