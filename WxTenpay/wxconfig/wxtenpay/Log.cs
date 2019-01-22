


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.IO;
using System.Text;

namespace WxTenpay.wxconfig.wxtenpay
{ 
    public static class Log
    {
        // public static string path = HttpContext.Current.Request.PhysicalApplicationPath + "logs";
        public static string path = System.AppDomain.CurrentDomain.BaseDirectory + "logs/" + DateTime.Now.ToString("yyyy-MM-dd");
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="text"></param>
        public static void WriteLog(string text)
        {

           StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath("./text") + "\\log.txt", true,Encoding.Default);
            //StreamWriter sw = new StreamWriter(path, true);
            text = " 时间：" + DateTime.Now + text;
            sw.WriteLine(text);
            sw.Close();//写入
        }

        //---------------
        public  static void WriteLog1( string content,string name="")
        {
            if (!Directory.Exists(path))//如果日志目录不存在就创建
            {
                Directory.CreateDirectory(path);
            }
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");//获取当前系统时间
            string filename = "";
            if (name=="")
             filename = path + "/" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";//用日期对日志文件命名
            else
             filename = path + "/" +name+ DateTime.Now.ToString("yyyy-MM-dd") + ".txt";//用日期对日志文件命名
            //创建或打开日志文件，向日志文件末尾追加记录
            StreamWriter mySw =  File.AppendText(filename);
            //向日志文件写入内容
            string write_content = time+"==>"+ content + "----------";

            //Byte[] temp = Encoding.UTF8.GetBytes(write_content);
            //string dataGBK = Encoding.GetEncoding("GB2312").GetString(temp);
            mySw.WriteLine(write_content);

            //关闭日志文件
            mySw.Close();
        }
    }
}


    

