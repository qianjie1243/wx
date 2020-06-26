using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;

namespace  Common
{
  public   class QRCode
    {
        #region 生成二维码
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">路劲/update/二维码/</param>
        /// <param name="number">435435435</param>
        /// <param name="pathName">138818732</param>
        /// <returns></returns>
        public  string SetQRCode(string path, string  number, string pathName)
        {

            //初始化二维码生成工具
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            qrCodeEncoder.QRCodeVersion = 0;
            qrCodeEncoder.QRCodeScale = 4;
            string str = number;
            //将字符串生成二维码图片
            Bitmap image = qrCodeEncoder.Encode(str);
            string paths = GetPath(pathName, path);
            image.Save(paths, ImageFormat.Jpeg);
            //输出二维码图片路劲
            return paths;
        }

        #endregion



        /// <summary>
        /// 生成随机数
        /// </summary>
        /// <returns></returns>
        public string get_number()
        {
            string str = Utils.Number(10);
            //get_number();
            return str;
        }

        #region 保存图片地址
        /// <summary>
        /// 保存图片地址
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string GetPath(string fileName, string path)
        {
            //string path = string.Empty;
            //path = "/upload/二维码/";
            path = HttpContext.Current.Server.MapPath(path);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += fileName + ".jpg";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            return path;
        }
        #endregion

        #region 保存图片地址
        /// <summary>
        /// 保存图片地址
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool GetPath( string path)
        {
            //string path = string.Empty;
            //path = "/upload/二维码/";
            path = HttpContext.Current.Server.MapPath(path);
            if (!File.Exists(path))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region 解析二维码
        /// <summary>
        /// 解析二维码
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <returns></returns>

        public string getQRCode(string path)
        {
            string decodedString = "";
            if (GetPath(path))
            {
                path= HttpContext.Current.Server.MapPath(path);                        
                Bitmap bmp = new Bitmap(path);
                QRCodeDecoder decoder = new QRCodeDecoder();
                try
                {
                    decodedString = decoder.decode(new QRCodeBitmapImage(new Bitmap(bmp)));
                }
                catch (Exception )
                {
                    return "";
                }
            }
            return decodedString;
        }
        #endregion
    }
}
