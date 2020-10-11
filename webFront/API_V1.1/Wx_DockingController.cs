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
    public class Wx_DockingController: BaseController
    {
        private WechatPublic wp = new WechatPublic();
        private Wx_EvenMessage wxevenmessage = new Wx_EvenMessage();
        private Wx_Message wxmessage = new Wx_Message();
        public void SmDocking()
        {
            try
            {
                GetConfig.ResetConfig();
                var Eventlis = wxevenmessage.GetList().Where(x => x.WxAppId == WXconfig.appid);
                var Messlis = wxmessage.GetList().Where(x => x.WxAppId == WXconfig.appid);
                wp.SaveMesslis((List<Message>)Messlis, (List<EvenMessage>)Eventlis);
                wp.WxDocking(WXconfig.Token);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}