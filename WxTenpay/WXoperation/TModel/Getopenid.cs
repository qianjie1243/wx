using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WxTenpay.WXoperation
{
    [Serializable]
    /// <summary>
    /// 获取openid 和access_token类
    /// </summary>
    public class Getopenid
    {
        /// <summary>
        /// openid 用户唯一标识，请注意，在未关注公众号时，用户访问公众号的网页，也会产生一个用户和公众号唯一的OpenID
        /// </summary>
        public string openid { set; get; }
        /// <summary>
        /// 网页授权接口调用凭证,注意：此access_token与基础支持的access_token不同
        /// </summary>
        public string access_token { set; get; }
        /// <summary>
        /// expires_in	access_token接口调用凭证超时时间，单位（秒）
        /// </summary>
        public string expires_in { set; get; }
        /// <summary>
        /// refresh_token	用户刷新access_token
        /// </summary>
        public string refresh_token { set; get; }
        /// <summary>
        /// scope	用户授权的作用域，使用逗号（,）分隔
        /// </summary>
        public string scope { set; get; }
        /// <summary>
        /// 错误编号
        /// </summary>
        public string errcode { set; get; }
        /// <summary>
        /// 错误原因
        /// </summary>
        public string errmsg { set; get; }
    }
}