using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WxTenpay
{
    [Description("微信基本配置类")]
    public class WXconfig
    {
        [Description("公众号ID")]
        public const string appid = "";//公众号ID
        [Description("微信公众号的secret")]
        public const string secret = "";//微信公众号的secret
        [Description("回调url")]
        public const string url = "";//回调url
        [Description("商户号")]
        public const string mch_id = "";//商户号
        [Description("证书密匙")]
        public const string paysignkey = "";//证书密匙
        [Description("证书路径")]
        public const string SSLCERT_PATH = "";//证书路径
        [Description("证书的密码")]
        public const string SSLCERT_PASSWORD = "";//证书的密码

    }


    /// <summary>
    /// 阿里云短信配置
    /// </summary>
    public class Aliconfig
    {
        /// <summary>
        /// 阿里云ID
        /// </summary>
        public const string accessKeyId = "";
        /// <summary>
        /// 阿里云KEY
        /// </summary>
        public const string accessKeySecret = "";

    }

    /// <summary>
    /// 支付宝配置
    /// </summary>
    public class Ailconfig
    {
        /// <summary>
        /// 支付宝ID
        /// </summary>
       public const string APPID = "";
        /// <summary>
        /// 你的应用私钥
        /// /// </summary>
        public const string APP_PRIVATE_KEY = "";
        /// <summary>
        /// 你的支付宝公钥
        /// </summary>
        public const  string ALIPAY_PUBLIC_KEY = "";
        /// <summary>
        /// 支付宝异步url地址
        /// </summary>
        public const string   NotifyUrl= "";
        /// <summary>
        /// 支付宝同步url地址
        /// </summary>
        public const string ReturnUrl = "";
    }

}
