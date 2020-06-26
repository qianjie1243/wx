using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;


namespace BaiDuAI.SERVICE
{
    /// <summary>
    /// 获取AccessToken
    /// </summary>
    public class AccessToken
    {
        /// <summary>
        /// 
        /// </summary>
        private static string access_token { set; get; }

        /// <summary>
        /// 时间
        /// </summary>
        private static DateTime time { set; get; }

        /// <summary>
        /// 有效时间
        /// </summary>
        private static int expires_in = 0;
        /// <summary>
        /// 获取access_token请求地址
        /// </summary>
        private const string url = "https://aip.baidubce.com/oauth/2.0/token";

        /// <summary>
        /// 获取getAccessToken
        /// </summary>
        /// <returns></returns>
        public static string getAccessToken(string AK, string SK)
        {
            if (string.IsNullOrEmpty(access_token))
            {
                getAccess(AK,SK);
            }
            else
            {
                var timedata = DateTime.Now;
                if ((timedata - time).TotalSeconds > (expires_in - 100))
                {
                    getAccess(AK, SK);
                }
            }
            return access_token;
        }

        /// <summary>
        /// 获取getAccessToken,默认配置参数
        /// </summary>
        /// <returns></returns>
        public static string getAccessToken()
        {
            if (string.IsNullOrEmpty(access_token))
            {
                getAccess(BaiDuConfig.AK, BaiDuConfig.SK);
            }
            else
            {
                var timedata = DateTime.Now;
                if ((timedata - time).TotalSeconds > (expires_in - 100))
                {
                    getAccess(BaiDuConfig.AK, BaiDuConfig.SK);
                }
            }
            return access_token;
        }
        /// <summary>
        /// 获取Access
        /// </summary>
        private static void getAccess(string AK, string SK)
        {
            try
            {
                NameValueCollection nv = new NameValueCollection();
                nv.Add("grant_type", "client_credentials");
                nv.Add("client_id", AK);
                nv.Add("client_secret", SK);
                var result = Utils.PostFromToUrl(url, nv);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                if (jo["access_token"] == null)
                {
                    Log.WriteLogFile("百度AI--获取access_token==>错误码：" + jo["error"].ToString() + ",错误描述：" + jo["error_description"].ToString(), "百度AI");
                }
                else
                {
                    time = DateTime.Now;
                    access_token = jo["access_token"].ToString();
                    expires_in = int.Parse(jo["expires_in"].ToString());
                }

            }
            catch (Exception )
            {
                throw;
            }
        }


    }
}
