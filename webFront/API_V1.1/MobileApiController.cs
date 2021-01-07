using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webFront.Models;
using WxTenpay;
using Common;
using System.Web.Mvc;

namespace webFront.API_V1._1
{
    /// <summary>
    /// 手机端接口
    /// </summary>
    public class MobileApiController : BaseController
    {
        #region 业务数据
        WeChatPayment wxpay = new WeChatPayment();
        WechatPublic wxpu = new WechatPublic();
        #endregion

        #region 获取微信配置
        /// <summary>
        /// 获取微信配置
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetConfig(string url)
        {
            try
            {
                string _url = Base64.DecodeBase64(url);
                var data = wxpu.GetWxConfig(_url);
                return Success(data);
            }
            catch (Exception ex)
            {
                return ErrorLog(ex.ToString(), "微信前端测试接口");
            }

        }

        #endregion

        #region 获取基本信息
        /// <summary>
        /// 获取基本信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetInformation(string code)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                    return Redirect(wxpu.GetAuthorizationUrl(""));
                var data = wxpu.GetOpenid(code);
                return Success(data);
            }
            catch (Exception ex)
            {
                return ErrorLog(ex.ToString(), "微信前端测试接口");
            }

        }
        #endregion

        #region 微信支付
        /// <summary>
        /// 微信支付
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetPay(string openid)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(openid))
                    return Error("授权失败！");

                var ip = HttpContext.Request.UserHostAddress;//获取ip
                var orderno = Utils.GetOrderNumber();
                var data = wxpay.JSAPIPayMent("测试", "测试", openid, ip, 0.01, orderno);
                return Success(data);
            }
            catch (Exception ex)
            {
                return ErrorLog(ex.ToString(), "微信前端测试接口");
            }

        }
        #endregion

        #region 微信扫码支付
        /// <summary>
        /// 微信扫码支付
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetScanPay()
        {
            try
            {
                var ip = HttpContext.Request.UserHostAddress;//获取ip
                var orderno = Utils.GetOrderNumber();
                var product_id = Guid.NewGuid().ToString("N");
                var data = wxpay.NATIVEPayMent("测试", "测试", ip, 0.01, orderno, product_id);
                return Success(data);
            }
            catch (Exception ex)
            {
                return ErrorLog(ex.ToString(), "微信前端测试接口");
            }

        }
        #endregion

        #region 根据openid获取基本信息
        /// <summary>
        /// 根据openid获取基本信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetOpenidInformation(string openid)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(openid))
                    return Error("授权失败！");
                var data = wxpu.GetPerson(openid);
                return Success(data);
            }
            catch (Exception ex)
            {
                return ErrorLog(ex.ToString(), "微信前端测试接口");
            }

        }
        #endregion 

    }
}