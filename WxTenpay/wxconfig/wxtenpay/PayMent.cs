using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace WxTenpay.wxconfig.wxtenpay
{
   
   public  class PayMent
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
        public Wx_pay APP_PayMent( string boby, string attach, string spbill_create_ip, Double total_fee, string out_trade_no,int type)
       {
           UnifiedOrder order = new UnifiedOrder();
            if (type == 1)
            {               
                    order.appid = APP_Aconfig.appid;
                    order.mch_id = APP_Aconfig.partnerid;            
            }
            else {                         
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
            else {             
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
        public string NATIVEPayMent (string boby,string attach , string spbill_create_ip, Double total_fee, string out_trade_no, string product_id)
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
        public string PayMent_result(string xmlstring) {
            TenpayUtil tenpay = new TenpayUtil();
           return  tenpay.GetXml(xmlstring);
        }
        /// <summary>
        /// 查询扫码订单情况
        /// </summary>
        /// <param name="out_trade_no">商户订单号</param>
        /// <returns></returns>
        public string  GetPayMent_result(string out_trade_no)
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
        public String JSAPIPayMent(string boby,string attach, string openid, string spbill_create_ip, Double total_fee, string out_trade_no)
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

    }
}
