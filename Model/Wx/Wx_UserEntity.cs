using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 微信关注用户
    /// </summary>
    public class Wx_UserEntity
    {

        public int Id { set; get; }

        public string GuId { set; get; } = "";
        /// <summary>
        /// Openid 
        /// </summary>
        public string Openid { set; get; } = "";

        /// <summary>
        ///昵称 
        /// </summary>
        public string Nickname { set; get; } = "";

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { set; get; } = "";
        /// <summary>
        /// 头像地址
        /// </summary>
        public string Headimgurl { set; get; } = "";
        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { set; get; } = 0;
        /// <summary>
        /// 关注时间
        /// </summary>
        public string SubscribeTime { set; get; } = "";

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
