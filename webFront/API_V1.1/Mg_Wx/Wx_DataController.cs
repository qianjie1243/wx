using Business.Business;
using Common;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Util;
using webFront.Models;
using WxTenpay;

namespace webFront.API
{
    public class Wx_DataController : BaseController
    {
        #region 业务
        private WeChatPayment wpm = new WeChatPayment();//微信操作类型
        private Wechat_Menu wm = new Wechat_Menu();//微信菜单
        private WechatPublic wp = new WechatPublic();//微信操作类
        private string personpath = "/file/media";
        private Wx_EvenMessage wxevenmessage = new Wx_EvenMessage();//自动回复事件
        private Wx_Menu wxmenu = new Wx_Menu();//微信菜单
        private Wx_Message wxmessage = new Wx_Message();//自动回复
        private Wx_User wxuser = new Wx_User();//推送人员
        private Wx_PushTemplate wxpushtemplate = new Wx_PushTemplate();//推送模板

        private Wx_PushList wxpushlist = new Wx_PushList();//推送记录

        private Wx_Material wxmaterial = new Wx_Material();//素材数据
        #endregion

        #region wx配置
        /// <summary>
        /// 修改配置文件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public object Config(string model)
        {
            try
            {
                var _entity = Common.JsonHelper.DataRowFromJSON(model);


                if (WXconfig.appid != _entity["appid"].ToString())
                {
                    wp.EmptyToken();//清空token
                    XmlHelper.Upxml("WxTenpay.config", "AppID", _entity["appid"].ToString());
                }
                if (WXconfig.secret != _entity["secret"].ToString())
                {
                    wp.EmptyToken();//清空token
                    XmlHelper.Upxml("WxTenpay.config", "Secret", _entity["secret"].ToString());
                }
                if (WXconfig.mch_id != _entity["mch_id"].ToString())
                {
                    XmlHelper.Upxml("WxTenpay.config", "MchId", _entity["mch_id"].ToString());
                }
                if (WXconfig.paysignkey != _entity["paysignkey"].ToString())
                {
                    XmlHelper.Upxml("WxTenpay.config", "TenPayKey", _entity["paysignkey"].ToString());
                }
                if (WXconfig.url != _entity["url"].ToString())
                {
                    XmlHelper.Upxml("WxTenpay.config", "URL", _entity["url"].ToString());
                }
                if (WXconfig.SSLCERT_PASSWORD != _entity["SSLCERT_PASSWORD"].ToString())
                {
                    XmlHelper.Upxml("WxTenpay.config", "SSLCERTPASSWORD", _entity["SSLCERT_PASSWORD"].ToString());
                }
                if (WXconfig.SSLCERT_PATH != _entity["SSLCERT_PATH"].ToString())
                {
                    XmlHelper.Upxml("WxTenpay.config", "SSLCERTPATH", _entity["SSLCERT_PATH"].ToString());
                }
                if (WXconfig.Token != _entity["Token"].ToString())
                {
                    XmlHelper.Upxml("WxTenpay.config", "Token", _entity["Token"].ToString());
                }
                GetConfig.ResetConfig();
                var data = new
                {
                    model
                };
                return Success(data);

            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }

        }

        /// <summary>
        /// 获取配置文件数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GainConfig()
        {
            try
            {

                GetConfig.ResetConfig();
                var data = new
                {
                    WXconfig.appid,
                    WXconfig.mch_id,
                    WXconfig.paysignkey,
                    WXconfig.secret,
                    WXconfig.SSLCERT_PASSWORD,
                    WXconfig.SSLCERT_PATH,
                    WXconfig.url,
                    WXconfig.Token
                };
                return Success(data);

            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }

        }
        #endregion

