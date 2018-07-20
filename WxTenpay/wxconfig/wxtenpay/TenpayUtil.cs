using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Xml;
//using System.Web.Script.Serialization;

namespace WxTenpay.wxconfig.wxtenpay
{
    public    class TenpayUtil
    {
        #region url
        /// <summary>
        /// 统一支付接口
        /// </summary>
        const string UnifiedPayUrl = "https://api.mch.weixin.qq.com/pay/unifiedorder";

        /// <summary>
        /// 网页授权接口
        /// </summary>
        const string access_tokenUrl = "https://api.weixin.qq.com/sns/oauth2/access_token";


        /// <summary>
        /// 提现接口
        /// </summary>
        const string CashPayUrl = "https://api.mch.weixin.qq.com/mmpaymkttransfers/promotion/transfers";

       
        /// <summary>
        /// 微信订单查询接口
        /// </summary>
        const string OrderQueryUrl = "https://api.mch.weixin.qq.com/pay/orderquery";

        #endregion

        #region 随机串,时间截
        /// <summary>
        /// 随机串
        /// </summary>
        public static string getNoncestr()
        {
            Random random = new Random();
            return MD5Util.GetMD5(random.Next(1000).ToString(), "GBK").ToLower().Replace("s", "S");
        }


        /// <summary>
        /// 时间截，自1970年以来的秒数
        /// </summary>
        public static string getTimestamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        #endregion

        /// <summary>
        /// 网页授权接口
        /// </summary>
        public static string getAccess_tokenUrl()
        {
            return access_tokenUrl;
        }


        #region 把微信扫码支付的回调XML转换集合
        public string GetXml(string xmlstring) {
            Log.WriteLog1(xmlstring, "微信回调");
            SortedDictionary < string, object> sd= GetInfoFromXml(xmlstring);
            string reslut = "";
            foreach (KeyValuePair<string, object> s in sd) {
                if (s.Key == "result_code") {
                    reslut= s.Value.ToString();
                }
            }
            return reslut;
        }
        #endregion

        #region 获取微信签名
        /// <summary>
        /// 获取微信签名
        /// </summary>
        /// <param name="sParams"></param>
        /// <returns></returns>
        public string getsign(SortedDictionary<string, object> sParams, string key)
        {
            int i = 0;
            string sign = string.Empty;
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, object> temp in sParams)
            {
                if (temp.Value.ToString() == "" || temp.Value == null || temp.Key.ToLower() == "sign")
                {
                    continue;
                }
                i++;
                sb.Append(temp.Key.Trim() + "=" + temp.Value.ToString() + "&");
            }
            sb.Append("key=" + key.Trim() + "");
            string signkey = sb.ToString();
            sign = MD5Util.GetMD5(signkey, "utf-8");
            //utf-8

            return sign;
        }

        #endregion

        #region post数据到指定接口并返回数据

        /// <summary>
        /// post数据到指定接口并返回数据
        /// </summary>
        public string PostXmlToUrl(string url, string postData,string type="")
        {
            string returnmsg = "";
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {                      
                if (type != "") {
                     Encoding encoding = Encoding.UTF8;
                    wc.Encoding = System.Text.Encoding.GetEncoding("GB2312");
                    byte[] data = encoding.GetBytes(postData);
                    returnmsg = Encoding.UTF8.GetString(wc.UploadData(url, "POST", data));
                }
                else 
                 returnmsg = wc.UploadString(url, "POST", postData);
            }
            return returnmsg;
        }

        #endregion

        #region 获取code_url
        /// <summary>
        /// 获取code_url
        /// </summary>
        public string getcode_url(UnifiedOrder order, string key)
        {
            string code_url = "";

            string post_data = getUnifiedOrderXml(order, key);
            string request_data = PostXmlToUrl(UnifiedPayUrl, post_data);
            //string request_data = HttpRequestutil.RequestUrl(UnifiedPayUrl, post_data, "post");
           Log.WriteLog1(request_data);

            SortedDictionary<string, object> requestXML = GetInfoFromXml(request_data);

            foreach (KeyValuePair<string, object> k in requestXML)
            {


                if (k.Key == "code_url")
                {
                    code_url = k.Value.ToString();
                    break;
                }
            }
            return code_url;
        }

        #endregion

        #region 获取prepay_id

