
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using WxTenpay.wxconfig;
using WxTenpay.wxconfig.wxtenpay;

namespace WxTenpay
{
    [Description("微信基本操作类")]
    /// <summary>
    /// 微信基本操作类
    /// </summary>
    public class WechatPublic
    {

        #region  ===
        /// <summary>
        /// 保存凭证
        /// </summary>
        [Description("Asscess凭证")]
        private  string Asscess { set; get; }
        /// <summary>
        /// jsp_api 签名参数
        /// </summary>
        [Description("jsp_api 签名参数")]
        private  string jsapi_ticket{set;get;}
        /// <summary>
        /// 保存凭证时间
        /// </summary>
        private  DateTime Asscess_Time { set; get; }
        /// <summary>
        /// 保存jsp_api时间
        /// </summary>
        private  DateTime Jsp_Api_Time { set; get; }

        #endregion

        #region code获取个人信息,openid====(已测试)


        /// <summary>
        /// code获取个人信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [Description("code获取个人信息")]
        public gerenxinxi GetPersonal(string code)
      {
          gerenxinxi xx = new gerenxinxi();
            Getopenid getopenid = asscess_token.shouquangerenxinxi(code);

            if (asscess_token.pandunaccess_token(getopenid.access_token, getopenid.openid).errcode == "0")
            {
                xx = asscess_token.gerenxinxi(getopenid.access_token, getopenid.openid);

            }
            else {
                getopenid = asscess_token.ShuaXinaccess_token(WXconfig.appid, getopenid.refresh_token);
             xx = asscess_token.gerenxinxi(getopenid.access_token, getopenid.openid);
            }
            return xx;
      }

        /// <summary>
        /// 返回openid
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [Description("返回openid")]
        public string  GetOpenid(string code)
        {
            gerenxinxi xx = new gerenxinxi();
            Getopenid openid = asscess_token.shouquangerenxinxi(code);
            return openid.openid;
        }

        #endregion

        #region 获取前端JS所需WX.config====(已测试)
        /// <summary>
        /// 获取config
        /// </summary>
        /// <returns></returns>
        [Description("获取config")]
        public string GetWxConfig(string url)
      {
            string nonceStr = TenpayUtil.getNoncestr();
            string timeStamp = TenpayUtil.getTimestamp();
            string JsapiTicket= GetJsapi_ticket();
            string string1 = "jsapi_ticket=" + JsapiTicket + "&noncestr=" + nonceStr + "&timestamp=" + timeStamp + "&url="+url;
            string signature = MD5Util.sha1(string1);
            string config = "{";
            config += "\"appId\":" + "\"" + WXconfig.appid+ "\",";
            config += "\"timeStamp\":" + "\"" + timeStamp + "\",";
            config += "\"nonceStr\":" + "\"" + nonceStr + "\",";
            config += "\"signature\":" + "\"" + signature + "\"";
            config += "}";
            return config;
      }


        #region 获取Asscess,jsapi_ticket
        /// <summary>
        /// 获取access_token
        /// </summary>
        /// <returns></returns>
        [Description("获取access_token")]
        public  string GetToken() {

          if (Asscess == null)
          {
              string token = asscess_token.GetToken(WXconfig.appid, WXconfig.secret);
              Asscess = token;
              Asscess_Time = DateTime.Now;
          }
          else
          {
              DateTime time = DateTime.Now;

              if ((time - Asscess_Time).TotalSeconds > 7000)
              {
                  string token = asscess_token.GetToken(WXconfig.appid, WXconfig.secret);
                  Asscess = token;
                  Asscess_Time = DateTime.Now;
              }
          }
          return Asscess;
      
      }


        /// <summary>
        /// jsapi_ticket
        /// </summary>
        /// <returns></returns>
        [Description("jsapi_ticket")]
        public string GetJsapi_ticket()
        {

            if (jsapi_ticket == null)
            {
                jsapi_ticket = asscess_token.getjsapi_ticket(GetToken());
                Jsp_Api_Time = DateTime.Now;
            }
            else
            {
                DateTime time = DateTime.Now;
                if ((time - Jsp_Api_Time).TotalSeconds > 7000)
                {
                    jsapi_ticket = asscess_token.getjsapi_ticket(GetToken());
                    Jsp_Api_Time = DateTime.Now;
                }

            }
            return jsapi_ticket;
        }
        #endregion

        #endregion

        #region 客户消息====(已测试)
        /// <summary>
        /// 微信客户消息
        /// </summary>
        /// <param name="openid">用户的openid</param>
        /// <param name="text">发送消息内容</param>
        /// <returns></returns>
        [Description("微信客户最基本消息")]
        public string WeiXinKeFu(string openid,string text) {
            messagehelp mp = new messagehelp();
            string  result =mp.FaSongXingXi(openid, text, GetToken());
            return result;

        }
        #endregion

        #region 发送微信模板消息====(已测试)
        /// <summary>
        /// 发送微信模板消息
        /// </summary>
        /// <param name="openid">openid</param>
        /// <param name="shuju_data">模板信息内容</param>
        /// <param name="template_id">模板ID</param>
        /// <param name="url">点击的url</param>
        /// <returns></returns>
        [Description("发送微信模板消息")]
        public string WeiXinTemplate(string openid, string template_id, string shuju_data, string url)
        {
            Dictionary<string, object> diy = new Dictionary<string, object>();
            messagehelp mp = new messagehelp();
            string result = mp.Template(openid, template_id, shuju_data, GetToken(),url);
            return result;

        }
        #endregion

        #region 微信配置URL对接====(已测试)

