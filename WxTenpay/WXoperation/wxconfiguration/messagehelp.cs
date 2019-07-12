using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Xml;
using System.Text;
using System.IO;
using System.Web.Security;
using System.Web.Script.Serialization;
using WxTenpay.WXoperation.Common;

namespace WxTenpay.WXoperation.wxconfigurateion
{
    /// <summary>
    /// 接受微信端的信息，并处理信息，发送信息
    /// </summary>
    public class messagehelp
    {

        #region 接受来自微信端的信息
        /// <summary>
        /// 接受来自微信端的信息，根据信息内容返回信息
        /// </summary>
        /// <param name="postStr"></param>
        /// <returns></returns>
        public string ReturnMessage(string postStr)
        {
            string responseContent = "";
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(new System.IO.MemoryStream(System.Text.Encoding.GetEncoding("utf-8").GetBytes(postStr)));

            //消息类型，event
            XmlNode MsgType = xmldoc.SelectSingleNode("/xml/MsgType");
            //关注与不关注的字段
            XmlNode Event = xmldoc.SelectSingleNode("/xml/Event");
            if (MsgType != null)
            {
                //关注时推送事件
                if (MsgType.InnerText == "event" && Event.InnerText == "subscribe")
                {

                    responseContent = GuanZhu(xmldoc);
                    return responseContent;
                }
                //取消订阅
                else if (MsgType.InnerText == "event" && Event.InnerText == "unsubscribe")
                {
                    deleteGuanZhu(xmldoc);
                }



                switch (MsgType.InnerText)
                {
                    case "event":
                        //return responseContent;
                        responseContent = EventHandle(xmldoc);//事件处理
                        break;
                    case "text":
                        //return "success";
                        responseContent = TextHandle(xmldoc);//接受文本消息处理
                        break;
                    default:
                        break;
                }
            }
            return responseContent;
        }
        #endregion
        //-------------------------------------

