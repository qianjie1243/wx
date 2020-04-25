using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxTenpay.WXoperation;
using WxTenpay.WXoperation.wxtenpay;

namespace WxTenpay
{

    /// <summary>
    /// 微信支付类
    /// </summary>
    public class WeChatPayment
    {
        /// <summary>
        /// 加载配置文件
        /// </summary>
        public WeChatPayment()
        {
            GetConfig.ResetConfig();
        }

        PayMent pm = new PayMent();

        #region 微信扫码支付====(已测试)
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
        public string NATIVEPayMent(string boby, string attach, string spbill_create_ip, Double total_fee, string out_trade_no, string product_id)
        {
            try
            {
                return pm.NATIVEPayMent(boby, attach, spbill_create_ip, total_fee, out_trade_no, product_id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion 

        #region 微信APP支付====(已测试)
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
            try
            {
                return pm.APP_PayMent(boby, attach, spbill_create_ip, total_fee, out_trade_no, type);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region 微信公众号支付====(已测试)
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
        public string JSAPIPayMent(string boby, string attach, string openid, string spbill_create_ip, Double total_fee, string out_trade_no)
        {
            try
            {
                return pm.JSAPIPayMent(boby, attach, openid, spbill_create_ip, total_fee, out_trade_no);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region 微信H5支付====(待测试)
        /// <summary>
        /// 微信H5支付(支持web APP不支持APP内H5支付请接入支付)
        /// </summary>
        /// <param name="boby">商品描述</param>
        /// <param name="attach">附加数据</param>
        /// <param name="scene_info">场景信息</param>
        /// <param name="spbill_create_ip">终端IP</param>
        /// <param name="total_fee">金额</param>
        /// <param name="out_trade_no">商户订单号</param>
        ///  <param name="wap_url">WAP网站URL地址</param>
        ///   <param name="wap_name">WAP 网站名</param>
        /// <returns></returns>
        public string H5PayMent(string boby, string attach, string scene_info, string spbill_create_ip, Double total_fee, string wap_url, string wap_name)
        {
            try
            {
                return pm.H5PayMent(boby, attach, scene_info, spbill_create_ip, total_fee, wap_url, wap_name);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        #endregion

        #region 微信小程序支付====(待测试)
        /// <summary>
        /// 微信小程序支付
        /// </summary>
        /// <param name="boby">商品描述</param>
        /// <param name="mch_id">商户号</param>     
        /// <param name="spbill_create_ip">终端IP</param>
        /// <param name="total_fee">金额</param>
        /// <param name="out_trade_no">商户订单号</param>
        /// 
        /// <returns></returns>
        public string JSAPISmallProgram(string boby, string attach, string spbill_create_ip, Double total_fee, string out_trade_no)
        {
            try
            {
                return pm.JSAPISmallProgram(boby, attach, spbill_create_ip, total_fee, out_trade_no);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        #endregion

        #region  微信公众号现金红包功能====(待测试)
        /// <summary>
        /// 微信公众号现金红包功能
        /// </summary>
        ///  <param name="mch_billno">客户订单号</param>
        /// <param name="send_name">商户名称</param>
        /// <param name="re_openid">用户openid</param>
        /// <param name="total_amount">付款金额</param>
        /// <param name="total_num">红包发放总人数</param>
        /// <param name="wishing">红包祝福语</param>
        /// <param name="client_ip">Ip地址</param>
        /// <param name="act_name">活动名称</param>
        /// <param name="remark">备注</param>
        /// <returns></returns>
        public string PayCash_bonus(string mch_billno, string send_name, string re_openid, double total_amount, int total_num, string wishing, string client_ip, string act_name, string remark)
        {

            try
            {
                return pm.PayCashbonus(mch_billno, send_name, re_openid, total_amount, total_num, wishing, client_ip, act_name, remark);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        #endregion

        #region 微信公众号提现功能====(待测试)
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
            try
            {
                return pm.CashPayMent(desc, openid, spbill_create_ip, total_fee, partner_trade_no, name);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        #endregion

        #region 微信退款功能====(待测试)
        /// <summary>
        /// 微信退款
        /// </summary>
        /// <param name="out_refund_no">商户退款单号</param>
        /// <param name="out_trade_no">商户订单号 （二选一）商户订单号和微信订单号</param>
        /// <param name="refund_fee">退款金额</param>
        /// <param name="transaction_id">微信订单号 （二选一）商户订单号和微信订单号</param>
        /// <param name="total_fee">订单金额</param>
        /// <param name="refund_desc">退款原因</param>
        /// <param name="type">退款类型1微信公众号 2：APP退款(默认微信公众号)</param>
        [Description("微信退款功能")]
        public string Get_Refund(string out_refund_no, string out_trade_no, double refund_fee, string transaction_id, double total_fee, string refund_desc, int type)
        {
            try
            {
                return pm.Get_Refund(out_refund_no, out_trade_no, refund_fee, transaction_id, total_fee, refund_desc, type);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        #endregion

        #region 微信支付订单基本操作

        #region 查询扫码订单情况====(已测试)
        /// <summary>
        /// 查询扫码订单情况
        /// </summary>
        /// <param name="out_trade_no">商户订单号</param>
        /// <returns></returns>
        [Description("查询扫码订单情况")]
        public string GetPayMent_result(string out_trade_no)
        {
            try
            {
                return pm.GetPayMent_result(out_trade_no);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        #endregion 

        #region 获取支付订单状态（微信回调）====(已测试)
        /// <summary>
        /// 获取支付订单状态（微信回调）
        /// </summary>
        /// <param name="xmlstring">微信回调数据</param>
        /// <param name="type">微信回调数据返回的结果, 0：result_code的值 ,客户订单号</param>
        /// <returns></returns>
        [Description("获取支付订单状态（微信回调）")]
        public dynamic PayMent_result(string xmlstring, int type = 0)
        {
            try
            {
                return pm.PayMent_result(xmlstring, type);
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        #endregion

        #region 通知微信已收到XML回调通知
        /// <summary>
        /// 通知微信已收到XML回调通知
        /// </summary>
        public void Inform()
        {
            try
            {
                var result = $@"<xml> 
                            <return_code><![CDATA[SUCCESS]]></return_code>
                            <return_msg><![CDATA[OK]]></return_msg>
                            </xml> ";
                System.Web.HttpContext.Current.Response.Write(result);
                System.Web.HttpContext.Current.Response.End();
            }
            catch
            {
                throw;
            }
        }

        #endregion 
        #endregion
    }
}
