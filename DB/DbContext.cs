using Model;
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
                ConnectionString = ConfigurationManager.AppSettings["connectionstring"],
                DbType = DbType.SqlServer,
                IsAutoCloseConnection = true
            });
            //调式代码 用来打印SQL 
            Db.Aop.OnLogExecuting = (sql, pars) =>
            {
                string s = sql;
                //Console.WriteLine(sql + "\r\n" +
                //    Db.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value)));
                //Console.WriteLine();
            };
        }
        public SqlSugarClient Db;//用来处理事务多表查询和复杂的操作

        //系统设置
        public SimpleClient<Sys_ButtonEntity> SysButtonDb => new SimpleClient<Sys_ButtonEntity>(Db);
        public SimpleClient<Sys_MenuEntity> SysMenuDB => new SimpleClient<Sys_MenuEntity>(Db);

        public SimpleClient<Sys_UserEntity> SysUserDB => new SimpleClient<Sys_UserEntity>(Db);

    }
}
