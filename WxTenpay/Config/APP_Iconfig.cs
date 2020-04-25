using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WxTenpay
{
    /// <summary>
    /// APPios 支付配置
    /// </summary>
    public class APP_Iconfig
    {
        #region 
        /// <summary>
        /// 回调url
        /// </summary>
        public static string url = "";//回调url
        /// <summary>
        ///     商户号
        /// </summary>
        public static string mch_id = "";//
        /// <summary>
        /// 应用的ID
        /// </summary>
        public static string appid = "";//
        /// <summary>
        ///   证书密匙
        /// </summary>
        public static string paysignkey = "";//

        #endregion
    }
}