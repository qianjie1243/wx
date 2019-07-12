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
        [Description("微信公众号的secret")]
        public static string secret = "";//
        /// <summary>
        ///       回调url
        /// </summary>
        [Description("回调url")]
        public static string url = "";//
        /// <summary>
        ///   商户号
        /// </summary>
        [Description("商户号")]
        public static string mch_id = "";//
        /// <summary>
        ///     证书密匙
        /// </summary>
        [Description("证书密匙")]
        public static string paysignkey = "";//
        /// <summary>
        ///  证书路径
        /// </summary>
        [Description("证书路径")]
        public static string SSLCERT_PATH = "";//
        /// <summary>
        ///  证书的密码
        /// </summary>
        [Description("证书的密码")]
        public static string SSLCERT_PASSWORD = "";//

    }

    /// <summary>
    /// 微信支付--小程序基本配置
    /// </summary>
    public class SmallProgram
    {
        [Description("小程序")]
        public static string appid = "";//公众号ID     
        [Description("回调url")]
        public static string url = "";//回调url
        [Description("商户号")]
        public static string mch_id = "";//商户号
        [Description("证书密匙")]
        public static string paysignkey = "";//证书密匙
        [Description("证书路径")]
        public static string SSLCERT_PATH = "";//证书路径
        [Description("证书的密码")]
        public static string SSLCERT_PASSWORD = "";//证书的密码
    }





}
