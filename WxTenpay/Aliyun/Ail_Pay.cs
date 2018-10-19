using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using Aop.Api.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WxTenpay.Aliyun
{
    /// <summary>
    /// 支付宝支付
    /// </summary>
   public  class Ail_Pay
    {

        /// <summary>
        /// H5支付
        /// </summary>
        /// <param name="Body">对一笔交易的具体描述信息</param>
        /// <param name="Subject">商品描述</param>
        /// <param name="TotalAmount">金额</param>
        /// <param name="OutTradeNo">商家唯一订单，填写你项目里生成的唯一订单号</param>
        /// <returns></returns>
        public static string H5Alipay(string Body, string Subject, string TotalAmount, string OutTradeNo)
        {
            try
            {
                string timeout_express = "30m";//订单有效时间（分钟）           
                string method = "alipay.trade.wap.pay";//调用接口 固定值 不用改
                IAopClient client = new DefaultAopClient("https://openapi.alipay.com/gateway.do", Ailconfig.APPID, Ailconfig.APP_PRIVATE_KEY, "json", "1.0", "RSA2", Ailconfig.ALIPAY_PUBLIC_KEY, "UTF-8", false);
                AlipayTradeWapPayRequest request = new AlipayTradeWapPayRequest();
                request.SetNotifyUrl(Ailconfig.NotifyUrl);//异步请求
               // request.SetReturnUrl(Ailconfig.ReturnUrl);//同步请求
                request.BizContent = "{" +
                "    \"body\":\""+ Body + "\"," +
                "    \"subject\":\""+ Subject + "\"," +
                "    \"out_trade_no\":\""+ OutTradeNo + "\"," +
                "    \"timeout_express\":\"" + timeout_express + "\"," +
                "    \"total_amount\":" + TotalAmount + "," +
                "    \"product_code\":\"" + method + "\"" +
                "  }";
                AlipayTradeWapPayResponse response = client.pageExecute(request);
                return HttpUtility.HtmlEncode(response.Body);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// APP调用支付宝支付
        /// </summary>
        /// <param name="Body">对一笔交易的具体描述信息</param>
        /// <param name="Subject">商品描述</param>
        /// <param name="TotalAmount">金额</param>
        /// <param name="OutTradeNo">商家唯一订单，填写你项目里生成的唯一订单号</param>
        /// <returns></returns>
        public static string APPAlipay(string Body,string Subject,string TotalAmount,string OutTradeNo)
        {
            try
            {                          
                string CHARSET = string.Empty;
                string QUICK_MSECURITY_PAY = string.Empty;
                IAopClient client = new DefaultAopClient("https://openapi.alipay.com/gateway.do", Ailconfig.APPID, Ailconfig.APP_PRIVATE_KEY, "json", "1.0", "RSA2", Ailconfig.ALIPAY_PUBLIC_KEY, CHARSET, false);
                //实例化具体API对应的request类,类名称和接口名称对应,当前调用接口名称如：alipay.trade.app.pay
                AlipayTradeAppPayRequest request = new AlipayTradeAppPayRequest();
                //SDK已经封装掉了公共参数，这里只需要传入业务参数。以下方法为sdk的model入参方式(model和biz_content同时存在的情况下取biz_content)。
                AlipayTradeAppPayModel paymodel = new AlipayTradeAppPayModel();
                paymodel.Body = Body;
                paymodel.Subject = Subject;
                paymodel.TotalAmount = TotalAmount;
                paymodel.ProductCode = QUICK_MSECURITY_PAY;
                paymodel.OutTradeNo = OutTradeNo;
                paymodel.TimeoutExpress = "30m";
                request.SetBizModel(paymodel);
                //外网商户可以访问的异步地址

                //这里和普通的接口调用不同，使用的是sdkExecute
                AlipayTradeAppPayResponse response = client.SdkExecute(request);
                //HttpUtility.HtmlEncode是为了输出到页面时防止被浏览器将关键参数html转义，实际打印到日志以及http传输不会有这个问题         
                return HttpUtility.HtmlEncode(response.Body);
                //页面输出的response.Body就是orderString 可以直接给客户端请求，无需再做处理。
            }
            catch (Exception ex) {
                throw;
            }
        }
    }
}
