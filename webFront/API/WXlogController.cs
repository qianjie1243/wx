using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using webFront.Models;

namespace webFront.API
{

    /// <summary>
    /// 接口文档
    /// </summary>
    public class WXlogController : BaseController
    {

        /// <summary>
        /// 获取日志目录
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetLog(string pathname = "")
        {
            try
            {
                List<dynamic> lis = new List<dynamic>();
                if (string.IsNullOrWhiteSpace(pathname))
                {
                    pathname = System.AppDomain.CurrentDomain.BaseDirectory + "Logs";
                }
                if (!Directory.Exists(pathname))//如果日志目录不存在就创建
                {
                    Directory.CreateDirectory(pathname);
                }
                DirectoryInfo root = new DirectoryInfo(pathname);
                FileInfo[] files = root.GetFiles();
             

                    foreach (var f in files)
                    {
                        lis.Add(new { name = f.Name, path = f.FullName });
                    }
            
                    var paths = Directory.GetDirectories(pathname);
                    foreach (var item in paths)
                    {
                        var name = item.Substring(item.LastIndexOf('\\') + 1);
                        lis.Add(new { name, path = item });
                    }
                
                return Success(lis);
            }
            catch (Exception ex)
            {
                return Error(ex.ToString());
            }

        }

        /// <summary>
        ///    获取日志详细
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetDetails(string pathname)
        {
            try
            {
                if (!System.IO.File.Exists(pathname))//如果日志目录不存在就创建
                {
                    return Error("文件不存在");
                }
                byte[] mybyte = Encoding.UTF8.GetBytes(System.IO.File.ReadAllText(pathname));
                var data  = Encoding.UTF8.GetString(mybyte).Replace("\n\r====> :", "").Replace("\n\r===END===\n\r", "----").Replace("\n\r\n\r", "=====");
               // StreamReader st = new StreamReader(pathname,Encoding.Default);
                //var data = st.ReadLine();
                return Success(data);
            }
            catch (Exception ex)
            {
                return Error(ex.ToString());
            }

        }
    }
}