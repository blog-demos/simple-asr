
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
 *          2019/03/25 15:11:47
 * 
 ***********************************************************/

using System;
using System.Runtime.InteropServices;

namespace proxy_asr_ifly
{
    internal class iFlyDll
    {
#if WIN64
        public const string DLL_FILE_NAME = "libs/msc_x64.dll";
#else
        public const string DLL_FILE_NAME = "libs/msc.dll";
#endif

        /// <summary>
        /// 接口登入，可以只登入一次，但是必须保证在调用其他接口前先登入
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="configs"></param>
        /// <returns></returns>
        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int MSPLogin(string username, string password, string configs);

        /// <summary>
        /// 不再使用服务的时候 调用MSPLogout()登出，避免不必要的麻烦
        /// </summary>
        /// <returns></returns>
        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int MSPLogout();

        /// <summary>
        /// 开始一次语音听写
        /// </summary>
        /// <param name="grammarList"></param>
        /// <param name="_params"></param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr QISRSessionBegin(string grammarList, string _params, ref int errorCode);

        /// <summary>
        /// 分块写入音频数据
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="waveData"></param>
        /// <param name="waveLen"></param>
        /// <param name="audioStatus"></param>
        /// <param name="epStatus"></param>
        /// <param name="recogStatus"></param>
        /// <returns></returns>
        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int QISRAudioWrite(string sessionID, byte[] waveData, uint waveLen, AudioStatus audioStatus, ref EpStatus epStatus, ref RecogStatus recogStatus);
        //public static extern int QISRAudioWrite(string sessionID, IntPtr waveData, uint waveLen, AudioStatus audioStatus, ref EpStatus epStatus, ref RecogStatus recogStatus);

        /// <summary>
        /// 循环调用 QISRGetResult(...) 接口返回听写结果
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="rsltStatus"></param>
        /// <param name="waitTime"></param>
        /// <param name="errorCode"></param>
        /// <returns></returns>
        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr QISRGetResult(string sessionID, ref RecogStatus rsltStatus, int waitTime, ref int errorCode);

        /// <summary>
        /// 主动结束本次听写
        /// </summary>
        /// <param name="sessionID"></param>
        /// <param name="hints"></param>
        /// <returns></returns>
        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int QISRSessionEnd(string sessionID, string hints);

        /// <summary>
        /// 获取当次语音识别信息，如上行流量、下行流量等
        /// </summary>
        /// <param name="sessionID">由QISRSessionEnd返回的句柄，如果为NULL，获取MSC的设置信息</param>
        /// <param name="paramName">参数名，一次调用只支持查询一个参数</param>
        /// <param name="paramValue"></param>
        /// <param name="valueLen"></param>
        /// <returns></returns>
        [DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.StdCall)]
        public static extern int QISRGetParam(string sessionID, string paramName, string paramValue, ref uint valueLen); // 读取语法

        //[DllImport(DLL_FILE_NAME, CallingConvention = CallingConvention.StdCall)]
        //public static extern int QISRFini(); // 释放
    }
}
