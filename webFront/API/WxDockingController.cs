using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webFront.Models;
using WxTenpay;

namespace webFront.API
{
    /// <summary>
    /// 微信验证url对接数据
    /// </summary>
    public class WxDockingController : BaseController
    {
        private WechatPublic wp = new WechatPublic();
        public void SmDocking() {

            try
            {
                GetConfig.ResetConfig();
                wp.WxDocking(WXconfig.Token);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}