using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 微信素材管理
    /// </summary>
    public class Wx_MaterialEntity
    {
        public int Id { set; get; }
        public string GuId { set; get; } = "";

        /// <summary>
        /// 类型
        /// </summary>
        public string Type { set; get; } = "";
        /// <summary>
        /// json 详情
        /// </summary>
        public string Content { set; get; } = "";
        /// <summary>
        /// 新增的图文消息素材的media_id
        /// </summary>
        public string Media_Id { set; get; } = "";

        /// <summary>
        /// 素材的描述
        /// </summary>
        public string Introduction { set; get; } = "";

        /// <summary>
        /// 新增的图片素材的图片URL（仅新增图片素材时会返回该字段）
        /// </summary>
        public string Url { set; get; } = "";

        /// <summary>
        /// 文件地址
        /// </summary>
        public string PathUrl { set; get; } = "";
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
