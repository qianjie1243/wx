using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WxTenpay.wxconfig
{
    [Serializable]
    public class token
    {
        /// <summary>
        /// 凭证
        /// </summary>
        public string access_token { set; get; }
        /// <summary>
        /// 有效时间
        /// </summary>
        public string expires_in { set; get; }
        /// <summary>
        /// jsp_api签到凭证
        /// </summary>
        public string ticket { set; get; }
    }
}