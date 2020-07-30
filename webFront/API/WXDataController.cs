using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webFront.Models;
using Common;
using WxTenpay;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace webFront.API
{

    /// <summary>
    /// 微信接口
    /// </summary>
    public class WXDataController : BaseController
    {
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
                    XmlHelper.Upxml("WxTenpay.config", "AppID", _entity["appid"].ToString());
                }
                if (WXconfig.secret != _entity["secret"].ToString())
                {
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
                GetConfig.ResetConfig();
                var data = new
                {
                    model
                };
                return Success(data);

            }
            catch (Exception ex)
            {
                return Error(ex.ToString());
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
                };
                return Success(data);

            }
            catch (Exception ex)
            {
                return Error(ex.ToString());
            }

        }
        #endregion

        #region 
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
                if (WXconfig.appid.IsEmpty() || WXconfig.secret.IsEmpty()) {
                    return Error("请先完善微信配置文件！");
                }
                List<WxTenpay.WXoperation.gerenxinxi> use = new List<WxTenpay.WXoperation.gerenxinxi>();
                if (use.Count==0)
                {
                    use = getWxUserLis(new List<WxTenpay.WXoperation.gerenxinxi>());
                }

                return Success(use);
            }
            catch (Exception ex)
            {
                return Error(ex.ToString());
            }

        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        private List<WxTenpay.WXoperation.gerenxinxi> getWxUserLis(List<WxTenpay.WXoperation.gerenxinxi> Glist, string next_openid = "")
        {

            WechatPublic wp = new WechatPublic();
            try
            {

                var lis = new Wechat_Menu().Getuserlis(next_openid);
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


    }
}
