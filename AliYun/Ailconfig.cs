using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


/// <summary>
/// 阿里配置文件
/// </summary>
namespace AliYun
{

    #region 阿里云配置
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
    #endregion

    #region  支付宝配置
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
        public static string NotifyUrl = "";
        /// <summary>
        /// 支付宝同步url地址
        /// </summary>
        public static string ReturnUrl = "";
    }
    #endregion 

    #region  百度map配置

    /// <summary>
    /// 百度map   ak 参数
    /// </summary>
    public class BaiduMap
    {
        /// <summary>
        /// 百度地图的ak参数
        /// </summary>
        public static string ak { set; get; } = "";

    }
    #endregion
}

