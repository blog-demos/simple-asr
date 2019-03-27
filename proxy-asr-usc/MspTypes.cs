
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
 *          2019/03/27 11:38:09
 * 
 ***********************************************************/

namespace proxy_asr_usc
{
    internal enum ErrorCodeiFlytek
    {
        MSP_SUCCESS = 0,
        MSP_ERROR_FAIL = -1,
        MSP_ERROR_EXCEPTION = -2,

        /* General errors 10100(0x2774) */
        MSP_ERROR_GENERAL = 10100, 	/* 0x2774 */
        MSP_ERROR_OUT_OF_MEMORY = 10101, 	/* 0x2775 */
        MSP_ERROR_FILE_NOT_FOUND = 10102, 	/* 0x2776 */
        MSP_ERROR_NOT_SUPPORT = 10103, 	/* 0x2777 */
        MSP_ERROR_NOT_IMPLEMENT = 10104, 	/* 0x2778 */
        MSP_ERROR_ACCESS = 10105, 	/* 0x2779 */
        MSP_ERROR_INVALID_PARA = 10106, 	/* 0x277A */  /* 缺少参数 */
        MSP_ERROR_INVALID_PARA_VALUE = 10107, 	/* 0x277B */  /* 无效参数值 */
        MSP_ERROR_INVALID_HANDLE = 10108, 	/* 0x277C */
        MSP_ERROR_INVALID_DATA = 10109, 	/* 0x277D */
        MSP_ERROR_NO_LICENSE = 10110, 	/* 0x277E */  /* 引擎授权不足 */
        MSP_ERROR_NOT_INIT = 10111, 	/* 0x277F */  /* 引擎未初始化,可能是引擎崩溃 */
        MSP_ERROR_NULL_HANDLE = 10112, 	/* 0x2780 */
        MSP_ERROR_OVERFLOW = 10113, 	/* 0x2781 */  /* 单用户下模型数超上限(10个), */
        /* 只出现在测试时对一个用户进行并发注册 */
        MSP_ERROR_TIME_OUT = 10114, 	/* 0x2782 */  /* 超时 */
        MSP_ERROR_OPEN_FILE = 10115, 	/* 0x2783 */
        MSP_ERROR_NOT_FOUND = 10116, 	/* 0x2784 */  /* 数据库中模型不存在 */
        MSP_ERROR_NO_ENOUGH_BUFFER = 10117, 	/* 0x2785 */
        MSP_ERROR_NO_DATA = 10118, 	/* 0x2786 */  /* 从客户端读音频或从引擎段获取结果时无数据 */
        MSP_ERROR_NO_MORE_DATA = 10119, 	/* 0x2787 */
        MSP_ERROR_NO_RESPONSE_DATA = 10120, 	/* 0x2788 */
        MSP_ERROR_ALREADY_EXIST = 10121, 	/* 0x2789 */  /* 数据库中模型已存在 */
        MSP_ERROR_LOAD_MODULE = 10122, 	/* 0x278A */
        MSP_ERROR_BUSY = 10123, 	/* 0x278B */
        MSP_ERROR_INVALID_CONFIG = 10124, 	/* 0x278C */
        MSP_ERROR_VERSION_CHECK = 10125, 	/* 0x278D */
        MSP_ERROR_CANCELED = 10126, 	/* 0x278E */
        MSP_ERROR_INVALID_MEDIA_TYPE = 10127, 	/* 0x278F */
        MSP_ERROR_CONFIG_INITIALIZE = 10128, 	/* 0x2790 */
        MSP_ERROR_CREATE_HANDLE = 10129, 	/* 0x2791 */
        MSP_ERROR_CODING_LIB_NOT_LOAD = 10130, 	/* 0x2792 */
        MSP_ERROR_USER_CANCELLED = 10131, 	/* 0x2793 */
        MSP_ERROR_INVALID_OPERATION = 10132, 	/* 0x2794 */
        MSP_ERROR_MESSAGE_NOT_COMPLETE = 10133,	/* 0x2795 */   /* flash */
        MSP_ERROR_NO_EID = 10134,	/* 0x2795 */
        MSP_ERROE_OVER_REQ = 10135,    /* 0x2797 */   /* client Redundancy request */
        MSP_ERROR_USER_ACTIVE_ABORT = 10136,    /* 0x2798 */   /* user abort */
        MSP_ERROR_BUSY_GRMBUILDING = 10137,    /* 0x2799 */
        MSP_ERROR_BUSY_LEXUPDATING = 10138,    /* 0x279A */
        MSP_ERROR_SESSION_RESET = 10139,    /* 0x279B */   /* msc主动终止会话，准备重传 */
        MSP_ERROR_BOS_TIMEOUT = 10140,    /* 0x279C */   /* VAD前端点超时 */
        MSP_ERROR_STREAM_FILTER = 10141,	/* 0X279D */   /* AIUI当前Stream被过滤 */
        MSP_ERROR_STREAM_CLEAR = 10142,    /* 0X279E */   /* AIUI当前Stream被清理 */

