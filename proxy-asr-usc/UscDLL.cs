
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
 *          2019/03/27 11:12:42
 * 
 ***********************************************************/

using System;
using System.Runtime.InteropServices;

namespace proxy_asr_usc
{
    internal class USCDLL
    {
        internal const string DLL_FILE_NAME = "libusc.dll";

        /// <summary>
        /// 创建识别接口
        /// </summary>
        /// <returns></returns>
        [DllImport(DLL_FILE_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal extern static int usc_create_service(out Int64 handle);

        /// <summary>
        /// 设置识别参数
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="option_id"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [DllImport(DLL_FILE_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal extern static int usc_set_option(Int64 handle, ParamIdUsc id, string value);

        /// <summary>
        /// 登录
        /// </summary> 
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport(DLL_FILE_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal extern static int usc_login_service(Int64 handle);

        /// <summary>
        /// 启动识别
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport(DLL_FILE_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal extern static int usc_start_recognizer(Int64 handle);

        /// <summary>
        /// 识别语音数据
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="buffer"></param>
        /// <param name="length"></param>
        /// <returns></returns>

        [DllImport(DLL_FILE_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal extern static int usc_feed_buffer(Int64 handle, byte[] buffer, int length);

        /// <summary>
        /// 获得识别结果
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport(DLL_FILE_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal extern static string usc_get_result(Int64 handle);

        /// <summary>
        /// 停止识别
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        [DllImport(DLL_FILE_NAME, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        internal extern static int usc_stop_recognizer(Int64 handle);

        /// <summary>
        /// 释放接口
        /// </summary>
        /// <returns></returns>
        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.Cdecl)]
        internal extern static void usc_release_service(Int64 handle);
    }
}
