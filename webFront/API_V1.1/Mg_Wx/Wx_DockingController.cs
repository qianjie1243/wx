using Business.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webFront.Models;
using WxTenpay;
using WxTenpay.WXoperation.TModel;

namespace webFront.API
{
    public class Wx_DockingController : BaseController
    {
        private WechatPublic wp = new WechatPublic();
        private Wx_EvenMessage wxevenmessage = new Wx_EvenMessage();
        private Wx_Message wxmessage = new Wx_Message();
        public void SmDocking()
        {
            try
            {
                GetConfig.ResetConfig();
                var Eventlis = wxevenmessage.GetList().Where(x => x.WxAppId == WXconfig.appid).Select(x =>
                {
                    return new EvenMessage
                    {
                      EventKey=  x.EventKey,
                        EventType=  x.EventType,
                        GuId= x.GuId,
                    };
                }).ToList();
                var Messlis = wxmessage.GetList().Where(x => x.WxAppId == WXconfig.appid).Select(x =>
                {
                    return new Message
                    {
                        Content = x.Content,
                        GuId = x.GuId,
                        Key = x.Key,
                        MatchingWay = x.MatchingWay,
                        Name = x.Name,
                        Type = x.Type,

                    };
                }).ToList();
                wp.SaveMesslis(Messlis, Eventlis);
                wp.WxDocking(WXconfig.Token);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}