        /* Error codes of network 10200(0x27D8)*/
        MSP_ERROR_NET_GENERAL = 10200, 	/* 0x27D8 */
        MSP_ERROR_NET_OPENSOCK = 10201, 	/* 0x27D9 */   /* Open socket */
        MSP_ERROR_NET_CONNECTSOCK = 10202, 	/* 0x27DA */   /* Connect socket */
        MSP_ERROR_NET_ACCEPTSOCK = 10203, 	/* 0x27DB */   /* Accept socket */
        MSP_ERROR_NET_SENDSOCK = 10204, 	/* 0x27DC */   /* Send socket data */
        MSP_ERROR_NET_RECVSOCK = 10205, 	/* 0x27DD */   /* Recv socket data */
        MSP_ERROR_NET_INVALIDSOCK = 10206, 	/* 0x27DE */   /* Invalid socket handle */
        MSP_ERROR_NET_BADADDRESS = 10207, 	/* 0x27EF */   /* Bad network address */
        MSP_ERROR_NET_BINDSEQUENCE = 10208, 	/* 0x27E0 */   /* Bind after listen/connect */
        MSP_ERROR_NET_NOTOPENSOCK = 10209, 	/* 0x27E1 */   /* Socket is not opened */
        MSP_ERROR_NET_NOTBIND = 10210, 	/* 0x27E2 */   /* Socket is not bind to an address */
        MSP_ERROR_NET_NOTLISTEN = 10211, 	/* 0x27E3 */   /* Socket is not listening */
        MSP_ERROR_NET_CONNECTCLOSE = 10212, 	/* 0x27E4 */   /* The other side of connection is closed */
        MSP_ERROR_NET_NOTDGRAMSOCK = 10213, 	/* 0x27E5 */   /* The socket is not datagram type */
        MSP_ERROR_NET_DNS = 10214, 	/* 0x27E6 */   /* domain name is invalid or dns server does not function well */
        MSP_ERROR_NET_INIT = 10215, 	/* 0x27E7 */   /* ssl ctx create failed */

        /*nfl error*/
        MSP_ERROR_NFL_INNER_ERROR = 10216,    /* NFL inner error */
        MSP_ERROR_MSS_TIME_OUT = 10217,    /* MSS TIMEOUT */
        MSP_ERROT_CLIENT_TIME_OUT = 10218,    /* CLIENT TIMEOUT */
        MSP_ERROR_CLIENT_CLOSE = 10219,    /* CLIENT CLOSED CONNECTION */

        MSP_ERROR_CLIENT_AREA_CHANGE = 10220,
        MSP_ERROR_NET_SSL_HANDSHAKE = 10221,
        MSP_ERROR_NET_INVALID_ROOT_CERT = 10222,
        MSP_ERROR_NET_INVALID_CLIENT_CERT = 10223,
        MSP_ERROR_NET_INVALID_SERVER_CERT = 10224,
        MSP_ERROR_NET_INVALID_KEY = 10225,
        MSP_ERROR_NET_CERT_VERIFY_FAILED = 10226,
        MSP_ERROR_NET_WOULDBLOCK = 10227,
        MSP_ERROR_NET_NOTBLOCK = 10228,

