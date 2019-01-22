using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxTenpay
{
    /// <summary>
    /// 微信菜单配置，上传视频，图片功能
    /// </summary>
    public class Wechat_Menu
    {
        wxconfig.wxconfiguration.wxmenu menu = new wxconfig.wxconfiguration.wxmenu();
        WechatPublic Wechat = new WechatPublic();//获取access_token  

        #region  上传素材=========================（新增接口）

        #region 上传图文素材===================（新增接口）
        /// <summary>
        /// 上传图文素材
        /// </summary>
        /// <param name="content">上传的图文JSON字符串</param>
        /// <returns></returns>
        public string graphic( string content)
        {
            try
            {
                return menu.graphic(Wechat.GetToken(), content);
            }
            catch (Exception ex) {
                throw;
            }
        }
        #endregion

        #region 上传图片,语音，缩略图===========（新增接口）
        /// <summary>
        /// 上传图片,语音，缩略图
        /// </summary>
        /// <param name="path">绝对图片路径</param>
        /// <param name="type">类型 image 图片类型,   thumb 缩略图, voice 语音</param>
        public string material(string path, string type)
        {
            try
            {
                return menu.material(path, Wechat.GetToken(), type);
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
        #endregion

        #region 视频上传到微信公众号=====================(新增接口)
        /// <summary>
        /// 视频上传到微信公众号
        /// </summary>
        /// <param name="path"></param>视频文件
        /// <param name="title"></param>视频的标题
        /// <param name="introduction"></param>视频的描述
        /// <returns></returns>
        public string video(string path, string title, string introduction)
        {
            try
            {
                return menu.video(Wechat.GetToken(), path, title, introduction);
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
        #endregion

        #endregion

        #region 修改素材=============================（新增接口）
        /// <summary>
        /// 修改素材
        /// </summary>
        /// <param name="content">修改图文JSON字符串</param>
        public string Update_graphic(string content)
        {
            try
            {
                return menu.Update_graphic(Wechat.GetToken(), content);
            }
            catch (Exception ex)
            {
                throw;
            }
          
        }
        #endregion

        #region  获取素材列表,总数================（新增接口）

        #region 获取素材列表=================（新增接口）
        /// <summary>
        /// 获取素材列表
        /// </summary>
        public string Get_list()
        {
            try
            {
                return menu.Get_list(Wechat.GetToken());
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
        #endregion

        #region 获取素材总数================（新增接口）
        /// <summary>
        /// 获取素材总数
        /// </summary>
        public string Get_count()
        {

            try
            {
                return menu.Get_count(Wechat.GetToken());
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
        #endregion

        #endregion

        #region 获取永久素材=====================（新增接口）
        /// <summary>
        /// 获取永久素材
        /// </summary>
        /// <param name="media_id">要获取的素材的media_id</param>
        public string Get_graphic(string media_id)
        {
            try
            {
                return menu.Get_graphic(media_id, Wechat.GetToken());
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
        #endregion

        #region 自定义菜单========================（新增接口）
        /// <summary>
        /// 自定义菜单
        /// </summary>
        /// <param name="Menu">自定义菜单字符串</param>
        /// <param name="type">类型 1:添加菜单 2:删除菜单 3:查询菜单</param>
        /// 

        public string Menu(string Menu, int type)
        {
            try
            {
                return menu.Add_Menu(Menu, Wechat.GetToken(), type);
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
        #endregion
    }
}
