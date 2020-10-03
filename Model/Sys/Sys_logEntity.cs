using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 系统日志
    /// </summary>
    public class Sys_logEntity
    {

        public int Id { set; get; }
        public string GuId { set; get; } = "";
        /// <summary>
        /// 类型名称
        /// </summary>
        public string Name { set; get; } = "";

        /// <summary>
        /// 类型 0：异常  1：编辑
        /// </summary>
        public int Type { set; get; } = 0;
        /// <summary>
        /// 错误内容
        /// </summary>
        public string Content { set; get; } = "";
        /// <summary>
        /// 添加时间
        /// </summary>
        public string CreateTime { set; get; } = "";

        /// <summary>
        /// 控制器名称
        /// </summary>
        public string Action { set; get; } = "";

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