        /* Error codes of mssp message 10300(0x283C) */
        MSP_ERROR_MSG_GENERAL = 10300, 	/* 0x283C */
        MSP_ERROR_MSG_PARSE_ERROR = 10301, 	/* 0x283D */
        MSP_ERROR_MSG_BUILD_ERROR = 10302, 	/* 0x283E */
        MSP_ERROR_MSG_PARAM_ERROR = 10303, 	/* 0x283F */
        MSP_ERROR_MSG_CONTENT_EMPTY = 10304, 	/* 0x2840 */
        MSP_ERROR_MSG_INVALID_CONTENT_TYPE = 10305, 	/* 0x2841 */
        MSP_ERROR_MSG_INVALID_CONTENT_LENGTH = 10306, 	/* 0x2842 */
        MSP_ERROR_MSG_INVALID_CONTENT_ENCODE = 10307, 	/* 0x2843 */
        MSP_ERROR_MSG_INVALID_KEY = 10308, 	/* 0x2844 */
        MSP_ERROR_MSG_KEY_EMPTY = 10309, 	/* 0x2845 */
        MSP_ERROR_MSG_SESSION_ID_EMPTY = 10310, 	/* 0x2846 */   /* 会话ID为空 */
        MSP_ERROR_MSG_LOGIN_ID_EMPTY = 10311, 	/* 0x2847 */   /* 音频序列ID为空 */
        MSP_ERROR_MSG_SYNC_ID_EMPTY = 10312, 	/* 0x2848 */
        MSP_ERROR_MSG_APP_ID_EMPTY = 10313, 	/* 0x2849 */
        MSP_ERROR_MSG_EXTERN_ID_EMPTY = 10314, 	/* 0x284A */
        MSP_ERROR_MSG_INVALID_CMD = 10315, 	/* 0x284B */
        MSP_ERROR_MSG_INVALID_SUBJECT = 10316, 	/* 0x284C */
        MSP_ERROR_MSG_INVALID_VERSION = 10317, 	/* 0x284D */
        MSP_ERROR_MSG_NO_CMD = 10318, 	/* 0x284E */
        MSP_ERROR_MSG_NO_SUBJECT = 10319, 	/* 0x284F */
        MSP_ERROR_MSG_NO_VERSION = 10320, 	/* 0x2850 */
        MSP_ERROR_MSG_MSSP_EMPTY = 10321, 	/* 0x2851 */
        MSP_ERROR_MSG_NEW_RESPONSE = 10322, 	/* 0x2852 */
        MSP_ERROR_MSG_NEW_CONTENT = 10323, 	/* 0x2853 */
        MSP_ERROR_MSG_INVALID_SESSION_ID = 10324, 	/* 0x2854 */   /* 无效的会话ID(sid) */
        MSP_ERROR_MSG_INVALID_CONTENT = 10325, 	/* 0x2855 */

        /* Error codes of DataBase 10400(0x28A0)*/
        MSP_ERROR_DB_GENERAL = 10400, 	/* 0x28A0 */   /* 数据库异常 */
        MSP_ERROR_DB_EXCEPTION = 10401, 	/* 0x28A1 */
        MSP_ERROR_DB_NO_RESULT = 10402, 	/* 0x28A2 */   /* redis中没有找到会话ID(sid) */
        MSP_ERROR_DB_INVALID_USER = 10403, 	/* 0x28A3 */
        MSP_ERROR_DB_INVALID_PWD = 10404, 	/* 0x28A4 */
        MSP_ERROR_DB_CONNECT = 10405, 	/* 0x28A5 */
        MSP_ERROR_DB_INVALID_SQL = 10406, 	/* 0x28A6 */
        MSP_ERROR_DB_INVALID_APPID = 10407,	/* 0x28A7 */
        MSP_ERROR_DB_NO_UID = 10408,

        /* Error codes of Resource 10500(0x2904)*/
        MSP_ERROR_RES_GENERAL = 10500, 	/* 0x2904 */
        MSP_ERROR_RES_LOAD = 10501, 	/* 0x2905 */   /* Load resource */
        MSP_ERROR_RES_FREE = 10502, 	/* 0x2906 */   /* Free resource */
        MSP_ERROR_RES_MISSING = 10503, 	/* 0x2907 */   /* Resource File Missing */
        MSP_ERROR_RES_INVALID_NAME = 10504, 	/* 0x2908 */   /* Invalid resource file name */
        MSP_ERROR_RES_INVALID_ID = 10505, 	/* 0x2909 */   /* Invalid resource ID */
        MSP_ERROR_RES_INVALID_IMG = 10506, 	/* 0x290A */   /* Invalid resource image pointer */
        MSP_ERROR_RES_WRITE = 10507, 	/* 0x290B */   /* Write read-only resource */
        MSP_ERROR_RES_LEAK = 10508, 	/* 0x290C */   /* Resource leak out */
        MSP_ERROR_RES_HEAD = 10509, 	/* 0x290D */   /* Resource head currupt */
        MSP_ERROR_RES_DATA = 10510, 	/* 0x290E */   /* Resource data currupt */
        MSP_ERROR_RES_SKIP = 10511, 	/* 0x290F */   /* Resource file skipped */