        /// <summary>
        /// 获取prepay_id
        /// </summary>
        public string getPrepay_id(UnifiedOrder order, string key)
        {
            string prepay_id = "";
            
                string post_data = getUnifiedOrderXml(order, key);
                string request_data = PostXmlToUrl(UnifiedPayUrl, post_data);
               
           Log.WriteLog1(request_data);

                SortedDictionary<string, object> requestXML = GetInfoFromXml(request_data);

                foreach (KeyValuePair<string, object> k in requestXML)
                {
               
                    
                    if (k.Key == "prepay_id")
                    {
                        prepay_id = k.Value.ToString();
                        break;
                    }
                }          
            return prepay_id;
        }

        #endregion


        #region 微信提现返回结果

        /// <summary>
        /// 微信提现返回结果
        /// </summary>
        public string getCash(Cash order)
        {
            string prepay_id = "";
            string return_msg = "";
            int Code = 0;
            string return_string = string.Empty;

            #region 请求提现
            SortedDictionary<string, object> sParams = new SortedDictionary<string, object>();
            sParams.Add("mch_appid", order.mch_appid);
            sParams.Add("mch_id", order.mch_id);
            sParams.Add("nonce_str", order.nonce_str);
            sParams.Add("partner_trade_no", order.partner_trade_no);
            sParams.Add("openid", order.openid);
            sParams.Add("check_name", order.check_name);
            sParams.Add("amount", order.amount);
            sParams.Add("desc", order.desc);
            sParams.Add("re_user_name", order.re_user_name);
            sParams.Add("spbill_create_ip", order.spbill_create_ip);
            string paySign = getsign(sParams, WXconfig.paysignkey);
            sParams.Add("sign", paySign);
            //拼接成XML请求数据
            StringBuilder sbPay = new StringBuilder();
            foreach (KeyValuePair<string, object> k in sParams)
            {
                if (k.Key == "sign")
                {
                    sbPay.Append("<" + k.Key + "><![CDATA[" + k.Value + "]]></" + k.Key + ">");
                }
                else
                {
                    sbPay.Append("<" + k.Key + ">" + k.Value + "</" + k.Key + ">");
                }
            }
            return_string = string.Format("<xml>{0}</xml>", sbPay.ToString());
            byte[] byteArray = Encoding.UTF8.GetBytes(return_string);
            return_string = Encoding.GetEncoding("GBK").GetString(byteArray);
            string request_data = PostXmlToUrl(CashPayUrl, return_string, "1");
            #endregion
            Log.WriteLog1(request_data, "微信提现");

            SortedDictionary<string, object> requestXML = GetInfoFromXml(request_data);

            foreach (KeyValuePair<string, object> k in requestXML)
            {
                if (k.Key == "return_msg")
                {
                    if (k.Value.ToString() != "")
                    {
                        return_msg = k.Value.ToString();

                    }
                }
                else if (k.Key == "partner_trade_no")
                {
                    prepay_id = k.Value.ToString();
                    Code = 1;

                }
                else if (k.Key == "payment_no")
                {
                    prepay_id += "," + k.Value.ToString();

                }
                else if (k.Key == "payment_time")
                {
                    prepay_id += "," + k.Value.ToString();

                }
                else if (k.Key == "err_code")
                {
                    #region 错误信息
                    if (k.Value.ToString() != "" && k.Value != null)
                    {
                        switch (k.Value.ToString())
                        {
                            case "NO_AUTH":
                                return_msg += "-没有该接口权限";
                                break;
                            case "AMOUNT_LIMIT":
                                return_msg += "-金额超限";
                                break;
                            case "PARAM_ERROR":
                                return_msg += "-参数错误";
                                break;
                            case "OPENID_ERROR":
                                return_msg += "-Openid错误";
                                break;
                            case "SEND_FAILED":
                                return_msg += "-付款错误";
                                break;
                            case "NOTENOUGH":
                                return_msg += "-余额不足";
                                break;
                            case "SYSTEMERROR":
                                return_msg += "-系统繁忙，请稍后再试";
                                break;
                            case "NAME_MISMATCH":
                                return_msg += "-姓名校验出错";
                                break;
                            case "SIGN_ERROR":
                                return_msg += "-签名错误";
                                break;
                            case "XML_ERROR":
                                return_msg += "-Post内容出错";
                                break;
                            case "FATAL_ERROR":
                                return_msg += "-两次请求参数不一致";
                                break;
                            case "FREQ_LIMIT":
                                return_msg += "-超过频率限制，请稍后再试";
                                break;
                            case "MONEY_LIMIT":
                                return_msg += "-已经达到今日付款总额上限/已达到付款给此用户额度上限";
                                break;
                            case "CA_ERROR":
                                return_msg += "-商户API证书校验出错";
                                break;
                            case "V2_ACCOUNT_SIMPLE_BAN":
                                return_msg += "-无法给非实名用户付款";
                                break;
                            case "PARAM_IS_NOT_UTF8":
                                return_msg += "-请求参数中包含非utf8编码字符";
                                break;
                            case "SENDNUM_LIMIT":
                                return_msg += "-该用户今日付款次数超过限制,如有需要请登录微信支付商户平台更改API安全配置";
                                break;
                        }
                        #endregion 
                    }
                }
            }


            return "{\"Code\": " + Code + ", \"msg\": \"" + prepay_id + "\", \"Message\": \"" + return_msg + "\"}";
        }

