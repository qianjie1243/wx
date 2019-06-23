using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
namespace WxTenpay.WXoperation.Common
{
    public class MD5Util
    {

        public MD5Util() { 
         //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        /// <summary>
        /// /** 获取大写的MD5签名结果 */
        /// </summary>
        /// <param name="encypStr">数据</param>
        /// <param name="charset">编码格式</param>
        /// <returns></returns>       
        public static string GetMD5(string encypStr, string charset)
        {
            string retStr;
            MD5CryptoServiceProvider m5 = new MD5CryptoServiceProvider();

            //创建md5对象
            byte[] inputBye;
            byte[] outputBye;

            //使用GB2312编码方式把字符串转化为字节数组．
            try
            {
                inputBye = Encoding.GetEncoding(charset).GetBytes(encypStr);
            }
            catch (Exception ex)
            {
                inputBye = Encoding.GetEncoding("GB2312").GetBytes(encypStr);
            }
            outputBye = m5.ComputeHash(inputBye);

            retStr = System.BitConverter.ToString(outputBye);
            retStr = retStr.Replace("-", "").ToUpper();
            return retStr;
        }
        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string sha1(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "sha1").ToLower();
        }
        /// <summary>
        /// SHA1加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns> 
        public static string SHA1(string data)
        {
            byte[] temp1 = Encoding.UTF8.GetBytes(data);

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            byte[] temp2 = sha.ComputeHash(temp1);
            sha.Clear();

            // 注意， 不能用这个
            //string output = Convert.ToBase64String(temp2);

            string output = BitConverter.ToString(temp2);
            output = output.Replace("-", "");
            output = output.ToLower();
            return output;
        }
        /// <summary>
        /// json
        /// </summary>
        /// <returns></returns>
        public static  String toJson(string appId, string timeStamp, string nonceStr, string packageA, string signType, string paySign)
        {
            String json = "{";
            json += "\"appId\":" + "\"" + appId + "\",";
            json += "\"timeStamp\":" + "\"" + timeStamp + "\",";
            json += "\"nonceStr\":" + "\"" + nonceStr + "\",";
            json += "\"package\":" + "\"" + packageA + "\",";
            json += "\"signType\":" + "\"" + signType + "\",";
            json += "\"paySign\":" + "\"" + paySign + "\"";
            json += "}";
            return json;
        }

        /// <summary>
        /// string转utf-8
        /// </summary>
        /// <param name="unicodeString"></param>
        /// <returns></returns>
        public static string get_uft8(string unicodeString)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            Byte[] encodedBytes = utf8.GetBytes(unicodeString);
            String decodedString = utf8.GetString(encodedBytes);
            return decodedString;
        }

    }
}

    