        /* Error codes of TTS 10600(0x2968)*/
        MSP_ERROR_TTS_GENERAL = 10600, 	/* 0x2968 */
        MSP_ERROR_TTS_TEXTEND = 10601, 	/* 0x2969 */  /* Meet text end */
        MSP_ERROR_TTS_TEXT_EMPTY = 10602, 	/* 0x296A */  /* no synth text */
        MSP_ERROR_TTS_LTTS_ERROR = 10603, 	/* 0x296B */

        /* Error codes of Recognizer 10700(0x29CC) */
        MSP_ERROR_REC_GENERAL = 10700, 	/* 0x29CC */  /* 引擎异常 */
        MSP_ERROR_REC_INACTIVE = 10701, 	/* 0x29CD */
        MSP_ERROR_REC_GRAMMAR_ERROR = 10702, 	/* 0x29CE */
        MSP_ERROR_REC_NO_ACTIVE_GRAMMARS = 10703, 	/* 0x29CF */
        MSP_ERROR_REC_DUPLICATE_GRAMMAR = 10704, 	/* 0x29D0 */
        MSP_ERROR_REC_INVALID_MEDIA_TYPE = 10705, 	/* 0x29D1 */
        MSP_ERROR_REC_INVALID_LANGUAGE = 10706, 	/* 0x29D2 */
        MSP_ERROR_REC_URI_NOT_FOUND = 10707, 	/* 0x29D3 */
        MSP_ERROR_REC_URI_TIMEOUT = 10708, 	/* 0x29D4 */
        MSP_ERROR_REC_URI_FETCH_ERROR = 10709, 	/* 0x29D5 */
        MSP_ERROR_REC_PROC_MOD = 10710,	/* 0x29D6 */


        /* Error codes of Speech Detector 10800(0x2A30) */
        MSP_ERROR_EP_GENERAL = 10800, 	/* 0x2A30 */
        MSP_ERROR_EP_NO_SESSION_NAME = 10801, 	/* 0x2A31 */
        MSP_ERROR_EP_INACTIVE = 10802, 	/* 0x2A32 */
        MSP_ERROR_EP_INITIALIZED = 10803, 	/* 0x2A33 */

        /* Error codes of TUV */
        MSP_ERROR_TUV_GENERAL = 10900, 	/* 0x2A94 */
        MSP_ERROR_TUV_GETHIDPARAM = 10901, 	/* 0x2A95 */   /* Get Busin Param huanid*/
        MSP_ERROR_TUV_TOKEN = 10902, 	/* 0x2A96 */   /* Get Token */
        MSP_ERROR_TUV_CFGFILE = 10903, 	/* 0x2A97 */   /* Open cfg file */
        MSP_ERROR_TUV_RECV_CONTENT = 10904, 	/* 0x2A98 */   /* received content is error */
        MSP_ERROR_TUV_VERFAIL = 10905, 	/* 0x2A99 */   /* Verify failure */

        /* Error codes of IMTV */
        MSP_ERROR_LOGIN_SUCCESS = 11000, 	/* 0x2AF8 */   /* 成功 */
        MSP_ERROR_LOGIN_NO_LICENSE = 11001, 	/* 0x2AF9 */   /* 试用次数结束，用户需要付费 */
        MSP_ERROR_LOGIN_SESSIONID_INVALID = 11002, 	/* 0x2AFA */   /* SessionId失效，需要重新登录通行证 */
        MSP_ERROR_LOGIN_SESSIONID_ERROR = 11003, 	/* 0x2AFB */   /* SessionId为空，或者非法 */
        MSP_ERROR_LOGIN_UNLOGIN = 11004, 	/* 0x2AFC */   /* 未登录通行证 */
        MSP_ERROR_LOGIN_INVALID_USER = 11005, 	/* 0x2AFD */   /* 用户ID无效 */
        MSP_ERROR_LOGIN_INVALID_PWD = 11006, 	/* 0x2AFE */   /* 用户密码无效 */
        MSP_ERROR_LOGIN_SYSTEM_ERROR = 11099, 	/* 0x2B5B */   /* 系统错误 */

