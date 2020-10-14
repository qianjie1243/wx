using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 推送记录
    /// </summary>
    public class Wx_PushListEntity
    {
        public int Id { set; get; }

        public string GuId { set; get; } = "";
        /// <summary>
        /// 模板ID 
        /// </summary>
        public string TempId { set; get; } = "";

        /// <summary>
        ///推送人ID 
        /// </summary>
        public string Oppid { set; get; } = "";

        /// <summary>
        /// 推送内容
        /// </summary>
        public string Content { set; get; } = "";
        /// <summary>
        /// 返回结果
        /// </summary>
        public string ResContent { set; get; } = "";

        /// <summary>
        ///添加时间
        /// </summary>
        public string CreateTime { set; get; } = "";

        /// <summary>
        /// 微信id
        /// </summary>
        public string WxAppId { set; get; } = "";

        /// <summary>
        /// 模板对象
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public Wx_PushTemplateEntity PushTemp { set; get; } = new Wx_PushTemplateEntity();

        /// <summary>
        /// 用户对象
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public Wx_UserEntity User { set; get; } = new Wx_UserEntity();
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
