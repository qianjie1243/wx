using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxTenpay.wxconfig;
using WxTenpay.wxconfig.wxtenpay;
namespace WxTenpay
{
    [Description("微信支付类")]
    public class WeChatPayment
    {
        PayMent pm = new PayMent();

        #region 微信扫码支付
        /// <summary>
        /// 微信扫码支付
        /// </summary>
        /// <param name="appid">公众号ID</param>
        /// <param name="boby">商品描述</param>
        /// <param name="mch_id">商户号</param>
        /// <param name="spbill_create_ip">终端IP</param>
        /// <param name="total_fee">金额</param>
        /// <param name="out_trade_no">商户订单号</param>
        /// <param name="attach">附加数据</param>
        /// <param name="product_id">二维码中包含的商品ID</param>
        /// <returns></returns>
        [Description("微信扫码支付")]
        public string NATIVEPayMent(string boby, string attach,string spbill_create_ip, Double total_fee, string out_trade_no, string product_id)
        {
            return pm.NATIVEPayMent(boby, attach, spbill_create_ip, total_fee, out_trade_no, product_id);
        }
        /// <summary>
        /// 查询扫码订单情况
        /// </summary>
        /// <param name="out_trade_no">商户订单号</param>
        /// <returns></returns>
        [Description("查询扫码订单情况")]
        public string GetPayMent_result(string out_trade_no)
        {
            return pm.GetPayMent_result(out_trade_no);
        }
        /// <summary>
        /// 获取支付订单状态（微信回调）
        /// </summary>
        /// <param name="xmlstring">微信回调数据</param>
        /// <returns></returns>
        [Description("获取支付订单状态（微信回调）")]
        public string PayMent_result(string xmlstring)
        {
            return pm.PayMent_result(xmlstring);
        }
        #endregion

        #region 微信APP支付
        /// <summary>
        /// 微信APP支付
        /// </summary>
        /// <param name="boby">商品描述</param>
        /// <param name="mch_id">商户号</param>
        /// <param name="openid">用户openid</param>
        /// <param name="spbill_create_ip">终端IP</param>
        /// <param name="total_fee">金额</param>
        /// <param name="out_trade_no">商户订单号</param>
        /// <param name="attach">附加数据</param> 
        /// <param name="type">APP类型1.安卓，2.IOS</param> 
        /// <returns></returns>
        [Description("微信APP支付")]
        public Wx_pay APP_PayMent(string boby, string attach, string spbill_create_ip, Double total_fee, string out_trade_no, int type)
        {
            return pm.APP_PayMent(boby, attach, spbill_create_ip, total_fee, out_trade_no, type);
        }
        #endregion

        #region 微信公众号支付
        /// <summary>
        /// 微信支付
        /// </summary>
        /// <param name="appid">公众号ID</param>
        /// <param name="boby">商品描述</param>
        /// <param name="mch_id">商户号</param>
        /// <param name="openid">用户openid</param>
        /// <param name="spbill_create_ip">终端IP</param>
        /// <param name="total_fee">金额</param>
        /// <param name="out_trade_no">商户订单号</param> 
        /// <returns></returns>
        [Description("微信公众号支付")]
        public String JSAPIPayMent(string boby, string attach, string openid, string spbill_create_ip, Double total_fee, string out_trade_no)
        {
            return pm.JSAPIPayMent(boby, attach, openid, spbill_create_ip, total_fee, out_trade_no);
        }
        #endregion

        #region 微信公众号提现功能
        /// <summary>
        /// 微信提现
        /// </summary>
        /// <param name="appid">公众号ID</param>
        /// <param name="boby">商品描述</param>
        /// <param name="mch_id">商户号</param>
        /// <param name="openid">用户openid</param>
        /// <param name="spbill_create_ip">终端IP</param>
        /// <param name="total_fee">金额</param>
        /// <param name="partner_trade_no">商户订单号</param>
        /// <param name="name">提现人的真实姓名</param>
        /// <returns></returns>  
        [Description("微信公众号提现功能")]
        public String CashPayMent(string desc, string openid, string spbill_create_ip, Double total_fee, string partner_trade_no, string name)
        {
            return pm.CashPayMent(desc, openid, spbill_create_ip, total_fee, partner_trade_no, name);
        }
        #endregion

    }
}
