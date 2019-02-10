using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using WxTenpay.wxconfig;

namespace WxTenpay.wxconfig.wxconfiguration
{
    /// <summary>
    /// 微信自定义菜单
    /// </summary>
    [Serializable]
    public class wxmenu
    {

        #region  上传素材=========================（新增接口）

        #region 上传图文素材===================（新增接口）
        /// <summary>
        /// 上传图文素材
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="content">上传的图文JSON字符串</param>
        /// <returns></returns>
        public string graphic(string access_token,string content)
        {
            return HttpRequestutil.RequestUrl(string.Format("https://api.weixin.qq.com/cgi-bin/material/add_news?access_token={0}", access_token), content, "post");
        }
        #endregion

        #region 上传图片,语音，缩略图===========（新增接口）
        /// <summary>
        /// 上传图片,语音，缩略图
        /// </summary>
        /// <param name="path">绝对图片路径</param>
        /// <param name="type">类型 image 图片类型,   thumb 缩略图, voice 语音</param>
        public string   material(string path,string access_token,string type)
        {
            string url = "https://api.weixin.qq.com/cgi-bin/material/add_material?access_token="+ access_token + "&type="+ type;
            return HttpRequestutil.HttpUploadFile(url, path);
        }
        #endregion

        #region 视频上传到微信公众号=====================(新增接口)
        /// <summary>
        /// 视频上传到微信公众号
        /// </summary>
        /// <param name="accessToken"></param>accesstoken 微信公众号的token
        /// <param name="path"></param>视频文件
        /// <param name="title"></param>视频的标题
        /// <param name="introduction"></param>视频的描述
        /// <returns></returns>
        public string  video(string accessToken, string path,string title,string introduction)
        {
          return  HttpRequestutil.GetUploadVideoResult( accessToken,  path,  title,  introduction);
        }
        #endregion

        #endregion

        #region 修改素材=============================（新增接口）
        /// <summary>
        /// 修改素材
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="content">修改图文JSON字符串</param>
        public string Update_graphic(string access_token, string content)
        {
            return HttpRequestutil.RequestUrl(string.Format("https://api.weixin.qq.com/cgi-bin/material/update_news?access_token={0}", access_token), content, "post");
        }
        #endregion

        #region  获取素材列表,总数================（新增接口）

        #region 获取素材列表=================（新增接口）
        /// <summary>
        /// 获取素材列表
        /// </summary>
        /// <param name="access_token"></param>
        public string Get_list(string access_token)
        {
            return HttpRequestutil.RequestUrl(string.Format("https://api.weixin.qq.com/cgi-bin/material/batchget_material?access_token={0}", access_token), "post");
        }
        #endregion

        #region 获取素材总数================（新增接口）
        /// <summary>
        /// 获取素材总数
        /// </summary>
        /// <param name="access_token"></param>
        public string Get_count(string access_token)
        {
            return HttpRequestutil.RequestUrl(string.Format("https://api.weixin.qq.com/cgi-bin/material/get_materialcount?access_token={0}", access_token), "get");
        }
        #endregion

        #endregion

        #region 获取永久素材=====================（新增接口）
        /// <summary>
        /// 获取永久素材
        /// </summary>
        /// <param name="access_token"></param>
        /// <param name="media_id">要获取的素材的media_id</param>
        public string Get_graphic(string media_id,string access_token)
        {
          return HttpRequestutil.RequestUrl(string.Format("https://api.weixin.qq.com/cgi-bin/material/get_material?access_token={0}&media_id={1}", access_token, media_id), "post");
        }
        #endregion

        #region 自定义菜单========================（新增接口）
        /// <summary>
        /// 自定义菜单
        /// </summary>
        /// <param name="menu">自定义菜单字符串</param>
        /// <param name="access_token">access_token字符串</param>
        /// <param name="type">类型 1:添加菜单 2:删除菜单 3:查询菜单</param>
        public string  Add_Menu(string  menu,string access_token, int type)
        {
            string result = string.Empty;
            if (type == 1)//添加菜单
                result = HttpRequestutil.RequestUrl(string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", access_token), menu, "post");
            else if (type == 2)//删除菜单            
                result = HttpRequestutil.RequestUrl(string.Format("https://api.weixin.qq.com/cgi-bin/material/delete?access_token={0}", access_token), "GET");
            else //查询菜单
                result = HttpRequestutil.RequestUrl(string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", access_token), "GET");
            return result;
        }
        #endregion
    }
}
