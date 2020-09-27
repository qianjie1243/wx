using Business.Business;
using Common;
using Model;
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
            return Json(new { Success = true, Data =new object() { } }, JsonRequestBehavior.AllowGet);
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
            logbll.Add(new Sys_logEntity { Content= JsonHelper.ObjectToJSON(Data), Name= Name });

            return Json(new { Success = false, Data = "系统异常" }, JsonRequestBehavior.AllowGet);
        }
    }
}