        /* Error codes of HCR */
        MSP_ERROR_HCR_GENERAL = 11100,
        MSP_ERROR_HCR_RESOURCE_NOT_EXIST = 11101,
        MSP_ERROR_HCR_CREATE = 11102,
        MSP_ERROR_HCR_DESTROY = 11103,
        MSP_ERROR_HCR_START = 11104,
        MSP_ERROR_HCR_APPEND_STROKES = 11105,
        MSP_ERROR_HCR_INIT = 11106,
        MSP_ERROR_HCR_POINT_DECODE = 11107,
        MSP_ERROR_HCR_DISPATCH = 11108,
        MSP_ERROR_HCR_GETRESULT = 11109,
        MSP_ERROR_HCR_RESOURCE = 11110,

        /* Error Codes using in local engine */
        MSP_ERROR_AUTH_NO_LICENSE = 11200,	/* 0x2BC0 */   /* 无授权 */
        MSP_ERROR_AUTH_NO_ENOUGH_LICENSE = 11201,	/* 0x2BC1 */   /* 授权不足 */
        MSP_ERROR_AUTH_INVALID_LICENSE = 11202,	/* 0x2BC2 */   /* 无效的授权 */
        MSP_ERROR_AUTH_LICENSE_EXPIRED = 11203,	/* 0x2BC3 */   /* 授权过期 */
        MSP_ERROR_AUTH_NEED_MORE_DATA = 11204,    /* 0x2BC4 */   /* 无设备信息 */
        MSP_ERROR_AUTH_LICENSE_TO_BE_EXPIRED = 11205,	/* 0x2BC5 */   /* 授权即将过期，警告性错误码 */
        MSP_ERROR_AUTH_INVALID_MACHINE_ID = 11206,    /* 0x2BC6 */   /* 无效的机器码 */
        MSP_ERROR_AUTH_LOCAL_ASR_FORBIDDEN = 11207,    /* 0x2BC7 */   /* 禁止使用本地识别引擎 */
        MSP_ERROR_AUTH_LOCAL_TTS_FORBIDDEN = 11208,    /* 0x2BC8 */   /* 禁止使用本地合成引擎 */
        MSP_ERROR_AUTH_LOCAL_IVW_FORBIDDEN = 11209,    /* 0x2BC9 */   /* 禁止使用本地唤醒引擎 */
        MSP_ERROR_AUTH_APPID_NOT_MATCH = 11210,	/* 0x2BCA */   /* 资源appid和应用appid不匹配 */
        MSP_ERROR_AUTH_UID_NOT_MATCH = 11211,	/* 0x2BCB */   /* 资源uid和登录用户uid不匹配 */
        MSP_ERROR_AUTH_TRIAL_EXPIRED = 11212,	/* 0x2BCC */   /* 试用资源过期 */
        MSP_ERROR_AUTH_LOCAL_IFD_FORBIDDEN = 11213,    /* 0x2BC9 */   /* 禁止使用本地人脸引擎 */

        /*Error Codes of Authorization*/
        MSP_ERROR_AUTH_DVC_NO_LICENSE = 11300,
        MSP_ERROR_AUTH_DVC_NO_ENOUGH_LICENSE = 11301,
        MSP_ERROR_AUTH_DVC_INVALID_LICENSE = 11302,
        MSP_ERROR_AUTH_DVC_LICENSE_EXPIRED = 11303,
        MSP_ERROR_AUTH_DVC_NEED_MORE_DATA = 11304,
        MSP_ERROR_AUTH_DVC_LICENSE_TO_BE_EXPIRED = 11305,
        MSP_ERROR_AUTH_DVC_EXCEED_LICENSE = 11306,

        /* Error codes of Ise */

        MSP_ERROR_ASE_EXCEP_SILENCE = 11401,
        MSP_ERROR_ASE_EXCEP_SNRATIO = 11402,
        MSP_ERROR_ASE_EXCEP_PAPERDATA = 11403,
        MSP_ERROR_ASE_EXCEP_PAPERCONTENTS = 11404,
        MSP_ERROR_ASE_EXCEP_NOTMONO = 11405,
        MSP_ERROR_ASE_EXCEP_OTHERS = 11406,
        MSP_ERROR_ASE_EXCEP_PAPERFMT = 11407,
        MSP_ERROR_ASE_EXCEP_ULISTWORD = 11408,

