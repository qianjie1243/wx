using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using WxTenpay.WXoperation.wxconfiguration;

namespace WxTenpay
{
    /// <summary>
    /// 微信菜单配置，上传视频，图片功能
    /// </summary>
    public class Wechat_Menu
    {
        /// <summary>
        /// 加载配置文件
        /// </summary>
        public Wechat_Menu()
        {
            GetConfig.ResetConfig();
        }

        wxmenu menu = new wxmenu();
        WechatPublic Wechat = new WechatPublic();//获取access_token  

        #region  上传素材=========================（新增接口）

        #region 上传图文素材===================（新增接口）
        /// <summary>
        /// 上传图文素材
        /// </summary>
        /// <param name="content">上传的图文JSON字符串</param>
        /// <returns></returns>
        public string graphic(string content)
        {
            try
            {
                return menu.graphic(Wechat.GetToken(), content);
            }
            catch (Exception )
            {
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
            catch (Exception )
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
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #endregion

        #region 修改素材==========================（新增接口）
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
            catch (Exception )
            {
                throw;
            }

        }
        #endregion

        #region  获取素材列表,总数================（新增接口）

        #region 获取素材列表=================（新增接口）
        /// <summary>
        /// 获取素材列表
        /// data {
        /// "type":TYPE,
        ///"offset":OFFSET,
        /// "count":COUNT
        /// }
        /// </summary>
        public string Get_list(string data)
        {
            try
            {
                return menu.Get_list(Wechat.GetToken(),data);
            }
            catch (Exception )
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
            catch (Exception)
            {
                throw;
            }

        }
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
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 移除永久素材=====================（新增接口）
        /// <summary>
        /// 获取永久素材
        /// </summary>
        /// <param name="media_id">要获取的素材的media_id</param>
        public string Del_graphic(string media_id)
        {
            try
            {
                var data = new
                {
                    media_id
                };
                return menu.Del_graphic(JsonConvert.SerializeObject(data), Wechat.GetToken());
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #endregion



        #region 自定义菜单========================（新增接口）
        /// <summary>
        /// 自定义菜单
        /// </summary>
        /// <param name="_menu">自定义菜单对象</param>
        /// <param name="type">类型 1:添加菜单 2:删除菜单 3:查询菜单</param>
        /// 实例
        //Wechat_Menu wx = new Wechat_Menu();
        //List<MenuModel> list = new List<MenuModel>
        //{

        //};
        //List<MenuModel> _MenuParameter = new List<MenuModel>();//多按钮列表
        //MenuModel model = new MenuModel();//
        //model.name = "菜单3-1";
        //model.type = "view";
        //model.url = "";
        //_MenuParameter.Add(model);

        //MenuModel model2 = new MenuModel();
        //model2.name = "菜单3-2";
        //model2.type = "view";
        //model2.url = "https://baidu.com";
        //_MenuParameter.Add(model2);

        //MenuModel _model = new MenuModel();//多按钮主列表名称
        //_model.name = "菜单3";
        //_model.sub_button = _MenuParameter;
        //list.Add(_model);

        //Dictionary<string, object> diy = new Dictionary<string, object>();
        //diy.Add("button", list);
        //var result = wx.Menu(diy, 1);  
        //pamtype=1  对象需要序列化   其他 已序列化
        public string Menu(object _menu, int type,int pamtype=1)
        {
            try
            {

                if (pamtype == 1)
                {
                    var Json = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };//设定过滤null的
                    return menu.Add_Menu(JsonConvert.SerializeObject(_menu, Formatting.Indented, Json), Wechat.GetToken(), type);
                }else
                    return menu.Add_Menu(_menu.ToString(), Wechat.GetToken(), type);
            }
            catch (Exception )
            {
                throw;
            }

        }
        #endregion

        #region 获取关注用户数量
        /// <summary>
        ///  获取关注用户数量
        /// </summary>
        /// <param name="next_openid">默认第一个拉取</param>
        /// <returns></returns>
        public string Getuserlis(string next_openid = "")
        {
            try
            {
                return menu.Getuserlis(Wechat.GetToken(), next_openid);
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

        #region  用户标签管理
        /// <summary>
        /// 创建用户标签
        /// </summary>
        /// <param name="name">标签名称</param>
        /// <returns></returns>
        public string CreateLabel(string name)
        {
            try
            {
                var data = new
                {
                    tag = new { name },
                };
                return menu.CreateLabel(Wechat.GetToken(), JsonConvert.SerializeObject(data));
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        ///  获取公众号已创建的标签
        /// </summary>
        /// <returns></returns>
        public string GetLabels()
        {
            try
            {
                return menu.GetLabels(Wechat.GetToken());
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 编辑公众号已创建的标签
        /// </summary>
        /// <param name="Label_id">标签id</param>
        /// <param name="name">新的名称</param>
        /// <returns></returns>
        public string UpdateLabel(int Label_id, string name)
        {
            try
            {
                var data = new
                {
                    tag = new { id = Label_id, name },
                };
                return menu.UpdateLabel(Wechat.GetToken(), JsonConvert.SerializeObject(data));
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        ///  删除公众号已创建的标签
        /// </summary>
        /// <param name="Label_id">标签id</param>
        public string DeleteLabel(int Label_id)
        {
            try
            {
                var data = new
                {
                    tag = new { id = Label_id },
                };
                return menu.DeleteLabel(Wechat.GetToken(), JsonConvert.SerializeObject(data));
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        ///  获取标签下粉丝列表
        /// </summary>
        /// <param name="Label_id">标签id</param>
        /// <param name="next_openid">第一个拉取的OPENID，不填默认从头开始拉取</param>
        public string GetLabelUsers(int Label_id, string next_openid = "")
        {
            try
            {
                var data = new
                {
                    tagid = Label_id,
                    next_openid,
                };
                return menu.GetLabelUsers(Wechat.GetToken(), JsonConvert.SerializeObject(data));
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        ///  批量为用户打标签
        /// </summary>
        /// <param name="Label_id">标签id</param>
        /// <param name="openid_list">粉丝列表openid</param>
        public string CreateUserLabel(int Label_id, string[] openid_list)
        {
            try
            {
                var data = new
                {
                    openid_list,
                    tagid = Label_id,
                };
                return menu.CreateUserLabel(Wechat.GetToken(), JsonConvert.SerializeObject(data));
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        ///  批量为用户取消标签
        /// </summary>
        /// <param name="Label_id">标签id</param>
        /// <param name="openid_list">粉丝列表openid</param>
        public string DeteteUserLabel(int Label_id, string[] openid_list)
        {
            try
            {
                var data = new
                {
                    openid_list,
                    tagid = Label_id,
                };
                return menu.DeteteUserLabel(Wechat.GetToken(), JsonConvert.SerializeObject(data));
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        ///  获取用户身上的标签列表
        /// </summary>
        /// <returns></returns>
        public string GetUserLabels(string openid)
        {
            try
            {
                var data = new
                {
                    openid,
                };
                return menu.GetUserLabels(Wechat.GetToken(), JsonConvert.SerializeObject(data));
            }
            catch (Exception)
            {

                throw;
            }
        }


        #endregion
    }
}
