using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WxTenpay
{
    /// <summary>
    /// 微信公众号配置
    /// </summary>
    [Description("微信基本配置类")]
    public static class WXconfig
    {
        /// <summary>
        ///   公众号ID
        /// </summary>  
        public static string appid = "";//
        /// <summary>
        ///      微信公众号的secret
        /// </summary>
        public static string secret = "";//
        /// <summary>
        ///       回调url
        /// </summary>
        public static string url = "";//
        /// <summary>
        ///   商户号
        /// </summary>
        public static string mch_id = "";//
        /// <summary>
        ///     证书密匙
        /// </summary>
        public static string paysignkey = "";//
        /// <summary>
        ///  证书路径
        /// </summary>
        public static string SSLCERT_PATH = "";//
        /// <summary>
        ///  证书的密码
        /// </summary>
        public static string SSLCERT_PASSWORD = "";//

    }

    /// <summary>
    /// 微信支付--小程序基本配置
    /// </summary>
    public class SmallProgram
    {
        /// <summary>
        ///     小程序appid
        /// </summary>
        public static string appid = "";//公众号ID     
        /// <summary>
        /// 小程序u回调rl
        /// </summary>
        public static string url = "";//回调url
        /// <summary>
        ///    商户号
        /// </summary>
        public static string mch_id = "";//
        /// <summary>
        ///  证书密匙
        /// </summary>
        public static string paysignkey = "";
        /// <summary>
        ///    证书路径
        /// </summary>
        public static string SSLCERT_PATH = "";
        /// <summary>
        ///    证书的密码
        /// </summary>
        public static string SSLCERT_PASSWORD = "";
    }





}
