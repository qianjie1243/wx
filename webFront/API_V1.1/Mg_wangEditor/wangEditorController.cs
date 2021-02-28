using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webFront.Models;

namespace webFront.API_V1._1
{

    /// <summary>
    /// wangeditor编辑器接收数据
    /// </summary>
    public class wangEditorController : BaseController
    {
        private string personpath = "/file/wangeditor";

        #region 接收编辑器图片接口
        /// <summary>
        /// 接收图片接口
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        public object updateimages()
        {
            try
            {

                var files = System.Web.HttpContext.Current.Request.Files;//获取图片文件
                if (files != null && files.Count > 0)
                {
                    if (files["mg_images"].ContentLength > 0)
                    {
                        var pathfile = Common.Thumbnail.UploadFile(files["mg_images"], personpath + "/images/" + DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMddHHmmss"));
                        if (string.IsNullOrWhiteSpace(pathfile))
                        {
                            var error = new
                            {
                                errno = "文件异常，请重新上传文件！",
                                data = new List<object>(),

                            };
                            return Json(error);
                        }
                        var data = new
                        {
                            errno = 0,
                            data = new List<object>() {
                            new {
                            url= pathfile,
                            alt="",
                            href= ""
                               },
                            },
                        };
                        return Json(data);
                    }
                }
                var errordata = new
                {
                    errno = "文件异常，请重新上传文件！",
                    data = new List<object>(),

                };
                return Json(errordata);
            }
            catch (Exception ex)
            {
                var errordata = new
                {
                    errno = ex.ToString(),
                    data = new List<object>(),
                };
                return Json(errordata);
            }
        }
        #endregion

        #region 接收编辑器视频接口
        /// <summary>
        /// 视频接口
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpPost]
        public object updatevideo()
        {
            try
            {

                var files = System.Web.HttpContext.Current.Request.Files;//获取文件
                if (files != null && files.Count > 0)
                {
                    if (files["mg_video"].ContentLength > 0)
                    {
                        var pathfile = Common.Thumbnail.UploadFile(files["mg_video"], personpath + "/video/" + DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMddHHmmss"));
                        if (string.IsNullOrWhiteSpace(pathfile))
                        {
                            var error = new
                            {
                                errno = "文件异常，请重新上传文件！",
                                data = new List<object>(),
                            };
                            return Json(error);
                        }
                        var data = new
                        {
                            errno = 0,
                            data =new  { url = pathfile },
                        };
                        return Json(data);
                    }
                }
                var errordata = new
                {
                    errno = "文件异常，请重新上传文件！",
                    data = new List<object>(),

                };
                return Json(errordata);
            }
            catch (Exception ex)
            {
                var errordata = new
                {
                    errno = ex.ToString(),
                    data = new List<object>(),
                };
                return Json(errordata);
            }
        }
        #endregion
    }
}