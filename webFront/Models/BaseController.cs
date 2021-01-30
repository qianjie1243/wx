using Business.Business;
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
        public object ErrorLog(object Data, string Name)
        {
            string controllerName = Request.RequestContext.RouteData.Values["controller"].ToString();//获取控制器名
            string actionName = Request.RequestContext.RouteData.Values["action"].ToString();//获取action名

            string action = controllerName + "/" + actionName;

            var model = new Sys_logEntity { Content = JsonHelper.ObjectToJSON(Data), Name = Name, Action = action, Type = 0 };
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
        /// <returns></returns>
        public object SuccessLog(object Data, object LogData, string Name, int Type)
        {

            string controllerName = Request.RequestContext.RouteData.Values["controller"].ToString();//获取控制器名
            string actionName = Request.RequestContext.RouteData.Values["action"].ToString();//获取action名

            string action = controllerName + "/" + actionName;

            var model = new Sys_logEntity { Content = JsonHelper.ObjectToJSON(LogData), Name = Name, Action = action, Type = Type };
            model.Create();
            logbll.Add(model);

            return Json(new { Success = true, Data = Data }, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Sys_UserEntity GetUserInfo(string token)
        {
            try
            {
                return JsonConvert.DeserializeObject<Sys_UserEntity>(DESEncrypt.MD5Decrypt(token, dkey));
            }
            catch (Exception)
            {
                throw;
            }
            
        }

    }
}