using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WxTenpay
{
    /// <summary>
    /// APPios 支付配置
    /// </summary>
    public class APP_Iconfig
    {
        /// <summary>
        /// 回调url
        /// </summary>
        public static string url = "";//回调url


        #region 
        public static string appid = "";//应用的ID
        public static string partnerid = "";//商户号
        public static string paysignkey = "";//证书密匙
       
        #endregion
    }
}