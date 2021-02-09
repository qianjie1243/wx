using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Sys_ButtonEntity
    {
        public int Id { set; get; }

        public string GuId { set; get; } = "";

        /// <summary>
        /// 功能按钮编号
        /// </summary>
        public string Number { set; get; } = "";
        /// <summary>
        /// 功能按钮名称
        /// </summary>
        public string Name { set; get; } = "";

        /// <summary>
        /// 添加时间
        /// </summary>
        public string CreateTime { set; get; } = "";

        /// <summary>
        /// 菜单ID
        /// </summary>
        public string MenuId { set; get; } = "";

        public int IsDel { set; get; } = 0;

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
