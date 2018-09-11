using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WxTenpay
{
    [Description("微信基本配置类")]
    public  class WXconfig
    {
        [Description("公众号ID")]
        public static string appid = "";//公众号ID
        [Description("微信公众号的secret")]
        public static string secret = "";//微信公众号的secret
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
