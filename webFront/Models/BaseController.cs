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
        public object Error(object Data, string fileName)
        {
            return Json(new { Success = false, Data = Data }, JsonRequestBehavior.AllowGet);
        }
    }
}