        #endregion

     

        #region 获取微信订单明细
        /// <summary>
        /// 获取微信订单明细
        /// </summary>
        public OrderDetail getOrderDetail(string out_trade_no)
        {
            string post_data = getQueryOrderXml(out_trade_no);
            string request_data = PostXmlToUrl(OrderQueryUrl, post_data,"1");
            OrderDetail orderdetail = new OrderDetail();
            SortedDictionary<string, object> requestXML = GetInfoFromXml(request_data);
            foreach (KeyValuePair<string, object> k in requestXML)
            {
                switch (k.Key)
                {
                    case "retuen_code":
                        orderdetail.result_code = k.Value.ToString();
                        break;
                    case "return_msg":
                        orderdetail.return_msg = k.Value.ToString();
                        break;
                    case "appid":
                        orderdetail.appid = k.Value.ToString();
                        break;
                    case "mch_id":
                        orderdetail.mch_id = k.Value.ToString();
                        break;
                    case "nonce_str":
                        orderdetail.nonce_str = k.Value.ToString();
                        break;
                    case "sign":
                        orderdetail.sign = k.Value.ToString();
                        break;
                    case "result_code":
                        orderdetail.result_code = k.Value.ToString();
                        break;
                    case "err_code":
                        orderdetail.err_code = k.Value.ToString();
                        break;
                    case "err_code_des":
                        orderdetail.err_code_des = k.Value.ToString();
                        break;
                    case "trade_state":
                        orderdetail.trade_state = k.Value.ToString();
                        break;
                    case "device_info":
                        orderdetail.device_info = k.Value.ToString();
                        break;
                    case "openid":
                        orderdetail.openid = k.Value.ToString();
                        break;
                    case "is_subscribe":
                        orderdetail.is_subscribe = k.Value.ToString();
                        break;
                    case "trade_type":
                        orderdetail.trade_type = k.Value.ToString();
                        break;
                    case "bank_type":
                        orderdetail.bank_type = k.Value.ToString();
                        break;
                    case "total_fee":
                        orderdetail.total_fee = k.Value.ToString();
                        break;
                    case "coupon_fee":
                        orderdetail.coupon_fee = k.Value.ToString();
                        break;
                    case "fee_type":
                        orderdetail.fee_type = k.Value.ToString();
                        break;
                    case "transaction_id":
                        orderdetail.transaction_id = k.Value.ToString();
                        break;
                    case "out_trade_no":
                        orderdetail.out_trade_no = k.Value.ToString();
                        break;
                    case "attach":
                        orderdetail.attach = k.Value.ToString();
                        break;
                    case "time_end":
                        orderdetail.time_end = k.Value.ToString();
                        break;               
                    default:
                        break;
                }
            }
            return orderdetail;
        }
        #endregion



        #region 

        #region 把XML数据转换为SortedDictionary