        #region 事件
        /// <summary>
        /// 事件
        /// </summary>
        /// <param name="xmldoc"></param>
        /// <returns></returns>
        public string EventHandle(XmlDocument xmldoc)
        {
            string responseContent = "";
            //事件类型，Event     subscribe(订阅)、unsubscribe(取消订阅)
            XmlNode Event = xmldoc.SelectSingleNode("/xml/Event");
            //事件KEY值，与自定义菜单接口中KEY值对应
            XmlNode EventKey = xmldoc.SelectSingleNode("/xml/EventKey");
            //开发者微信号
            XmlNode ToUserName = xmldoc.SelectSingleNode("/xml/ToUserName");
            //发送方帐号（一个OpenID）
            XmlNode FromUserName = xmldoc.SelectSingleNode("/xml/FromUserName");
            #region 菜单单击事件

            #endregion
            return responseContent;
        }
        #endregion
        //-------------------------------
        #region 接受文本消息
        /// <summary>
        /// 接受文本消息
        /// </summary>
        /// <param name="xmldoc"></param>
        /// <returns></returns>
        public string TextHandle(XmlDocument xmldoc)
        {


            // string responsecontent = "";
            XmlNode ToUserName = xmldoc.SelectSingleNode("/xml/ToUserName");
            XmlNode FromUserName = xmldoc.SelectSingleNode("/xml/FromUserName");
            XmlNode Content = xmldoc.SelectSingleNode("/xml/Content");
            //if (Content != null)
            //{
            //    if (Content.InnerText == "qq")
            //    {
            //        responsecontent = string.Format(
            //   ReplyType.Message_Text,
            //    FromUserName.InnerText,
            //   ToUserName.InnerText,
            //   DateTime.Now.Ticks,
            //    "你好！："
            //   );
            //    }
            //    else
            //    {
            //    responsecontent = string.Format(
            //             ReplyType.Message_Text,
            //                FromUserName.InnerText,
            //                ToUserName.InnerText,
            //                DateTime.Now.Ticks,
            //                "success"
            //                 ); 
            return "success";
            //}
            // }
            //return responsecontent;
        }
        #endregion
        //-----------------------
        #region 关注后的推送事件
        /// <summary>
        /// 关注后的推送事件
        /// </summary>
        /// <param name="xmldoc"></param>
        /// <returns></returns>
        //关注后的推送事件
        public string GuanZhu(XmlDocument xmldoc)
        {

            string responsecontent = "";
            //开发者微信号
            XmlNode ToUserName = xmldoc.SelectSingleNode("/xml/ToUserName");
            //openid
            XmlNode FromUserName = xmldoc.SelectSingleNode("/xml/FromUserName");
            responsecontent = string.Format(
                  ReplyType.Message_Text,
                   FromUserName.InnerText,
                  ToUserName.InnerText,
                  DateTime.Now.Ticks,
                  "你好!谢谢你的关注!\r\n(●'◡'●)ﾉ♥~(●'◡'●)ﾉ♥~"
                  );

            return responsecontent;
        }
        #endregion
        //-----------------------
        #region 取消关注后的事件
        /// <summary>
        ///  取消关注后的事件
        /// </summary>
        /// <param name="xmldoc"></param>
        public void deleteGuanZhu(XmlDocument xmldoc)
        {
            //FromUserName 取消关注的openid
            XmlNode FromUserName = xmldoc.SelectSingleNode("/xml/FromUserName");
        }
        #endregion
        //-----------------------
        #region 文本消息类型
        /// <summary>
        /// 文本消息类型
        /// </summary>
        public class ReplyType
        {
            /// <summary>
            /// 普通文本消息
            /// ToUserName  接受方openid
            /// FromUserName  开发者微信号
            /// CreateTime  消息创建时间
            /// MsgType  text  是数据类型
            /// Content  数据内容
            /// </summary>
            public static string Message_Text
            {
                get
                {
                    return @"<xml>
                            <ToUserName><![CDATA[{0}]]></ToUserName>
                            <FromUserName><![CDATA[{1}]]></FromUserName>
                            <CreateTime>{2}</CreateTime>
                            <MsgType><![CDATA[text]]></MsgType>
                            <Content><![CDATA[{3}]]></Content>
                           </xml>";
                }
            }
            /// <summary>
            /// 图文消息主体
            /// ToUserName  接受方openid
            /// FromUserName  开发者微信号
            /// CreateTime  消息创建时间
            /// MsgType   news
            /// ArticleCount  在Articles中的个数不能超过8个
            /// Articles  添加item
            /// </summary>
            public static string Message_News_Main
            {
                get
                {
                    return @"<xml>
                            <ToUserName><![CDATA[{0}]]></ToUserName>
                            <FromUserName><![CDATA[{1}]]></FromUserName>
                            <CreateTime>{2}</CreateTime>
                            <MsgType><![CDATA[news]]></MsgType>
                            <ArticleCount>{3}</ArticleCount>
                            <Articles>
                            {4}
                            </Articles>
                            </xml> ";
                }
            }
            /// <summary>
            /// 图片消息
            /// ToUserName	是	接收方帐号（收到的OpenID）
            ///FromUserName	是	开发者微信号
            ///CreateTime	是	消息创建时间 （整型）
            ///MsgType	是	image
            ///MediaId	是	通过上传多媒体文件，得到的id。
            /// </summary>
            public static string Message_image
            {
                get
                {
                    return @"<xml>
                <ToUserName><![CDATA[{0}]]></ToUserName>
                FromUserName><![CDATA[{1}]]></FromUserName>
                <CreateTime>{2}</CreateTime>
                <MsgType><![CDATA[image]]></MsgType>
                <Image>
                <MediaId><![CDATA[{3}]]></MediaId>
                </Image>
                </xml>";
                }
            }


            /// <summary>
            /// 图文消息项
            /// url   跳转链接
            /// PicUrl 图片链接
            /// title 标题
            /// Description 摘要
            /// </summary>
            public static string Message_News_Item
            {
                get
                {
                    return @"<item>
                            <Title><![CDATA[{0}]]></Title> 
                            <Description><![CDATA[{1}]]></Description>
                            <PicUrl><![CDATA[{2}]]></PicUrl>
                            <Url><![CDATA[{3}]]></Url>
                            </item>";
                }
            }
            /// <summary>
            /// 语音消息
            /// ToUserName	是	接收方帐号（收到的OpenID）
            ///FromUserName	是	开发者微信号
            ///CreateTime	是	消息创建时间戳 （整型）
            ///MsgType	    是	语音，voice
            ///MediaId   	是	通过素材管理中的接口上传多媒体文件，得到的id
            /// </summary>
            public static string Message_voice
            {
                get
                {
                    return @"<xml>
                <ToUserName><![CDATA[{0}]]></ToUserName>
                <FromUserName><![CDATA[{1}]]></FromUserName>
                <CreateTime>{2}</CreateTime>
                <MsgType><![CDATA[voice]]></MsgType>
                    <Voice>
                <MediaId><![CDATA[{3}]]></MediaId>
                    </Voice>
                    </xml>";
                }
            }

