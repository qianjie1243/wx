﻿using Business.Business;
using Common;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace webFront.Models
{

    public class BaseController : Controller
    {
        private string dkey = "SYS_USER";
        private Sys_log logbll = new Sys_log();
        /// <summary>
        ///  请求成功
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public object Success(object Data)
        {
            return Json(new { Success = true, Data = Data }, JsonRequestBehavior.AllowGet);
        }
        public object Success()
        {
            return Json(new { Success = true, Data = new object() { } }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        ///  请求异常
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public object Error(object Data)
        {
            return Json(new { Success = false, Data = Data }, JsonRequestBehavior.AllowGet);
        }
        public object Error()
        {
            return Json(new { Success = false, Data = new object() { } }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 异常记录日志
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public object ErrorLog(Exception ex, string Name)
        {
            string controllerName = Request.RequestContext.RouteData.Values["controller"].ToString();//获取控制器名
            string actionName = Request.RequestContext.RouteData.Values["action"].ToString();//获取action名

            string action = controllerName + "/" + actionName;

            var model = new Sys_logEntity { Content = ex.ToString(), Name = Name, Action = action, Type = 0 };
            model.Create();
            logbll.Add(model);
            return Json(new { Success = false, Data = "系统异常" }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 操作日志记录功能
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Name"></param>
        /// <param name="Type">类型0：异常 1：新增，2修改，删除</param>
        /// <param name="UserGuId">添加数据列表</param>
        /// <returns></returns>
        public object SuccessLog(object Data, object LogData, string Name, int Type)
        {

            var usermodel = (Sys_UserEntity)GetUserInfo();//用户基本信息
            string controllerName = Request.RequestContext.RouteData.Values["controller"].ToString();//获取控制器名
            string actionName = Request.RequestContext.RouteData.Values["action"].ToString();//获取action名

            string action = controllerName + "/" + actionName;

            var model = new Sys_logEntity { Content = JsonHelper.ObjectToJSON(LogData), Name = Name, Action = action, Type = Type, AddUserGuId = usermodel.GuId };
            model.Create();
            logbll.Add(model);

            return Json(new { Success = true, Data = Data }, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public object GetUserInfo()
        {
            try
            {
                //验证登录状态
                var token = Utils.GetCookie("token");
                if (string.IsNullOrWhiteSpace(token))
                {
                    return Redirect("/V1.1/Login.html");
                }
                var usermolde = JsonConvert.DeserializeObject<Sys_UserEntity>(DESEncrypt.MD5Decrypt(token, dkey));
                //判断登入是否过期、只有当天时间有效
                if (DateTime.Parse(usermolde.LogTime).ToString("yyyy-MM-dd") != DateTime.Now.ToString("yyyy-MM-dd"))
                {
                    return Redirect("/V1.1/Login.html");
                }
                return usermolde;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}