        #region  关注用户
        /// <summary>
        /// 获取关注用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetUser()
        {
            try
            {
                GetConfig.ResetConfig();
                if (WXconfig.appid.IsEmpty() || WXconfig.secret.IsEmpty())
                {
                    return Error("请先完善微信配置文件！");
                }
                List<Wx_UserEntity> data = new List<Wx_UserEntity>();
                var use = getWxUserLis(new List<WxTenpay.WXoperation.gerenxinxi>());
                if (use.Count > 0)//添加数据列表 数据库
                {

                    wxuser.Delete(x => x.Id > 0);//移除数据库记录
                    data = use.Select(x =>
                    {
                        return new Wx_UserEntity
                        {
                            Sex = x.sex,
                            Address = x.country + x.province + x.city,
                            GuId = Guid.NewGuid().ToString(),
                            CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                            Nickname = x.nickname,
                            SubscribeTime = x.subscribe_time,
                            Openid = x.openid,
                            WxAppId = WXconfig.appid,
                            Headimgurl = x.headimgurl
                        };

                    }).ToList();

                    wxuser.AddList(data);
                }

                return Success(data);
            }
            catch (Exception ex)
            {
                return ErrorLog(ex.ToString(), "获取关注用户");
            }

        }


        /// <summary>
        /// 获取数据库关注用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetDBUser(PageParm parm, string queryjson)
        {
            try
            {

                var query = queryjson.ToJObject();

                #region 
                var expression = LinqExtensions.True<Wx_UserEntity>();
                if (!query["Name"].IsEmpty())
                {
                    expression = expression.And(t => t.Nickname.Contains(query["Name"].ToString()));
                }
                if (!query["Sex"].IsEmpty())
                {
                    expression = expression.And(t => t.Sex.ToString() == query["Sex"].ToString());
                }

                #endregion
                return Success(wxuser.GetPages(parm, expression, x => x.CreateTime, 2));

            }
            catch (Exception ex)
            {
                return ErrorLog(ex.ToString(), "获取数据库关注用户");
            }

        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        private List<WxTenpay.WXoperation.gerenxinxi> getWxUserLis(List<WxTenpay.WXoperation.gerenxinxi> Glist, string next_openid = "")
        {

            try
            {

                var lis = wm.Getuserlis(next_openid);
                JObject li = (JObject)JsonConvert.DeserializeObject(lis);
                if (!li["errcode"].IsEmpty())
                {
                    throw new Exception(li["errmsg"].ToString());
                }
                else
                {
                    JObject openids = (JObject)JsonConvert.DeserializeObject(li["data"].ToString());
                    JArray jaa = (JArray)JsonConvert.DeserializeObject(openids["openid"].ToString());
                    for (var i = 0; i < jaa.Count; i++)
                    {
                        var va = jaa[i].ToString();
                        var jsonperson = wp.GetPerson(va);
                        //var model = JsonConvert.DeserializeObject<WxTenpay.WXoperation.gerenxinxi>(jsonperson);
                        Glist.Add(jsonperson);
                    }

                    if (li["count"].ToInt() == 10000 && li["total"].ToInt() > li["count"].ToInt())
                    {
                        return getWxUserLis(Glist, li["next_openid"].ToString());
                    }
                    return Glist;


                }


            }
            catch (Exception ex)
            {

                throw;
            }

        }
        #endregion

        #region  微信菜单
        /// <summary>
        /// 获取接口微信菜单
        /// </summary>   
        /// <returns></returns>
        /// 
        [HttpGet]
        public object GetURLWMenu()
        {
            try
            {
                GetConfig.ResetConfig();
                if (WXconfig.appid.IsEmpty() || WXconfig.secret.IsEmpty())
                {
                    return Error("请先完善微信配置文件！");
                }
                var munlis = wm.Menu("", 3);
                var Content = "";
                var oj = (JObject)JsonConvert.DeserializeObject(munlis);
                if (!oj["menu"].IsEmpty())
                {
                    Content = oj["menu"].ToString();
                }
                var model = wxmenu.GetModel(x => x.WxAppId == WXconfig.appid);
                if (!string.IsNullOrWhiteSpace(model.GuId))
                {
                    model.Content = Content;
                    wxmenu.Update(model);
                }
                else
                {
                    model.WxAppId = WXconfig.appid;
                    model.Content = Content;
                    model.Create();
                    wxmenu.Add(model);
                }
                return Success(Content);
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "微信菜单");
            }

        }

