using System;
using System.Collections.Generic;
using System.Web.Http;
using webFront.Models;
using Common;
using WxTenpay;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using WxTenpay.WXoperation.TModel;
using Redis.CacheBase;
using System.Configuration;
using Redis;

namespace webFront.API
{

    /// <summary>
    /// 微信接口
    /// </summary>
    public class WXDataController : BaseController
    {
        #region 业务
        private WeChatPayment wpm = new WeChatPayment();
        private Wechat_Menu wm = new Wechat_Menu();
        private WechatPublic wp = new WechatPublic();
        #endregion

        #region 缓存定义
        private ICache cache = CacheFactory.CaChe();
        private string cacheKey = "wxuser";
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
                List<WxTenpay.WXoperation.gerenxinxi> use = new List<WxTenpay.WXoperation.gerenxinxi>();
                if (use.Count == 0)
                {
                    use = getWxUserLis(new List<WxTenpay.WXoperation.gerenxinxi>());
                }
                return Success(use);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
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
        /// 获取微信菜单
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
                var munlis = wm.Menu("", 3);
                return Success(munlis);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
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
                return Success(munlis);
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
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
                return Error(ex.Message);
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
                return Error(ex.Message);
            }

        }



        #endregion

        #region 获取素材
        /// <summary>
        ///获取素材列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetSCList(string data)
        {
            try
            {
                GetConfig.ResetConfig();
                if (WXconfig.appid.IsEmpty() || WXconfig.secret.IsEmpty())
                {
                    return Error("请先完善微信配置文件！");
                }
                return Success(wm.Get_list(data));
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
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
                return Error(ex.Message);
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
                GetConfig.ResetConfig();
                if (WXconfig.appid.IsEmpty() || WXconfig.secret.IsEmpty())
                {
                    return Error("请先完善微信配置文件！");
                }
                return Success(wm.Del_graphic(mid));
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }

        }



        #endregion

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
                if (type == 0) return Success(wp.WeiXinKeFu(openid.Trim(), content));

                else return Success(wp.WeiXinTemplate(openid.Trim(), temid.Trim(), temp, openurl));
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }

        }
        #endregion

        #region 微信自动回复
        /// <summary>
        ///微信自动回复
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object SaveMess(List<Message> lis, List<EvenMessage> eventlis)
        {
            try
            {
                if (lis != null)
                {
                    lis.ForEach(x =>
                    {
                        x.Content = Common.Base64.DecodeBase64(x.Content);

                    });
                }
                wp.SaveMesslis(lis, eventlis);
                return Success("操作成功！");
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
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
                return Success(wp.GetMesslis());
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }

        }
        #endregion 
    }
}
