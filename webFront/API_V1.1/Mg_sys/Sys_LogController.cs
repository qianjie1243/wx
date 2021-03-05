using Business.Business;
using Common;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using webFront.Models;

namespace webFront.API
{
    /// <summary>
    /// 系统日志管理
    /// </summary>
    public class Sys_LogController : BaseController
    {
        #region 业务数据
        private Sys_log logbll = new Sys_log();
        #endregion


        /// <summary>
        /// 获取全部数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetPageLis(PageParm parm, string queryjson)
        {
            try
            {

                var usermolde = (Sys_UserEntity)GetUserInfo();//获取用户信息
                var query = queryjson.ToJObject();
                #region 
                var expression = LinqExtensions.True<Sys_logEntity>();
                if (usermolde.Name.ToUpper() != "SYSTEM")//不是超级管理员 获取自己数据
                    expression = expression.And(t => t.AddUserGuId == usermolde.GuId);
                if (!query["Name"].IsEmpty())
                {
                    expression = expression.And(t => t.Name.Contains(query["Name"].ToString()));
                }
                if (!query["Type"].IsEmpty())
                {
                    expression = expression.And(t => t.Type.ToString() == query["Type"].ToString());
                }

                #endregion
                return Success(logbll.GetPages(parm, expression, x => x.CreateTime, 2));
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "编辑菜单API");
            }

        }


    }
}