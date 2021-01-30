using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    /// <summary>
    /// 权限配置
    /// </summary>
    public class Sys_RoleAuthorizationEntity
    {
        public int Id { set; get; }
        public string GuId { set; get; } = "";
        /// <summary>
        /// 菜单Gid
        /// </summary>
        public string MenuGid { set; get; } = "";
        /// <summary>
        /// 用户Gid
        /// </summary>
        public string  UserGid { set; get; } = "";
        /// <summary>
        /// 按钮事件权限
        /// </summary>
        public string ButtonLis { set; get; } = "";
        /// <summary>
        /// 添加时间
        /// </summary>
        public string CreateTime { set; get; } = "";
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