        /* Error codes of Iot */
        MSP_ERROR_IOT_BASE = 11500,
        MSP_ERROR_IOT_PARAM_ERROR = 11501,		// param error
        MSP_ERROR_IOT_INVALID_SERVICE = 11502,		// invalid service for iot ProTranServer
        MSP_ERROR_IOT_INVALID_PRODUCTID = 11503,		// invalid productid for ProTranServer
        MSP_EEROR_IOT_INVALID_ATTR = 11504,		// invalid attr value for one product in ProTranServer
        MSP_ERROR_IOT_INVALID_PLATFORM = 11505,		// invalid platform for ProTranServer
        MSP_ERROR_IOT_DID_NOT_FOUND = 11506,		// not found device id in semantic

        /* Error codes of IVP */
        MSP_ERROR_IVP_GENERAL = 11600,            //  内核异常
        MSP_ERROR_IVP_EXTRA_RGN_SOPPORT = 11601,            //  注册时向引擎所写音频条数超过上限(9次)
        MSP_ERROR_IVP_TRUNCATED = 11602,            //  音频截幅(因信号波形的幅度太大，而超出系统的线性范围)，如记录尖叫声的音频
        MSP_ERROR_IVP_MUCH_NOISE = 11603,            //  音频信噪比过低
        MSP_ERROR_IVP_TOO_LOW = 11604,            //  音频能量过低
        MSP_ERROR_IVP_ZERO_AUDIO = 11605,            //  无音频
        MSP_ERROR_IVP_UTTER_TOO_SHORT = 11606,            //  音频太短
        MSP_ERROR_IVP_TEXT_NOT_MATCH = 11607,            //  1.音频和文本不匹配，常见原因1.抢读(在按下录音键之前读)
        //  2.录音机的启动电流被录入表现在音频上是在音频首有冲击电流 3.确实不匹配"
        MSP_ERROR_IVP_NO_ENOUGH_AUDIO = 11608,            //  音频不够，注册自由说，而写入的音频又不够长时会报，告诉调用者继续传音频
        MSP_ERROR_IVP_MODEL_NOT_FOUND_IN_HBASE = 11610,            //  模型在hbase中没找到

        /* Error codes of Face */

        MSP_ERROR_IFR_NOT_FACE_IMAGE = 11700,			//	【无人脸，对应的引擎错误码是20200 】      
        MSP_ERROR_FACE_IMAGE_FULL_LEFT = 11701,			//	【人脸向左，对应的引擎错误码是20201】
        MSP_ERROR_FACE_IMAGE_FULL_RIGHT = 11702,			//	【人脸向右，对应的引擎错误码是20202】
        MSP_ERROR_IMAGE_CLOCKWISE_WHIRL = 11703,			//	【顺时针旋转，对应的引擎错误码是20203】
        MSP_ERROR_IMAGE_COUNTET_CLOCKWISE_WHIRL = 11704,			//	【逆时针旋转，对应的引擎错误码是20204】
        MSP_ERROR_VALID_IMAGE_SIZE = 11705,			//	【图片大小异常 ，对应的引擎错误码是20205】
        MSP_ERROR_ILLUMINATION = 11706,			//	【光照异常，对应的引擎错误码是20206】
        MSP_ERROR_FACE_OCCULTATION = 11707,		    //	【人脸被遮挡，对应的引擎错误码是20207】
        MSP_ERROR_FACE_INVALID_MODEL = 11708,			//	【非法模型数据，对应的引擎错误码是20208】
        MSP_ERROR_FUSION_INVALID_INPUT_TYPE = 11709,			//	【输入数据类型非法，对应的引擎错误码是20300】
        MSP_ERROR_FUSION_NO_ENOUGH_DATA = 11710,			//	【输入的数据不完整，对应的引擎错误码是20301】
        MSP_ERROR_FUSION_ENOUGH_DATA = 11711,			//	【输入的数据过多，对应的引擎错误码是20302】

        /*Error Codes of AIUI*/
        MSP_ERROR_AIUI_CID_EXPIRED = 11800,

        /* Error codes of http 12000(0x2EE0) */
        MSP_ERROR_HTTP_BASE = 12000,	/* 0x2EE0 */
    }

    internal enum SynthStatusiFlytek
    {
        MSP_TTS_FLAG_STILL_HAVE_DATA = 1,
        MSP_TTS_FLAG_DATA_END = 2,
        MSP_TTS_FLAG_CMD_CANCELED = 0
    }

