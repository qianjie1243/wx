using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace WxTenpay.wxconfig.wxtenpay
{

    public class PayMent
    {

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
        /// <returns></returns>
        public Wx_pay APP_PayMent(string boby, string attach, string spbill_create_ip, Double total_fee, string out_trade_no, int type)
        {
            UnifiedOrder order = new UnifiedOrder();
            if (type == 1)
            {
                order.appid = APP_Aconfig.appid;
                order.mch_id = APP_Aconfig.partnerid;
            }
            else
            {
                order.appid = APP_Iconfig.appid;
                order.mch_id = APP_Iconfig.partnerid;
            }
            order.attach = attach;
            order.body = boby;
            order.device_info = "WEB";
            //order.mch_id = "";
            order.nonce_str = TenpayUtil.getNoncestr();

            if (type == 1)
            {
                order.notify_url = APP_Aconfig.url;
            }
            else
            {
                order.notify_url = APP_Iconfig.url;
            }

            //order.notify_url = APP_Aconfig.url;
            order.out_trade_no = out_trade_no;
            order.trade_type = "APP";
            order.spbill_create_ip = spbill_create_ip;
            order.total_fee = Convert.ToInt32((total_fee) * 100);
            TenpayUtil tenpay = new TenpayUtil();
            string paySignKey = string.Empty;
            if (type == 1)
            {
                paySignKey = APP_Aconfig.paysignkey;
            }
            else
            {
                paySignKey = APP_Iconfig.paysignkey;
            }
            string prepay_id = tenpay.getPrepay_id(order, paySignKey);
            string timeStamp = TenpayUtil.getTimestamp();
            string nonceStr = TenpayUtil.getNoncestr();
            SortedDictionary<string, object> sParams = new SortedDictionary<string, object>();
            sParams.Add("appid", order.appid);
            sParams.Add("partnerid", order.mch_id);
            sParams.Add("prepayid", prepay_id);
            sParams.Add("noncestr", nonceStr);
            sParams.Add("timestamp", timeStamp);
            sParams.Add("package", "Sign=WXPay");
            //  sParams.Add("signType", "MD5");
            string paySign = tenpay.getsign(sParams, paySignKey);
            Wx_pay wp = new Wx_pay();
            wp.appid = order.appid;
            wp.partnerid = order.mch_id;
            wp.noncestr = nonceStr;
            wp.prepayid = prepay_id;
            wp.sign = paySign;
            wp.timestamp = timeStamp;
            return wp;
        }
        #endregion

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
        /// <param name="product_id">二维码中包含的商品ID</param>
        /// <param name="attach">附加数据</param>
        /// <returns></returns>
        public string NATIVEPayMent(string boby, string attach, string spbill_create_ip, Double total_fee, string out_trade_no, string product_id)
        {
            UnifiedOrder order = new UnifiedOrder();
            order.appid = WXconfig.appid;
            order.attach = attach;
            order.body = boby;
            order.device_info = "";
            order.mch_id = WXconfig.mch_id;
            order.nonce_str = TenpayUtil.getNoncestr();
            order.notify_url = WXconfig.url;
            order.out_trade_no = out_trade_no;
            order.product_id = product_id;
            order.trade_type = "NATIVE";
            order.spbill_create_ip = spbill_create_ip;
            order.total_fee = Convert.ToInt32((total_fee) * 100);
            TenpayUtil tenpay = new TenpayUtil();
            string paySignKey = WXconfig.paysignkey;
            string code_url = tenpay.getcode_url(order, paySignKey);
            return code_url;
        }
        /// <summary>
        /// 获取支付订单状态（微信回调）
        /// </summary>
        /// <param name="GetInfoFromXml"></param>
        /// <returns></returns>
        public string PayMent_result(string xmlstring)
        {
            TenpayUtil tenpay = new TenpayUtil();
            return tenpay.GetXml(xmlstring);
        }
        /// <summary>
        /// 查询扫码订单情况
        /// </summary>
        /// <param name="out_trade_no">商户订单号</param>
        /// <returns></returns>
        public string GetPayMent_result(string out_trade_no)
        {
            TenpayUtil tenpay = new TenpayUtil();
            OrderDetail detail = tenpay.getOrderDetail(out_trade_no);


            if (detail.trade_state == "SUCCESS")//支付成功          
                return "SUCCESS";

            else if (detail.trade_state == "USERPAYING")//用户支付中 

                return "USERPAYING";
            //return "3";


            else if (detail.trade_state == "NOTPAY")//未支付 
            {
                return "NOTPAY";
                // return "2";

            }
            else if (detail.trade_state == "PAYERROR")//支付失败
            {
                return "PAYERROR";
                //return "4"; ;

            }
            else if (detail.err_code == "ORDERNOTEXIST")//订单不存在
            {
                return "ORDERNOTEXIST";

            }
            else if (detail.err_code == "SYSTEMERROR")
            {

                return "SYSTEMERROR";
            }
            else
            {

                return detail.trade_state; //其他状态
            }


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
        /// 
        /// <returns></returns>
        public String JSAPIPayMent(string boby, string attach, string openid, string spbill_create_ip, Double total_fee, string out_trade_no)
        {
            UnifiedOrder order = new UnifiedOrder();
            order.appid = WXconfig.appid;
            order.attach = attach;
            order.body = boby;
            order.device_info = "";
            order.mch_id = WXconfig.mch_id;
            order.nonce_str = TenpayUtil.getNoncestr();
            order.notify_url = WXconfig.url;
            order.openid = openid;
            order.out_trade_no = out_trade_no;
            order.trade_type = "JSAPI";
            order.spbill_create_ip = spbill_create_ip;
            order.total_fee = Convert.ToInt32((total_fee) * 100);
            TenpayUtil tenpay = new TenpayUtil();
            string paySignKey = WXconfig.paysignkey;
            string prepay_id = tenpay.getPrepay_id(order, paySignKey);
            string timeStamp = TenpayUtil.getTimestamp();
            string nonceStr = TenpayUtil.getNoncestr();
            SortedDictionary<string, object> sParams = new SortedDictionary<string, object>();
            sParams.Add("appId", WXconfig.appid);
            sParams.Add("timeStamp", timeStamp);
            sParams.Add("nonceStr", nonceStr);
            sParams.Add("package", "prepay_id=" + prepay_id);
            sParams.Add("signType", "MD5");
            string paySign = tenpay.getsign(sParams, paySignKey);
            string package = "prepay_id=" + prepay_id;
            return MD5Util.toJson(WXconfig.appid, timeStamp, nonceStr, package, "MD5", paySign);
        }
        #endregion

        #region 微信H5支付
        /// <summary>
        /// 微信H5支付
        /// </summary>
        /// <param name="boby">商品描述</param>
        /// <param name="mch_id">商户号</param>
        /// <param name="openid">场景信息</param>
        /// <param name="spbill_create_ip">终端IP</param>
        /// <param name="total_fee">金额</param>
        /// <param name="out_trade_no">商户订单号</param>
        ///  <param name="wap_url">WAP网站URL地址</param>
        ///   <param name="wap_name">WAP 网站名</param>
        /// <returns></returns>
        public string H5PayMent(string boby, string attach, string scene_info, string spbill_create_ip, Double total_fee, string wap_url, string wap_name)
        {
            UnifiedOrder order = new UnifiedOrder();
            order.appid = WXconfig.appid;
            order.attach = attach;
            order.body = boby;
            order.device_info = "";
            order.mch_id = WXconfig.mch_id;
            order.nonce_str = TenpayUtil.getNoncestr();
            order.notify_url = WXconfig.url;
            order.scene_info = "{\"h5_info\" {\"type\": \"Wap\", \"wap_url\": " + wap_url + ",\"wap_name\":" + wap_name + "}}";
            order.trade_type = "MWEB";
            order.spbill_create_ip = spbill_create_ip;
            order.total_fee = Convert.ToInt32((total_fee) * 100);
            TenpayUtil tenpay = new TenpayUtil();
            string paySignKey = WXconfig.paysignkey;
            string timeStamp = TenpayUtil.getTimestamp();
            string nonceStr = TenpayUtil.getNoncestr();
            return tenpay.H5PayMent(order, paySignKey);
        }
        #endregion 

        #region 微信公众号提现
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
        public String CashPayMent(string desc, string openid, string spbill_create_ip, Double total_fee, string partner_trade_no, string name)
        {
            Cash order = new Cash();
            order.mch_appid = WXconfig.appid;
            order.desc = desc;
            order.mch_id = WXconfig.mch_id;
            order.nonce_str = TenpayUtil.getNoncestr();
            order.openid = openid;
            order.partner_trade_no = partner_trade_no;
            order.spbill_create_ip = spbill_create_ip;
            order.amount = Convert.ToInt32((total_fee) * 100);
            order.check_name = "FORCE_CHECK";
            order.re_user_name = name;
            TenpayUtil tenpay = new TenpayUtil();
            string result = tenpay.getCash(order);
            return result;
        }
        #endregion

        #region 微信公众号现金红包
        /// <summary>
        /// 微信公众号现金红包
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
        public string PayCashbonus(string mch_billno, string send_name, string re_openid, double total_amount, int total_num, string wishing, string client_ip, string act_name, string remark)
        {
            string result = string.Empty;
            WxPayData wxpay = new WxPayData();
            wxpay.act_name = act_name;
            wxpay.client_ip = client_ip;
            wxpay.mch_billno = mch_billno;
            wxpay.mch_id = WXconfig.mch_id;
            wxpay.nonce_str= TenpayUtil.getNoncestr();
            wxpay.remark = remark;
            wxpay.re_openid = re_openid;
            wxpay.send_name = send_name;
            wxpay.total_amount =Convert.ToInt32((total_amount)*100);
            wxpay.total_num = total_num;
            wxpay.wishing = wishing;
            wxpay.wxappid = WXconfig.appid;
            TenpayUtil tenpay = new TenpayUtil();
            result = tenpay.getPayCashbonus(wxpay);
            return result;
        }
        #endregion 

        #region 微信退款
        /// <summary>
        /// 微信退款
        /// </summary>
        /// <param name="out_refund_no">商户退款单号</param>
        /// <param name="out_trade_no">微信订单号和商户订单号 （二选一）</param>
        /// <param name="refund_fee">退款金额</param>
        /// <param name="transaction_id">微信订单号和商户订单号 （二选一）</param>
        /// <param name="total_fee">订单金额</param>
        /// <param name="refund_desc">退款原因</param>
        /// <param name="type">退款类型1微信公众号 2：APP退款</param>
        /// <returns></returns>
        public string Get_Refund(string out_refund_no, string out_trade_no, double refund_fee, string transaction_id, double total_fee, string refund_desc, int type = 1)
        {
            if (type == 1)
            {
                refund order = new refund();
                order.appid = WXconfig.appid;
                order.mch_id = WXconfig.paysignkey;
                order.nonce_str = TenpayUtil.getNoncestr();
                order.out_refund_no = out_refund_no;
                order.out_trade_no = out_trade_no;
                order.refund_fee = (refund_fee * 100).ToString();
                order.total_fee = (total_fee * 100).ToString();
                order.transaction_id = transaction_id;
                TenpayUtil tenpay = new TenpayUtil();
                SortedDictionary<string, object> sParams = new SortedDictionary<string, object>();
                sParams.Add("appId", WXconfig.appid);
                sParams.Add("mch_id", WXconfig.mch_id);
                sParams.Add("nonce_str", TenpayUtil.getNoncestr());
                sParams.Add("notify_url", WXconfig.url);
                sParams.Add("out_refund_no", out_refund_no);
                sParams.Add("out_trade_no", out_trade_no);
                sParams.Add("refund_fee", (refund_fee * 100).ToString());
                sParams.Add("transaction_id", transaction_id);
                sParams.Add("total_fee", (total_fee * 100).ToString());
                sParams.Add("refund_account", "REFUND_SOURCE_UNSETTLED_FUNDS");
                sParams.Add("refund_desc", refund_desc);
                sParams.Add("refund_fee_type", "CNY");
                sParams.Add("sign_type", "MD5");
                string sign = tenpay.getsign(sParams, WXconfig.paysignkey);
                order.sign = sign;
                return tenpay.getRefund(order);
            }
            else
            {
                refund order = new refund();
                order.appid = APP_Iconfig.appid;
                order.mch_id = APP_Iconfig.paysignkey;
                order.nonce_str = TenpayUtil.getNoncestr();
                order.out_refund_no = out_refund_no;
                order.out_trade_no = out_trade_no;
                order.refund_fee = (refund_fee * 100).ToString();
                order.total_fee = (total_fee * 100).ToString();
                order.transaction_id = transaction_id;
                TenpayUtil tenpay = new TenpayUtil();
                SortedDictionary<string, object> sParams = new SortedDictionary<string, object>();
                sParams.Add("appId", APP_Iconfig.appid);
                sParams.Add("mch_id", APP_Iconfig.mch_id);
                sParams.Add("nonce_str", TenpayUtil.getNoncestr());
                sParams.Add("notify_url", APP_Iconfig.url);
                sParams.Add("out_refund_no", out_refund_no);
                sParams.Add("out_trade_no", out_trade_no);
                sParams.Add("refund_fee", (refund_fee * 100).ToString());
                sParams.Add("transaction_id", transaction_id);
                sParams.Add("total_fee", (total_fee * 100).ToString());
                sParams.Add("refund_account", "REFUND_SOURCE_UNSETTLED_FUNDS");
                sParams.Add("refund_desc", refund_desc);
                sParams.Add("refund_fee_type", "CNY");
                sParams.Add("sign_type", "MD5");
                string sign = tenpay.getsign(sParams, APP_Iconfig.paysignkey);
                order.sign = sign;
                return tenpay.getRefund(order);
            }
        }
        #endregion
    }
}
