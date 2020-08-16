using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxTenpay.WXoperation.TModel
{
    /// <summary>
    /// 自动回复消息类型
    /// </summary>
    public class Message
    {

        public string GuId { set; get; } = "";
        /// <summary>
        /// 消息类型 1:自动回复  2：关注 3：取消关注
        /// </summary>
        public int Type { set; get; } = 1;

        /// <summary>
        /// 消息模板 1:文本消息类型  2：图文消息主体 3：图片消息  4：语音消息  5：音乐消息  6：视频消息 
        /// </summary>
        public int Key { set; get; } = 1;

        /// <summary>
        /// 匹配的内容
        /// </summary>
        public string Name { set; get; } = "";

        /// <summary>
        /// 发送具体内容
        /// </summary>
        public string Content { set; get; } = "";
        /// <summary>
        /// 匹配方式0：模糊匹配  1：全部匹配
        /// </summary>
        public int MatchingWay { set; get; } = 0;
      

    }
}