        /// <summary>
        /// 把XML数据转换为SortedDictionary<string, string>集合
        /// </summary>
        /// <param name="strxml"></param>
        /// <returns></returns>
        protected SortedDictionary<string, object> GetInfoFromXml(string xmlstring)
        {
            SortedDictionary<string, object> sParams = new SortedDictionary<string, object>();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xmlstring);
                XmlElement root = doc.DocumentElement;
                int len = root.ChildNodes.Count;
                for (int i = 0; i < len; i++)
                {
                    string name = root.ChildNodes[i].Name;
                    if (!sParams.ContainsKey(name))
                    {
                        sParams.Add(name.Trim(), root.ChildNodes[i].InnerText.Trim());
                    }
                }
            }
            catch(Exception ex ) {

            }
            return sParams;
        }

        #endregion

        #region 微信统一下单接口xml参数整理
        /// <summary>
        /// 微信统一下单接口xml参数整理
        /// </summary>
        /// <param name="order">微信支付参数实例</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        protected string getUnifiedOrderXml(UnifiedOrder order, string key)
        {
            string return_string = string.Empty;
            SortedDictionary<string, object> sParams = new SortedDictionary<string, object>();
            sParams.Add("appid", order.appid);
            sParams.Add("attach", order.attach);
            sParams.Add("body", order.body);
            sParams.Add("device_info", order.device_info);
            sParams.Add("mch_id", order.mch_id);
            sParams.Add("nonce_str", order.nonce_str);
            sParams.Add("notify_url", order.notify_url);
            //当 trade_type=JSAPI 时必输入
            if (order.trade_type == "JSAPI")
            {
                sParams.Add("openid", order.openid);
            }
            else if (order.trade_type == "NATIVE")
            {
                //当 trade_type=NATIVE 时必输入
                sParams.Add("product_id", order.product_id);
            }
            sParams.Add("out_trade_no", order.out_trade_no);
            sParams.Add("spbill_create_ip", order.spbill_create_ip);
            sParams.Add("total_fee", order.total_fee);
            sParams.Add("trade_type", order.trade_type);
            order.sign = getsign(sParams, key);
            sParams.Add("sign", order.sign);
           
            //拼接成XML请求数据
            StringBuilder sbPay = new StringBuilder();
            foreach (KeyValuePair<string, object> k in sParams)
            {
                if (k.Key == "attach" || k.Key == "body" || k.Key == "sign")
                {
                    sbPay.Append("<" + k.Key + "><![CDATA[" + k.Value + "]]></" + k.Key + ">");
                }
                else
                {
                    sbPay.Append("<" + k.Key + ">" + k.Value + "</" + k.Key + ">");
                }
            }
            return_string = string.Format("<xml>{0}</xml>", sbPay.ToString());
            byte[] byteArray = Encoding.UTF8.GetBytes(return_string);
            return_string = Encoding.GetEncoding("GBK").GetString(byteArray);
            Byte[] temp = Encoding.UTF8.GetBytes(return_string);
            string dataGBK = Encoding.GetEncoding("utf-8").GetString(temp);         
            return return_string;
            //  GBK
        }

        #endregion

        #region 微信订单查询接口XML参数整理
        /// <summary>
        /// 微信订单查询接口XML参数整理
        /// </summary>
        /// <param name="queryorder">微信订单查询参数实例</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        protected string getQueryOrderXml(string out_trade_no)
        {
            string return_string = string.Empty;
            SortedDictionary<string, object> sParams = new SortedDictionary<string, object>();
            sParams.Add("appid", WXconfig.appid);
            sParams.Add("mch_id", WXconfig.mch_id);
           // sParams.Add("transaction_id", queryorder.transaction_id);
            sParams.Add("out_trade_no", out_trade_no);
            sParams.Add("nonce_str", getNoncestr());
           string  sign = getsign(sParams, WXconfig.paysignkey);
            sParams.Add("sign", sign);

            //拼接成XML请求数据
            StringBuilder sbPay = new StringBuilder();
            foreach (KeyValuePair<string, object> k in sParams)
            {
                if (k.Key == "attach" || k.Key == "body" || k.Key == "sign")
                {
                    sbPay.Append("<" + k.Key + "><![CDATA[" + k.Value + "]]></" + k.Key + ">");
                }
                else
                {
                    sbPay.Append("<" + k.Key + ">" + k.Value + "</" + k.Key + ">");
                }
            }
            return_string = string.Format("<xml>{0}</xml>", sbPay.ToString().TrimEnd(','));
            return return_string;
        }
        #endregion 

        #endregion
    }
}