using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Wx_MessageEntity
    {

        public int Id { set; get; }

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

        /// <summary>
        ///添加时间
        /// </summary>
        public string CreateTime { set; get; } = "";

        /// <summary>
        /// 微信id
        /// </summary>
        public string WxAppId { set; get; } = "";

        /// <summary>
        /// 新增方法
        /// </summary>
        public void Create()
        {
            if (string.IsNullOrWhiteSpace(this.GuId))
                this.GuId = Guid.NewGuid().ToString();
            if (string.IsNullOrWhiteSpace(this.CreateTime))
                this.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