        [Description("微信配置URL对接")]
        public void wx(string token)
        {
            InterfaceTest(token);

            string poststring = string.Empty;
            try
            {
                // 接受来自微信的信息
                if (System.Web.HttpContext.Current.Request.HttpMethod.ToUpper() == "POST")
                {
                    using (Stream stream = System.Web.HttpContext.Current.Request.InputStream)
                    {
                        byte[] postbyte = new byte[stream.Length];
                        stream.Read(postbyte, 0, (Int32)stream.Length);
                        poststring = Encoding.UTF8.GetString(postbyte);
                        Handle(poststring);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 微信公众号url对接
        /// </summary>
        [Description("微信公众号url对接")]
        public void InterfaceTest(string token1)
        {
            //string token = token1;
            if (string.IsNullOrEmpty(token1))
            {
                return;
            }

            string echoString = System.Web.HttpContext.Current.Request.QueryString["echoStr"];
            string signature = System.Web.HttpContext.Current.Request.QueryString["signature"];
            string timestamp = System.Web.HttpContext.Current.Request.QueryString["timestamp"];
            string nonce = System.Web.HttpContext.Current.Request.QueryString["nonce"];

            if (!string.IsNullOrEmpty(echoString))
            {
                System.Web.HttpContext.Current.Response.Write(echoString);
                System.Web.HttpContext.Current.Response.End();
            }
        }
        /// <summary>
        /// 处理信息并应答
        /// </summary>
        /// <param name="poststr"></param>
        [Description("处理信息并应答")]
        public void Handle(string poststr)
        {
            messagehelp help = new messagehelp();
            string responseContent = help.ReturnMessage(poststr);
            //System.Web.HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
            System.Web.HttpContext.Current.Response.Write(responseContent);
            System.Web.HttpContext.Current.Response.End();
        }
        //-----------------------------------------
        #endregion

        #region 微信头像下载====(已测试)
        /// <summary>
        /// 微信头像下载
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="path">保存头像图片地址已/结尾</param>
        /// <param name="Name">保存头像图片名称</param>

        /// <returns></returns>
        [Description("serverId微信头像下载")]
        public string Head_portrait(string serverId,string path,string Name) {

            string access_token = GetToken();
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}", access_token, serverId);        
            return Download_Image(url,Name,path );                  
        }

        #region 下载微信头像

        /// <summary>
        /// 下载微信头像
        /// </summary>
        /// <param name="url">头像地址</param>
        /// <param name="Name">保存头像图片名称</param>
        /// <param name="path">保存头像图片地址已/结尾</param>
        [Description("url=头像地址 下载微信头像")]
        public string  Download_Image(string url, string Name,string path)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream reader = response.GetResponseStream();
                string paths = GetPath(path, Name);
                FileStream writer = new FileStream(paths, FileMode.OpenOrCreate, FileAccess.Write);
                byte[] buff = new byte[512];
                int c = 0; //实际读取的字节数
                while ((c = reader.Read(buff, 0, buff.Length)) > 0)
                {
                    writer.Write(buff, 0, c);
                }
                writer.Close();
                writer.Dispose();
                reader.Close();
                reader.Dispose();
                response.Close();
                return ToJson(new ResponseMessage { Code = 1, Tag =(path+Name) });            
            }
            catch (Exception ex) {
                return ToJson(new ResponseMessage { Code = 2, Message = ex.Message });
                //return ex.Message;
            }
        }
        /// <summary>
        /// 保存图片地址
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string GetPath(string path,string fileName)
        {      
            path = HttpContext.Current.Server.MapPath(path);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            path += fileName;
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            return path;
        }
        #endregion

        /// <summary>
        /// 根据openid头像下载
        /// </summary>
        /// <param name="serverId"></param>
        /// <param name="path">保存头像图片地址已/结尾</param>
        /// <param name="Name">保存头像图片名称</param>

        /// <returns></returns>
        [Description("根据openid头像下载")]
        public string OpenidGetHead(string openid, string path, string Name)
        {

            string access_token = GetToken();
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN", GetToken(), openid);//获取用户个人信息
            string result = HttpRequestutil.RequestUrl(url, "get");
            JavaScriptSerializer json = new JavaScriptSerializer();
            Dictionary<string, object> diy = json.Deserialize<Dictionary<string, object>>(result);
            if (diy["headimgurl"] != null && diy["headimgurl"].ToString() != "")
            {
                return Download_Image(diy["headimgurl"].ToString(), Name, path);
            }
            else {
                return ToJson(new ResponseMessage { Code = 2, Message = "异常" });
            }
           
        }

        #endregion

        #region obj=>json
        private string ToJson(object obj)
        {
            JavaScriptSerializer json = new JavaScriptSerializer();
            string reslut = json.Serialize(obj);
            return reslut;
        }
        #endregion

    }

    #region 模板消息的实体类
    [Description("模板消息的实体类")]
    public class Templatetext {
        /// <summary>
        /// 说明
        /// </summary>
        public string value { set; get; }
        /// <summary>
        /// 字体颜色
        /// </summary>
        public string color { set; get; }

    }
    #endregion

    #region 返回类

    /// <summary>
    /// 返回类
    /// </summary>
    class ResponseMessage
    {
      
        /// <summary>
        /// 1.成功。2.失败
        /// </summary>
        public int Code { set; get; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Message { set; get; }
        /// <summary>
        /// 附加信息
        /// </summary>
        public string Tag { set; get; }
        /// <summary>
        /// 附加信息1
        /// </summary>
        public string Tag1 { set; get; }
    }
    #endregion
}
