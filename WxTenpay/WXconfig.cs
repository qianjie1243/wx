using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace  WxTenpay
{
    /// <summary>
    /// 微信公众号配置
    /// </summary>
    [Description("微信基本配置类")]
    public static class WXconfig
    {
        [Description("公众号ID")]
        public static string appid = "wxad5c6b5c0796716f";//公众号ID
        [Description("微信公众号的secret")]
        public static string secret = "5fd73cb4473735eda6fe5b301405e5f6";//微信公众号的secret
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

    /// <summary>
    /// 微信支付--小程序基本配置
    /// </summary>
    public class SmallProgram {
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


    /// <summary>
    /// 阿里云短信配置
    /// </summary>
    public class Aliconfig
    {
        /// <summary>
        /// 阿里云ID
        /// </summary>
        public static string accessKeyId = "";
        /// <summary>
        /// 阿里云KEY
        /// </summary>
        public static string accessKeySecret = "";

    }

    /// <summary>
    /// 支付宝配置
    /// </summary>
    public class Ailconfig
    {
        /// <summary>
        /// 支付宝ID
        /// </summary>
       public static string APPID = "";
        /// <summary>
        /// 你的应用私钥
        /// /// </summary>
        public static string APP_PRIVATE_KEY = "";
        /// <summary>
        /// 你的支付宝公钥
        /// </summary>
        public static string ALIPAY_PUBLIC_KEY = "";
        /// <summary>
        /// 支付宝异步url地址
        /// </summary>
        public static string   NotifyUrl= "";
        /// <summary>
        /// 支付宝同步url地址
        /// </summary>
        public static string ReturnUrl = "";
    }

    /// <summary>
    /// 百度map   ak 参数
    /// </summary>
    public class BaiduMap {
        /// <summary>
        /// 百度地图的ak参数
        /// </summary>
        public static string ak { set; get; } = "";

    }


}
