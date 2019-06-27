using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

using WxTenpay.WXoperation.Common;

namespace WxTenpay.WXoperation
{
    /// <summary>
    /// 授权网站登入获取个人信息
    /// </summary>
    public class asscess_token
    {
        #region 授权登入获取个人信息
        /// <summary>
        /// 授权登入获取个人信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public static gerenxinxi gerenxinxi(string token, string openid)
        {
            var url = "https://api.weixin.qq.com/sns/userinfo?access_token=" + token + "&openid=" + openid + "&lang=zh_CN ";          
            var json1 = HttpRequestutil.RequestUrlget(url);
            JavaScriptSerializer js = new JavaScriptSerializer();
            gerenxinxi geren = js.Deserialize<gerenxinxi>(json1);
            return geren;
        }
        /// <summary>
        /// 使用code获取openid,access_token(网页的access_token)
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static Getopenid shouquangerenxinxi(string code)
        {
            string url = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + WXconfig.appid + "&secret=" + WXconfig.secret + "&code=" + code + "&grant_type=authorization_code ";
            var json1 = HttpRequestutil.RequestUrlget(url);
            JavaScriptSerializer json = new JavaScriptSerializer();
            Getopenid getopenid = json.Deserialize<Getopenid>(json1);
            return getopenid;
        }
        /// <summary>
        /// 检验授权凭证（access_token）是否有效
        /// </summary>
        /// <param name="token"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        public static erroy pandunaccess_token(string token, string openid)
        {
            var url = "https://api.weixin.qq.com/sns/auth?access_token=" + token + "&openid=" + openid;
            var json1 = HttpRequestutil.RequestUrlget(url);
            JavaScriptSerializer json = new JavaScriptSerializer();
            erroy err = json.Deserialize<erroy>(json1);
            return err;
        }
        /// <summary>
        /// 刷新网页access_token
        /// </summary>
        /// <param name="token"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        public static Getopenid ShuaXinaccess_token(string appid, string refresh_token)
        {
            var url = "https://api.weixin.qq.com/sns/oauth2/refresh_token?appid=" + appid + "&grant_type=refresh_token&refresh_token=" + refresh_token;
            var json1 = HttpRequestutil.RequestUrlget(url);
            JavaScriptSerializer json = new JavaScriptSerializer();
            Getopenid err = json.Deserialize<Getopenid>(json1);
            return err;
        }
        #endregion

        #region 微信公众号的Token
        #region 获取Token
        /// <summary>
        /// 获取Token
        /// </summary>
        public static string GetToken(string appid, string secret)
        {
            var strJson = HttpRequestutil.RequestUrl(string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", appid, secret), "get");
            Log.WriteLogFile(strJson, "GetToken");
            JavaScriptSerializer json = new JavaScriptSerializer();
            token tk = json.Deserialize<token>(strJson);
            return tk.access_token;
        }
        #endregion

        /// <summary>
        /// 获取jsapi_ticket
        /// </summary>
        /// <returns></returns>
        public static string getjsapi_ticket(string Asscess)
        {
            var strJson = HttpRequestutil.RequestUrl(string.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi", Asscess), "get");        
            JavaScriptSerializer json = new JavaScriptSerializer();
            token tk = json.Deserialize<token>(strJson);
            return tk.ticket;
        }
        #endregion
    }
}