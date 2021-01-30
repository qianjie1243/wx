
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Model
{
    public class Sys_UserEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { set; get; }
        /// <summary>
        /// 
        /// </summary>
        public string GuId { set; get; } = "";
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { set; get; } = "";
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { set; get; } = "";
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { set; get; } = "";
        /// <summary>
        /// 手机号码
        /// </summary>
        public string Phone { set; get; } = "";
        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { set; get; } = "";
        /// <summary>
        /// 加密key
        /// </summary>
        public string key { set; get; } = "";
        /// <summary>
        /// 加密密码
        /// </summary>
        public string EncryPwd { set; get; } = "";

        /// <summary>
        /// 状态 0：正常 1：禁用
        /// </summary>
        public int IsDel { set; get; } = 0;

        /// <summary>
        /// 添加时间
        /// </summary>
        public string CreateTime { set; get; } = "";

        /// <summary>
        /// 访问时间
        /// </summary>
        /// 
        [SugarColumn(IsIgnore = true)]
        public string LogTime { set; get; } = "";

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

