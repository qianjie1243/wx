using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 菜单名称管理数据
    /// </summary>
    public class Sys_MenuEntity
    {
        public int Id { set; get; }

        public string GuId { set; get; } = Guid.NewGuid().ToString();

        /// <summary>
        /// 菜单名
        /// </summary>
        public string Name { set; get; } = "";

        /// <summary>
        /// 编号
        /// </summary>
        public string Number { set; get; } = "";

        /// <summary>
        /// 上级菜单 0：顶级 
        /// </summary>
        public string SuperiorId { set; get; } = "0";

        /// <summary>
        /// 菜单地址
        /// </summary>
        public string Address { set; get; } = "";

        /// <summary>
        ///状态 0：正常 1：移除
        /// </summary>
        public int IsDel { set; get; } = 0;

        /// <summary>
        ///排序
        /// </summary>
        public int Sort { set; get; } = 0;

        /// <summary>
        ///类型 iframe   expand 
        /// </summary>
        public string Type { set; get; } = "";

        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { set; get; } = "";

        /// <summary>
        /// 权限按钮列表
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<Sys_ButtonEntity> buttons { set; get; }

        /// <summary>
        /// 子集菜单
        /// </summary>
        [SugarColumn(IsIgnore = true)]
        public List<Sys_MenuEntity> PSysMenu { set; get; } = new List<Sys_MenuEntity>();

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
