using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxTenpay.WXoperation
{
    /// <summary>
    /// 微信菜单请求返回类
    /// </summary>
   public  class Model
    {
        /// <summary>
        /// 返回视频的id
        /// </summary>
        public string media_id { set; get; }
        /// <summary>
        /// 返回的错误id
        /// </summary>
        public string errcode { set; get; }
        /// <summary>
        /// 返回的错误描述
        /// </summary>
        public string errmsg { set; get; }
    }


    /// <summary>
    /// 图文素材的参数类
    /// </summary>
    public class articles
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string title { set; get; } = "";
        /// <summary>
        /// 图文消息的封面图片素材id（必须是永久mediaID）
        /// </summary>
        public string thumb_media_id { set; get; } = "";
        /// <summary>
        /// 作者
        /// </summary>
        public string author { set; get; } = "";
        /// <summary>
        /// 图文消息的摘要，仅有单图文消息才有摘要，多图文此处为空。如果本字段为没有填写，则默认抓取正文前64个字。
        /// </summary>
        public string digest { set; get; } = "";
        /// <summary>
        /// 是否显示封面，0为false，即不显示，1为true，即显示
        /// </summary>
        public int show_cover_pic { set; get; } = 0;
        /// <summary>
        /// 图文消息的具体内容，支持HTML标签，必须少于2万字符，小于1M，且此处会去除JS,涉及图片url必须来源 "上传图文消息内的图片获取URL"接口获取。外部图片url将被过滤。
        /// </summary>
        public string content { set; get; } = "";
        /// <summary>
        /// 图文消息的原文地址，即点击“阅读原文”后的URL
        /// </summary>
        public string content_source_url { set; get; } = "";
    }

    /// <summary>
    /// 修改图文素材的参数类
    /// </summary>
    public class update_articles {
        /// <summary>
        /// 修改articles的参数类
        /// </summary>
        public articles article { set; get; }
        /// <summary>
        ///要修改的图文消息的id
        /// </summary>
        public string media_id { set; get; }
        /// <summary>
        ///要更新的文章在图文消息中的位置（多图文消息时，此字段才有意义），第一篇为0
        /// </summary>
        public string index { set; get; }
    }

}
