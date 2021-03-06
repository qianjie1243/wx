﻿using Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class DbContext
    {
        public DbContext()
        {
            Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConfigurationManager.ConnectionStrings["connectionstring"].ToString(),
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true
            });
            //调式代码 用来打印SQL 
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                string s = sql;
                //Console.WriteLine(sql + "\r\n" +
                //   Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                //Console.WriteLine();
            };
        }
        public SqlSugarClient Db;//用来处理事务多表查询和复杂的操作

        #region 系统设置
        public SimpleClient<Sys_ButtonEntity> SysButtonDb => new SimpleClient<Sys_ButtonEntity>(Db);
        public SimpleClient<Sys_MenuEntity> SysMenuDB => new SimpleClient<Sys_MenuEntity>(Db);
        public SimpleClient<Sys_UserEntity> SysUserDB => new SimpleClient<Sys_UserEntity>(Db);
        public SimpleClient<Sys_logEntity> SyslogDB => new SimpleClient<Sys_logEntity>(Db);
        public SimpleClient<TableTypeEntity> SystableDB => new SimpleClient<TableTypeEntity>(Db);
        public SimpleClient<Sys_RoleAuthorizationEntity> Sys_RoleAuthorizationDB => new SimpleClient<Sys_RoleAuthorizationEntity>(Db);
        
        #endregion

        #region 微信
        public SimpleClient<Wx_MenuEntity> WxMenu => new SimpleClient<Wx_MenuEntity>(Db);
        public SimpleClient<Wx_MessageEntity> WxMessage => new SimpleClient<Wx_MessageEntity>(Db);
        public SimpleClient<Wx_EvenMessageEntity> WxEvenMessage => new SimpleClient<Wx_EvenMessageEntity>(Db);
        public SimpleClient<Wx_UserEntity> WxUser => new SimpleClient<Wx_UserEntity>(Db);
        public SimpleClient<Wx_PushTemplateEntity> WxPushTemplate => new SimpleClient<Wx_PushTemplateEntity>(Db);
        public SimpleClient<Wx_PushListEntity> WxPushList => new SimpleClient<Wx_PushListEntity>(Db);

        
        #endregion 
    }
}
