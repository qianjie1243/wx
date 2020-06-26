using AliYun.AliYun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WxTenpay
{
    /// <summary>
    /// 支付宝支付类
    /// </summary>
    public class AilPay
    {
        /// <summary>
        /// H5支付
        /// </summary>
        /// <param name="Body">对一笔交易的具体描述信息</param>
        /// <param name="Subject">商品描述</param>
        /// <param name="TotalAmount">金额</param>
        /// <param name="OutTradeNo">商家唯一订单，填写你项目里生成的唯一订单号</param>
        /// <returns></returns>
        public  string H5Alipay(string Body, string Subject, string TotalAmount, string OutTradeNo)
        {
            try
            {
                return Ail_Pay.H5Alipay(Body, Subject, TotalAmount, OutTradeNo);
            }
            catch {
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
        public  string APPAlipay(string Body, string Subject, string TotalAmount, string OutTradeNo)
        {
            try
            {
                return Ail_Pay.APPAlipay(Body, Subject, TotalAmount, OutTradeNo);
            }
            catch {
                throw;
            }
        }

    }
}
