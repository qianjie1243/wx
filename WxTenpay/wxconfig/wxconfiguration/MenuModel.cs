using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxTenpay.wxconfig.wxconfiguration
{

    /// <summary>
    /// 二级菜单的参数
    /// </summary>
    public class MenuModel
    {     
        /// <summary>
        ///菜单的响应动作类型，view表示网页类型，click表示点击类型，miniprogram表示小程序类型
        /// </summary>
        public string type { set; get; }

        /// <summary>
        ///菜单标题
        /// </summary>
        public string name { set; get; }

        /// <summary>
        /// click等点击类型必须	菜单KEY值，用于消息接口推送，不超过128字节
        /// </summary>
        public string key { set; get; }

        /// <summary>
        ///view、miniprogram类型必须
        /// </summary>
        public string url { set; get; }

        /// <summary>
        ///调用新增永久素材接口返回的合法media_id
        /// </summary>
        public string media_id { set; get; }

        /// <summary>
        ///小程序的appid（仅认证公众号可配置）
        /// </summary>
        public string appid { set; get; }

        /// <summary>
        ///	小程序的页面路径
        /// </summary>
        public string pagepath { set; get; }

        /// <summary>
        ///二级菜单数组，个数应为1~5个
        /// </summary>
        public List<MenuModel> sub_button { set; get; }
    }
}