    internal enum ErrorCodeUsc
    {
        // 识别句柄错误
        USC_ASR_NO_HANDLE_INPUT = -91138,

        // 参数ID错误
        USC_ASR_INVALID_ID = -91151,

        // 参数错误
        USC_ASR_INVALID_PARAMETERS = -91152,

        // 语音数据格式错误
        USC_ASR_INVALID_INPUT_DATA = -91157,

    }
    internal enum StatusUsc
    {
        // 识别正常
        USC_ASR_OK = 0,

        // 有结果返回
        USC_RECOGNIZER_PARTIAL_RESULT = 2,

        // 检测到语音开始
        USC_RECOGNIZER_SPEAK_BEGIN = 100,

        // 检测到语音结束
        USC_RECOGNIZER_SPEAK_END = 101,
    }

    internal enum ParamIdUsc
    {
        // 参数为APP_KEY
        USC_OPT_ASR_APP_KEY = 9,

        // 参数为用户ID
        USC_OPT_ASRUSER_ID = 14,

        // 选择识别领域 
        USC_OPT_RECOGNITION_FIELD = 18,

        //语言选择
        USC_OPT_LANGUAGE_SELECT = 20,

        USC_OPT_ASR_ENGINE_PARAMETER = 104,

        // 设置语义参数
        USC_OPT_NLU_PARAMETER = 201,

        // 参数为用户secret
        USC_OPT_USER_SECRET = 204,

        // 输入语音编码格式
        USC_OPT_INPUT_AUDIO_FORMAT = 1001,

        // 识别结果文本中是否使用标点符号
        USC_OPT_PUNCTUATION_ENABLED = 1002,

        // 语音解码帧字节长度
        USC_OPT_DECODE_FRAME_SIZE = 1003,

        // 噪音数据过滤
        USC_OPT_NOISE_FILTER = 1004,

        USC_OPT_RESULT_FORMAT = 1006,

        USC_SERVICE_STATUS_SELECT = 1015,

    };

    internal enum AudioStatusiFlytek
    {
        MSP_AUDIO_SAMPLE_FIRST = 1,
        MSP_AUDIO_SAMPLE_CONTINUE = 2,
        MSP_AUDIO_SAMPLE_LAST = 4,
    }

    internal enum EpStatusiFlytek
    {
        MSP_EP_NULL = -1,
        MSP_EP_LOOKING_FOR_SPEECH = 0,          ///还没有检测到音频的前端点
        MSP_EP_IN_SPEECH = 1,                   ///已经检测到了音频前端点，正在进行正常的音频处理。
        MSP_EP_AFTER_SPEECH = 3,                ///检测到音频的后端点，后继的音频会被MSC忽略。
        MSP_EP_TIMEOUT = 4,                     ///超时
        MSP_EP_ERROR = 5,                       ///出现错误
        MSP_EP_MAX_SPEECH = 6                   ///音频过大
    }

    public enum RecogStatusiFlytek
    {
        MSP_REC_NULL = -1,
        MSP_REC_STATUS_SUCCESS = 0,             ///识别成功，此时用户可以调用QISRGetResult来获取（部分）结果。
        MSP_REC_STATUS_NO_MATCH = 1,            ///识别结束，没有识别结果
        MSP_REC_STATUS_INCOMPLETE = 2,          ///正在识别中
        MSP_REC_STATUS_NON_SPEECH_DETECTED = 3, ///保留
        MSP_REC_STATUS_SPEECH_DETECTED = 4,     ///发现有效音频
        MSP_REC_STATUS_SPEECH_COMPLETE = 5,     ///识别结束
        MSP_REC_STATUS_MAX_CPU_TIME = 6,        ///保留
        MSP_REC_STATUS_MAX_SPEECH = 7,          ///保留
        MSP_REC_STATUS_STOPPED = 8,             ///保留
        MSP_REC_STATUS_REJECTED = 9,            ///保留
        MSP_REC_STATUS_NO_SPEECH_FOUND = 10     ///没有发现音频
    }
    /// <summary>
    /// 百度语音合成的错误代码
    /// </summary>
    public enum TTSErrorCodeBaidu
    {
        Error_Code_Success = 0,
        Error_Code_One = 500,
        Error_Code_Two = 501,
        Error_Code_Three = 502,
        Error_Code_Four = 503,
    }
}
