using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WxTenpay
{
    /// <summary>
    /// APP安卓支付配置
    /// </summary>
    public class APP_Aconfig
    {
        public static string url = "";//回调ur

        #region
        [Description("商户号")]
        public static string mch_id = "";//商户号
        public static string appid = "";//APPID
        public static string partnerid = "";//商户号
        public static string paysignkey = "";//证书密匙  


        #endregion     

    }
}