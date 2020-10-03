﻿using System;
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

    }
}