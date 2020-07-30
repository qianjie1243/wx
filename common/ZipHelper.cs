using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Checksums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ZipHelper
    {
        /// <summary>
        ///  压缩多个文件
        /// </summary>
        /// <param name="files">文件名</param>
        /// <param name="ZipedFileName">压缩包文件名</param>
        /// <param name="Password">解压码</param>
        /// <returns></returns>
        public static void Zip(List<string> files, string ZipedFileName, string Password)
        {
            files = files.Where(f => File.Exists(f)).ToList();
            if (files.Count() == 0) throw new FileNotFoundException("未找到指定打包的文件");
            ZipOutputStream s = new ZipOutputStream(File.Create(ZipedFileName));
            s.SetLevel(6);
            if (!string.IsNullOrEmpty(Password.Trim())) s.Password = Password.Trim();
            ZipFileDictory(files, s);
            s.Finish();
            s.Close();
        }

        /// <summary>
        ///  压缩多个文件
        /// </summary>
        /// <param name="files">文件名</param>
        /// <param name="ZipedFileName">压缩包文件名</param>
        /// <returns></returns>
        public static void Zip(List<string> files, string ZipedFileName)
        {
            Zip(files, ZipedFileName, string.Empty);
        }

        private static void ZipFileDictory(List<string> files, ZipOutputStream s)
        {
            ZipEntry entry = null;
            FileStream fs = null;
            Crc32 crc = new Crc32();
            try
            {
                //创建当前文件夹
                entry = new ZipEntry("/");  //加上 “/” 才会当成是文件夹创建
                s.PutNextEntry(entry);
                s.Flush();
                foreach (string file in files)
                {
                    //打开压缩文件
                    fs = File.OpenRead(file);

                    byte[] buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    entry = new ZipEntry("/" + Path.GetFileName(file));
                    entry.DateTime = DateTime.Now;
                    entry.Size = fs.Length;
                    fs.Close();
                    crc.Reset();
                    crc.Update(buffer);
                    entry.Crc = crc.Value;
                    s.PutNextEntry(entry);
                    s.Write(buffer, 0, buffer.Length);
                }
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                    fs = null;
                }
                if (entry != null)
                    entry = null;
                GC.Collect();
            }
        }

    }
}