        /// <summary>
        /// 获取数据库微信菜单
        /// </summary>   
        /// <returns></returns>
        /// 
        [HttpGet]
        public object GetWMenu()
        {
            try
            {
                GetConfig.ResetConfig();
                if (WXconfig.appid.IsEmpty() || WXconfig.secret.IsEmpty())
                {
                    return Error("请先完善微信配置文件！");
                }
                var model = wxmenu.GetModel(x => x.WxAppId == WXconfig.appid);

                if (string.IsNullOrWhiteSpace(model.GuId))
                    return Success(new object() { });
                return Success(model.Content);
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "微信菜单");
            }

        }

        /// <summary>
        /// 保存微信菜单
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public object AddWMenu(string menu)
        {
            try
            {
                GetConfig.ResetConfig();
                if (WXconfig.appid.IsEmpty() || WXconfig.secret.IsEmpty())
                {
                    return Error("请先完善微信配置文件！");
                }
                var munlis = wm.Menu(menu, 1, 2);

                var model = wxmenu.GetModel(x => x.WxAppId == WXconfig.appid);
                if (!string.IsNullOrWhiteSpace(model.GuId))
                {
                    model.Content = menu;
                    wxmenu.Update(model);
                }
                else
                {
                    model.WxAppId = WXconfig.appid;
                    model.Content = menu;
                    model.Create();
                    wxmenu.Add(model);
                }
                return Success(munlis);
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "保存微信菜单");
            }

        }
        #endregion

        #region 获取token/jsapi_ticket

        /// <summary>
        ///    获取token
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetToken()
        {
            try
            {
                GetConfig.ResetConfig();
                if (WXconfig.appid.IsEmpty() || WXconfig.secret.IsEmpty())
                {
                    return Error("请先完善微信配置文件！");
                }
                var data = new
                {
                    Token = wp.GetToken(),
                    JsapiTicket = wp.GetJsapi_ticket(),
                    JTime = wp.GetJsapiTicketTime().ToString("yyyy-MM-dd HH:mm:ss"),
                    Time = wp.GetTokenTime().ToString("yyyy-MM-dd HH:mm:ss")
                };
                return Success(data);
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "获取token");
            }

        }


        /// <summary>
        ///    获取GetJsapi_ticket
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetJsapi_ticket()
        {
            try
            {
                GetConfig.ResetConfig();
                if (WXconfig.appid.IsEmpty() || WXconfig.secret.IsEmpty())
                {
                    return Error("请先完善微信配置文件！");
                }
                var data = new
                {
                    JsapiTicket = wp.GetJsapi_ticket(),
                    Time = wp.GetJsapiTicketTime().ToString("yyyy-MM-dd HH:mm:ss")
                };
                return Success(data);
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "获取GetJsapi_ticket");
            }

        }



        #endregion

        #region 获取素材
        /// <summary>
        ///获取素材列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetSCPageList(PageParm parm, string queryjson)
        {
            try
            {

                var query = queryjson.ToJObject();

                #region 查询条件
                var expression = LinqExtensions.True<Wx_MaterialEntity>();
                if (!query["Type"].IsEmpty())
                {
                    expression = expression.And(t => t.Type == query["Type"].ToString());
                }
                #endregion

                return Success(wxmaterial.GetPages(parm, expression, x => x.CreateTime, 2));
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "获取素材列表");
            }

        }


        /// <summary>
        ///获取素材列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetSCList(string type="")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(type))
                    return Success(wxmaterial.GetList());
                else
                    return Success(wxmaterial.GetList().Where(x => x.Type == type));
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "获取素材列表");
            }

        }

        /// <summary>
        ///获取素材总数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetSCCount()
        {
            try
            {
                GetConfig.ResetConfig();
                if (WXconfig.appid.IsEmpty() || WXconfig.secret.IsEmpty())
                {
                    return Error("请先完善微信配置文件！");
                }
                return Success(wm.Get_count());
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "获取素材总数");
            }

        }

        /// <summary>
        ///获取移素材
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object DeleteSC(string mid)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(mid))
                {
                    return Error("参数异常！");
                }
                var ob = wm.Del_graphic(mid);
                var obj = (JObject)JsonConvert.DeserializeObject(ob);
                if (obj["errcode"].ToString() == "0")
                {
                    wxmaterial.Delete(x => x.Media_Id == mid);
                    return SuccessLog("操作成功！", ob, "微信素材操作", 3);
                }
                else
                {
                    return Error(ob);
                }
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "获取移素材");
            }

        }
        /// <summary>
        /// 上传素材功能
        /// </summary>
        /// <returns></returns>
        public object AddMaterialList(string lis, string type)
        {
            List<string> result = new List<string>();
            List<Wx_MaterialEntity> addlis = new List<Wx_MaterialEntity>();
            try
            {


                GetConfig.ResetConfig();
                if (WXconfig.appid.IsEmpty() || WXconfig.secret.IsEmpty())
                {
                    return Error("请先完善微信配置文件！");
                }

                switch (type)
                {
                    case "1"://图文素材

                        var res1 = wm.graphic(lis);
                        result.Add(res1);
                        var obj1 = (JObject)JsonConvert.DeserializeObject(res1);
                        if (obj1["errcode"].IsEmpty())
                        {
                            Wx_MaterialEntity model1 = new Wx_MaterialEntity();
                            model1.Create();
                            model1.Content = lis;
                            model1.Type = "news";
                            model1.Media_Id = obj1["media_id"].ToString();
                            model1.WxAppId = WXconfig.appid;
                            addlis.Add(model1);
                        }
                        else
                            return Error(res1);
                        break;
                    case "2"://图片素材image
                        #region 保存文件
                        var files = System.Web.HttpContext.Current.Request.Files;
                        if (files != null && files.Count > 0)
                        {
                            string[] names = files.AllKeys;
                            for (int i = 0; i < names.Length; i++)
                            {
                                if (files[i].ContentLength > 0)
                                {
                                    var pathfile = Common.Thumbnail.UploadFile(files[i], personpath + "/images/" + DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMddHHmmss"));
                                    if (string.IsNullOrWhiteSpace(pathfile))
                                    {
                                        return Error("文件异常，请重新上传文件！");
                                    }
                                    var res = wm.material(Thumbnail.GetMapPath(pathfile), "image");
                                    result.Add(res);
                                    var obj = (JObject)JsonConvert.DeserializeObject(res);
                                    if (obj["errcode"].IsEmpty())
                                    {
                                        Wx_MaterialEntity model = new Wx_MaterialEntity();
                                        model.Create();
                                        model.Media_Id = obj["media_id"].ToString();
                                        model.Url = obj["url"].ToString();
                                        model.PathUrl = pathfile;
                                        model.Type = "image";
                                        model.WxAppId = WXconfig.appid;
                                        addlis.Add(model);
                                    }
                                }

                            }
                        }
                        #endregion                     
                        break;
                    case "3"://语音素材voice
                        #region 保存文件
                        var mp3files = System.Web.HttpContext.Current.Request.Files;
                        if (mp3files != null && mp3files.Count > 0)
                        {
                            string[] names = mp3files.AllKeys;
                            for (int i = 0; i < names.Length; i++)
                            {
                                if (mp3files[i].ContentLength > 0)
                                {
                                    var pathfile = Common.Thumbnail.UploadFile(mp3files[i], personpath + "/voice/" + DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMddHHmmss"));
                                    if (string.IsNullOrWhiteSpace(pathfile))
                                    {
                                        return Error("文件异常，请重新上传文件！");
                                    }

                                    var res = wm.material(Thumbnail.GetMapPath(pathfile), "voice");
                                    result.Add(res);
                                    var obj = (JObject)JsonConvert.DeserializeObject(res);
                                    if (obj["errcode"].IsEmpty())
                                    {
                                        Wx_MaterialEntity model = new Wx_MaterialEntity();
                                        model.Create();
                                        model.Media_Id = obj["media_id"].ToString();
                                        model.PathUrl = pathfile;
                                        model.Type = "voice";
                                        model.WxAppId = WXconfig.appid;
                                        addlis.Add(model);
                                    }
                                    //result.Add(wm.material(Thumbnail.GetMapPath(pathfile), "voice"));
                                }

                            }
                        }
                        #endregion
                        break;
                    case "4"://视频素材 video
                        JArray ja = (JArray)JsonConvert.DeserializeObject(lis);
                        foreach (var item in ja)
                        {
                            #region 保存文件
                            var voidfiles = System.Web.HttpContext.Current.Request.Files;
                            if (voidfiles != null && voidfiles.Count > 0)
                            {
                                string[] names = voidfiles.AllKeys;
                                for (int i = 0; i < names.Length; i++)
                                {
                                    if (voidfiles[i].ContentLength > 0)
                                    {
                                        var pathfile = Common.Thumbnail.UploadFile(voidfiles[i], personpath + "/video/" + DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMddHHmmss"));
                                        if (string.IsNullOrWhiteSpace(pathfile))
                                        {
                                            return Error("文件异常，请重新上传文件！");
                                        }

                                        var res = wm.video(Thumbnail.GetMapPath(pathfile), item["title"].ToString(), item["introduction"].ToString());
                                        result.Add(res);
                                        var obj = (JObject)JsonConvert.DeserializeObject(res);
                                        if (obj["errcode"].IsEmpty())
                                        {
                                            Wx_MaterialEntity model = new Wx_MaterialEntity();
                                            model.Create();
                                            model.Media_Id = obj["media_id"].ToString();
                                            model.PathUrl = pathfile;
                                            model.Type = "video";
                                            model.WxAppId = WXconfig.appid;
                                            addlis.Add(model);
                                        }
                                    }

                                }
                            }
                            #endregion
                        }
                        break;
                    case "5":
                        break;
                }

                wxmaterial.AddList(addlis);

                return SuccessLog("操作成功！", result, "微信素材操作", 1);
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "上传素材");
            }
        }


        #endregion

        #region 推送
        #region  发送微信推送消息
        /// <summary>
        ///发送微信推送消息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object SaveSms(List<Template> temp, string openid, string content, string temid, int type, string openurl)
        {
            try
            {
                GetConfig.ResetConfig();
                if (WXconfig.appid.IsEmpty() || WXconfig.secret.IsEmpty())
                {
                    return Error("请先完善微信配置文件！");
                }
                if (type == 0)
                {
                    var model = wp.WeiXinKeFu(openid.Trim(), content);
                    var Pushmodel = new Wx_PushListEntity() { ResContent = JsonConvert.SerializeObject(model), Content = content, Oppid = openid.Trim(), TempId = "文本推送", WxAppId = WXconfig.appid };
                    Pushmodel.Create();
                    wxpushlist.Add(Pushmodel);
                    return Success(model);
                }
                else
                {
                    var model = wp.WeiXinTemplate(openid.Trim(), temid.Trim(), temp, openurl);
                    var Pushmodel = new Wx_PushListEntity() { ResContent = JsonConvert.SerializeObject(model), Oppid = openid.Trim(), TempId = temid.Trim(), WxAppId = WXconfig.appid, Content = temp.ToJson() };
                    Pushmodel.Create();
                    wxpushlist.Add(Pushmodel);
                    return Success(model);
                }
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "微信推送消息");
            }

        }


        /// <summary>
        ///获取推送配置
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public object GetSmsConfig()
        {
            try
            {
                var lis = wxuser.GetList().Where(x => x.WxAppId == WXconfig.appid);
                var templateLis = wxpushtemplate.GetList().Where(x => x.WxAppId == WXconfig.appid);
                var data = new
                {
                    lis,
                    templateLis
                };


                return Success(data);
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "获取微信用户列表");
            }

        }
        #endregion

        #region 微信推送模板维护
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public object GetTempList(PageParm parm, string queryjson)
        {
            try
            {
                var query = queryjson.ToJObject();

                #region 
                var expression = LinqExtensions.True<Wx_PushTemplateEntity>();
                if (!query["Name"].IsEmpty())
                {
                    expression = expression.And(t => t.Name.Contains(query["Name"].ToString()));
                }

                #endregion
                return Success(wxpushtemplate.GetPages(parm, expression, x => x.CreateTime, 2));
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "获取微信模板列表");
            }

        }
        /// <summary>
        /// 编辑微信模板
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public object SaveTempFrom(Wx_PushTemplateEntity entity)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(entity.GuId))
                {
                    var model = wxpushtemplate.GetModel(x => x.GuId == entity.GuId);
                    model.Name = entity.Name;
                    model.TempId = entity.TempId;
                    model.Content = entity.Content;
                    wxpushtemplate.Update(model);
                }
                else
                {
                    entity.WxAppId = WXconfig.appid;
                    entity.Create();
                    wxpushtemplate.Add(entity);
                }
                return Success("操作成功！");
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "编辑微信模板");
            }

        }


        /// <summary>
        /// 微信模板详情
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public object GetTempdetails(string guid)
        {
            try
            {
                var model = wxpushtemplate.GetModel(x => x.GuId == guid);
                return Success(model);
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "微信模板详情");
            }

        }

        /// <summary>
        /// 移除微信模板
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public object DeleteTempList(string guid)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(guid))
                    wxpushtemplate.Delete(x => x.GuId == guid);
                else
                    return Error("参数错误！");
                return Success("操作成功！");
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "移除微信模板");
            }

        }
        #endregion

        #region 推送记录
        /// <summary>
        /// 获取推送列表
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public object GetPushList(PageParm parm, string queryjson)
        {
            try
            {
                var query = queryjson.ToJObject();

                #region 
                var expression = LinqExtensions.True<Wx_PushListEntity>();
                if (!query["TempId"].IsEmpty())
                {
                    expression = expression.And(t => t.TempId.Contains(query["TempId"].ToString()));
                }
                if (!query["Oppid"].IsEmpty())
                {
                    expression = expression.And(t => t.Oppid.Contains(query["Oppid"].ToString()));
                }

                var res = wxpushlist.GetPages(parm, expression, x => x.CreateTime, 2);
                res.Items = res.Items.Select(x =>
                  {
                      if (!string.IsNullOrWhiteSpace(x.TempId))
                          x.PushTemp = wxpushtemplate.GetModel(p => p.TempId == x.TempId);
                      if (!string.IsNullOrWhiteSpace(x.Oppid))
                          x.User = wxuser.GetModel(p => p.Openid == x.Oppid);
                      return x;
                  }).ToList();
                #endregion
                return Success(res);
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "获取微信模板列表");
            }

        }
        #endregion 

        #endregion

        #region 微信自动回复
        /// <summary>
        ///微信自动回复
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object SaveMess(List<Wx_MessageEntity> lis, List<Wx_EvenMessageEntity> eventlis)
        {
            try
            {
                if (WXconfig.appid.IsEmpty() || WXconfig.secret.IsEmpty())
                {
                    return Error("请先完善微信配置文件！");
                }


                using (TransactionScope tran = new TransactionScope())
                {
                    wxevenmessage.Delete(x => x.WxAppId == WXconfig.appid);//移除数据
                    wxmessage.Delete(x => x.WxAppId == WXconfig.appid);//移除数据
                    if (lis != null)
                    {
                        lis.ForEach(x =>
                        {
                            x.Content = Common.Base64.DecodeBase64(x.Content);
                            x.WxAppId = WXconfig.appid;
                            x.Create();
                        });
                        wxmessage.AddList(lis);

                    }

                    if (eventlis != null)
                    {
                        eventlis.ForEach(x =>
                        {
                            x.WxAppId = WXconfig.appid;
                            x.Create();
                        });
                        wxevenmessage.AddList(eventlis);

                    }

                    tran.Complete();
                }

                // wp.SaveMesslis(lis, eventlis);
                return Success("操作成功！");
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "微信自动回复");
            }

        }

        /// <summary>
        ///获取微信自动回复
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetMess()
        {
            try
            {
                if (WXconfig.appid.IsEmpty() || WXconfig.secret.IsEmpty())
                {
                    return Error("请先完善微信配置文件！");
                }
                var Eventlis = wxevenmessage.GetList().Where(x => x.WxAppId == WXconfig.appid);
                var Messlis = wxmessage.GetList().Where(x => x.WxAppId == WXconfig.appid);

                var date = new
                {
                    Messlis,
                    Eventlis
                };
                return Success(date);
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "获取微信自动回复");
            }

        }
        #endregion

    }
}