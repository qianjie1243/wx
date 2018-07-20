using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WxTenpay.wxconfig
{
    /// <summary>
    /// 错误信息类
    /// </summary>
    public class erroy
    {
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