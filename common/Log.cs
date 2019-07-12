using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Log
    {
        // public static string path = HttpContext.Current.Request.PhysicalApplicationPath + "logs";
        public static string path = System.AppDomain.CurrentDomain.BaseDirectory + "Logs/" + DateTime.Now.ToString("yyyy-MM-dd");

        //---------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="name">文件名</param>
        /// <param name="filename">文件夹名称</param>
        public static void WriteLog(string content, string name = "", string filename = "")
        {
            if (!string.IsNullOrWhiteSpace(filename))
            {
                path = System.AppDomain.CurrentDomain.BaseDirectory + filename + "/" + DateTime.Now.ToString("yyyy-MM-dd");
            }

            if (!Directory.Exists(path))//如果日志目录不存在就创建
            {
                Directory.CreateDirectory(path);
            }
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");//获取当前系统时间
            string pathname = "";


            if (string.IsNullOrWhiteSpace(name))
                pathname = path + "/" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";//用日期对日志文件命名
            else
                pathname = path + "/" + name + ".log";//用日期对日志文件命名
                                                      //创建或打开日志文件，向日志文件末尾追加记录
            using (StreamWriter mySw = File.AppendText(filename))
            {
                //向日志文件写入内容
                string write_content = time + "==>" + content + "----------";

                //Byte[] temp = Encoding.UTF8.GetBytes(write_content);
                //string dataGBK = Encoding.GetEncoding("GB2312").GetString(temp);
                mySw.WriteLine(write_content);

                //关闭日志文件
                mySw.Close();
            }
        }


        /// <summary>
        /// 写入日志文件
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="Name"></param>
        /// <param name="filename"></param>
        public static void WriteLogFileObject(object obj, string Name = "", string filename = "")
        {
            var json = JsonHelper.ObjectToJSON(obj);
            WriteLogFile(json, Name, filename);
        }

        /// <summary>
        /// 写入日志文件
        /// </summary>
        /// <param name="content"></param>
        public static void WriteLogFile(string content, string Name = "", string filename = "")
        {

            if (!string.IsNullOrWhiteSpace(filename))
            {
                path = System.AppDomain.CurrentDomain.BaseDirectory + filename + "/" + DateTime.Now.ToString("yyyy-MM-dd");
            }

            if (!Directory.Exists(path))//如果日志目录不存在就创建
            {
                Directory.CreateDirectory(path);
            }

            if (!string.IsNullOrWhiteSpace(Name))
            {
                //指定日志文件的目录
                Name = path + "/" + Name + ".log";
            }
            else
            {
                Name = path + "/" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            }

            if (!File.Exists(Name))
            {
                //不存在文件
                File.Create(Name).Dispose();//创建该文件
            }

            /**/
            ///判断文件是否存在以及是否大于2K
            /* if (finfo.Length > 1024 * 1024 * 10)
            {
            /**/
            //文件超过10MB则重命名
            /* File.Move(fname, Directory.GetCurrentDirectory() + DateTime.Now.TimeOfDay + "\\LogFile.txt");
            //删除该文件
            //finfo.Delete();
            }*/

            using (StreamWriter log = new StreamWriter(Name, true))
            {
                //FileStream fs = new FileStream(url, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);FileMode.Append

                //设置写数据流的起始位置为文件流的末尾
                log.BaseStream.Seek(0, SeekOrigin.End);

                //写入“Log Entry : ”
                log.Write("\n\r====> : ");

                //写入当前系统时间并换行
                log.Write("{0} {1} \n\r", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());

                //写入日志内容并换行
                log.Write("\n\r" + content + "\n\r===END===\n\r");

                //清空缓冲区
                log.Flush();
                //关闭流
                log.Close();
            }
        }

        /// <summary>
        /// 将异常打印到LOG文件
        /// </summary>
        /// <param name="ex">异常</param>
        /// <param name="LogAddress">日志文件名称</param>
        /// <param name="filename">文件夹名称</param>
        /// <param name="ip">访问IP地址</param>
        public static void WriteLogTxt(Exception ex, string LogAddress = "", string filename = "", string ip = "")
        {

            if (!string.IsNullOrWhiteSpace(filename))
            {
                path = System.AppDomain.CurrentDomain.BaseDirectory + filename + "/" + DateTime.Now.ToString("yyyy-MM-dd");
            }

            if (!Directory.Exists(path))//如果日志目录不存在就创建
            {
                Directory.CreateDirectory(path);
            }
            //如果日志文件为空，则默认在Debug目录下新建 YYYY-mm-dd_Log.log文件
            if (!string.IsNullOrWhiteSpace(LogAddress))
            {
                //指定日志文件的目录
                LogAddress = path + "/" + LogAddress + ".log";
            }
            else
            {
                LogAddress = path + "/" + DateTime.Now.ToString("yyyy-MM-dd") + ".log";
            }



            FileInfo finfo = new FileInfo(LogAddress);

            if (!finfo.Exists)
            {
                FileStream fs;
                fs = File.Create(LogAddress);
                fs.Close();
                finfo = new FileInfo(LogAddress);
            }

            //把异常信息输出到文件
            StreamWriter sw = new StreamWriter(LogAddress, true);
            sw.WriteLine("当前时间：" + DateTime.Now.ToString());
            sw.WriteLine("异常信息：" + ex.Message);
            sw.WriteLine("异常对象：" + ex.Source);
            sw.WriteLine("调用堆栈：\n" + ex.StackTrace.Trim());
            sw.WriteLine("触发方法：" + ex.TargetSite);
            sw.WriteLine("访问IP地址：" + ip);
            sw.WriteLine();
            sw.Close();
        }
    }
}
