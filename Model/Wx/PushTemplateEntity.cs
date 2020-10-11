using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Wx_PushTemplateEntity
    {

        public int Id { set; get; }

        public string GuId { set; get; } = "";
        /// <summary>
        /// 模板ID 
        /// </summary>
        public string TempId { set; get; } = "";

        /// <summary>
        ///模板名称 
        /// </summary>
        public string Name { set; get; } = "";

        /// <summary>
        /// 详情
        /// </summary>
        public string Content { set; get; } = "";
     

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