            /// <summary>
            /// 音乐消息
            /// ToUserName	是	接收方帐号（收到的OpenID）
            /// FromUserName 是	开发者微信号
            ///CreateTime	是	消息创建时间 （整型）
            ///MsgType	    是	music
            ///Title	    否	音乐标题
            ///Description	否	音乐描述
            ///MusicURL	    否	音乐链接
            ///HQMusicUrl	否	高质量音乐链接，WIFI环境优先使用该链接播放音乐
            ///ThumbMediaId	是	缩略图的媒体id，通过素材管理中的接口上传多媒体文件，得到的id
            /// </summary>
            public static string Message_music
            {
                get
                {
                    return @"<xml>
                <ToUserName><![CDATA[{0}]]></ToUserName>
                <FromUserName><![CDATA[{1}]]></FromUserName>
                <CreateTime>{2}</CreateTime>
                <MsgType><![CDATA[music]]></MsgType>
                <Music>
                <Title><![CDATA[{3}]]></Title>
                <Description><![CDATA[{4}]]></Description>
                <MusicUrl><![CDATA[{5}]]></MusicUrl>
                <HQMusicUrl><![CDATA[{6}]]></HQMusicUrl>
                <ThumbMediaId><![CDATA[{7}]]></ThumbMediaId>
                </Music>
                </xml>";
                }
            }
            /// <summary>
            /// 视频消息
            /// ToUserName	是	接收方帐号（收到的OpenID）
            /// FromUserName 是	开发者微信号
            ///CreateTime	是	消息创建时间 （整型）
            ///MsgType	    是	Video
            ///Title	    否	视频标题
            ///Description	否	视频描述
            ///MusicURL	    否	视频链接
            ///HQMusicUrl	否	高质量视频链接，WIFI环境优先使用该链接播放音乐
            ///ThumbMediaId	是	缩略图的媒体id，通过素材管理中的接口上传多媒体文件，得到的id
            /// </summary>
            public static string Message_Video
            {
                get
                {
                    return @"<xml>
                    <ToUserName><![CDATA[{0}]]></ToUserName>
                    <FromUserName><![CDATA[{1}]]></FromUserName>
                    <CreateTime>{2}</CreateTime>
                    <MsgType><![CDATA[video]]></MsgType>
                    <Video>
                    <MediaId><![CDATA[{3}]]></MediaId>
                    <Title><![CDATA[{4}]]></Title>
                    <Description><![CDATA[{5}]]></Description>
                    </Video> 
                    </xml>";
                }

            }

        }
        #endregion

        #region 微信端主动发送信息给客户

        /// <summary>
        /// 微信端主动发送信息给客户
        /// </summary>
        /// <param name="openid">openid</param>
        /// <param name="text">发送的信息</param>
        /// <param name="token">微信的token</param>
        /// <returns></returns>
        public erroy FaSongXingXi(string openid, string text, string token)
        {
            try
            {
                string menu = "{\"touser\":\"openid\",\"msgtype\":\"text\",\"text\":{\"content\":\"txt\"}}";
                menu = menu.Replace("openid", openid).Replace("txt", text);
                var json1 = HttpRequestutil.RequestUrl("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token=" + token, menu, "post");
                JavaScriptSerializer js = new JavaScriptSerializer();
                Log.WriteLogFile(json1, "微信客户消息");
                return js.Deserialize<erroy>(json1);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region 微信端主动发送信息给客户(模板消息)

        /// <summary>
        /// 微信端主动发送信息给客户(模板消息)
        /// </summary>
        /// <param name="openid">openid</param>
        /// <param name="shuju_data">发送的信息</param>
        /// <param name="template_id">模板ID</param>
        /// <param name="token">微信的token</param>
        /// <param name="url">点击的url</param>
        /// <returns></returns>
        public string Template(string openid, string template_id, string shuju_data, string token, string url)
        {
            try
            {
                string menu = "{\"touser\":\"openid\",\"template_id\":\"tem_id_name\",\"url\":\"to_url\",\"data\":shuju_data}";
                menu = menu.Replace("openid", openid).Replace("tem_id_name", template_id).Replace("shuju_data", shuju_data).Replace("to_url", url);
                return HttpRequestutil.RequestUrl("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token=" + token, menu, "post");

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

    }
}