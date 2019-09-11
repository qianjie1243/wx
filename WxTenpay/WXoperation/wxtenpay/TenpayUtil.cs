using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.IO;
using System.Net.Security;

using WxTenpay.WXoperation.Common;
//using System.Web.Script.Serialization;

namespace WxTenpay.WXoperation.wxtenpay
{
    public class TenpayUtil
    {
        #region url==================================
        /// <summary>
        /// 统一支付接口
        /// </summary>
        const string UnifiedPayUrl = "https://api.mch.weixin.qq.com/pay/unifiedorder";

        /// <summary>
        /// 网页授权接口
        /// </summary>
        const string access_tokenUrl = "https://api.weixin.qq.com/sns/oauth2/access_token";
        /// <summary>
        /// 微信退款接口
        /// </summary>
        const string refund_Url = "https://api.mch.weixin.qq.com/secapi/pay/refund";
        /// <summary>
        /// 提现接口
        /// </summary>
        const string CashPayUrl = "https://api.mch.weixin.qq.com/mmpaymkttransfers/promotion/transfers";
        /// <summary>
        /// 微信公众号现金红包接口
        /// </summary>
        const string PayCashbonus = "https://api.mch.weixin.qq.com/mmpaymkttransfers/sendredpack";
        /// <summary>
        /// 微信订单查询接口
        /// </summary>
        const string OrderQueryUrl = "https://api.mch.weixin.qq.com/pay/orderquery";
        /// <summary>
        /// 微信H5支付
        /// </summary>
        const string H5PayMentUrl = "https://api.mch.weixin.qq.com/pay/unifiedorder";
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
        /// <summary>
        /// 把微信扫码支付的回调XML转换集合
        /// </summary>
        /// <param name="xmlstring"></param>
        /// <param name="type">微信回调数据返回的结果, 0：result_code的值,客户订单号</param>
        /// <returns></returns>
        public object GetXml(string xmlstring, int type)
        {
            Log.WriteLogFile(xmlstring, "微信回调");
            SortedDictionary<string, object> sd = GetInfoFromXml(xmlstring);
            string result_code = "";
            string out_trade_no = "";
            switch (type) {
                case 0:
                    foreach (KeyValuePair<string, object> s in sd)
                    {
                        if (s.Key == "result_code")
                        {
                            result_code = s.Value.ToString();
                        }
                        if (s.Key == "out_trade_no")
                        {
                            out_trade_no = s.Value.ToString();
                        }
                    }
                    return new { result_code = result_code, out_trade_no = out_trade_no };                             
                default:
                   return sd;
            }
           
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
        public string PostXmlToUrl(string url, string postData, string type = "")
        {
            string returnmsg = "";
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                if (type != "")
                {
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

        /// <summary>
        /// 微信需要证书接口
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postdata"></param>
        /// <returns></returns>
        public string Postxmltourl(string url, string postData)
        {
            Stream outstream = null;
            Stream instream = null;
            StreamReader sr = null;
            HttpWebResponse response = null;
            HttpWebRequest request = null;
            Encoding encoding = Encoding.UTF8;
            byte[] data = encoding.GetBytes(postData);
            // 准备请求...  
            try
            {
                //CerPath证书路径，这里是本机的路径，实际应用中，按照实际情况来填写
                string certPath = WXconfig.SSLCERT_PATH;
                //证书密码
                string password = WXconfig.SSLCERT_PASSWORD;
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);

                // X509Certificate2 cert = new X509Certificate2(certPath, password, X509KeyStorageFlags.MachineKeySet);
                X509Certificate2 cert = new X509Certificate2(certPath, password);
                // 设置参数  
                request = WebRequest.Create(url) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;//不可少（个人理解为，返回的时候需要验证）
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.ContentType = "text/xml";
                request.ContentLength = data.Length;
                request.ClientCertificates.Add(cert);//添加证书请求
                outstream = request.GetRequestStream();
                outstream.Write(data, 0, data.Length);
                outstream.Close();
                //发送请求并获取相应回应数据  
                response = request.GetResponse() as HttpWebResponse;
                //直到request.GetResponse()程序才开始向目标网页发送Post请求  
                instream = response.GetResponseStream();
                sr = new StreamReader(instream, encoding);
                //返回结果网页（html）代码  
                string content = sr.ReadToEnd();
                string err = string.Empty;
                return content;

            }
            catch (Exception ex)
            {
                string err = ex.Message;
                return string.Empty;
            }
        }

        /*CheckValidationResult的定义*/
        private static bool CheckValidationResult(object sender,
        X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            if (errors == SslPolicyErrors.None)
                return true;
            return false;
        }


        #endregion

        #region 微信H5统一下单接口
        /// <summary>
        ///      微信H5统一下单接口
        /// </summary>
        /// <param name="order"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string H5PayMent(UnifiedOrder order, string key)
        {
            string msg = string.Empty;
            string mweb_url = string.Empty;
            string prepay_id = string.Empty;
            string post_data = getH5UnifiedOrderXml(order, key);
            string request_data = PostXmlToUrl(H5PayMentUrl, post_data);
            Log.WriteLogFile(request_data,"H5支付");  //记录
            SortedDictionary<string, object> requestXML = GetInfoFromXml(request_data);
            foreach (KeyValuePair<string, object> k in requestXML)
            {
                if (k.Key == "mweb_url")
                {
                    mweb_url = k.Value.ToString();
                    continue;
                }
                if (k.Key == "prepay_id")
                {
                    prepay_id = k.Value.ToString();
                    continue;
                }
                if (k.Key == "return_msg ")
                {
                    msg += k.Value.ToString();
                    continue;
                }
                if (k.Key == "err_code_des")
                {
                    msg += k.Value.ToString();
                    continue;
                }
            }
            return "{\"Code\":\"1\",\"mweb_url\":" + mweb_url + ",\"prepay_id\":" + prepay_id + ",\"msg\":" + msg + "}";
        }
        #endregion

        #region 获取code_url
        /// <summary>
        /// 获取code_url
        /// </summary>
        public string getcode_url(UnifiedOrder order, string key)
        {
            try
            {
                string code_url = "";
               // order.body = MD5Util.get_uft8(order.body);//进行uft-8编码，针对中文出现签名失败原因，
                string post_data = getUnifiedOrderXml(order, key);
                string request_data = PostXmlToUrl(UnifiedPayUrl, post_data);
                Log.WriteLogFile(request_data,"二维码支付");//记录
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
            catch (Exception e)
            {
                throw;
            }
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
            Log.WriteLogFile(request_data,"公众号支付");
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
            string return_msg = "";
            int Code = 0;
            string return_string = string.Empty;
            return_string = getCashXml(order, WXconfig.paysignkey);
            string request_data = Postxmltourl(CashPayUrl, return_string);
            Log.WriteLogFile(request_data, "微信提现");
            #region 解析返回结果
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
                else if (k.Key == "result_code")
                {
                    if (k.Value.ToString() == "SUCCESS")
                    {
                        Code = 1;
                    }
                }
                else if (k.Key == "err_code_des")
                {
                    if (k.Value.ToString() != "" && k.Value != null)
                    {
                        return_msg += "-" + k.Value.ToString();
                    }
                }
            }
            #endregion

            return "{\"Code\": " + Code + ", \"Message\": \"" + return_msg + "\"}";
        }

        #endregion

        #region 获取微信订单明细
        /// <summary>
        /// 获取微信订单明细
        /// </summary>
        /// <param name="out_trade_no">客户订单号</param>
        /// <returns></returns>
        public OrderDetail getOrderDetail(string out_trade_no)
        {
            string post_data = getQueryOrderXml(out_trade_no);
            string request_data = PostXmlToUrl(OrderQueryUrl, post_data, "1");
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

        #region 微信退款
        /// <summary>
        /// 微信退款
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public string getRefund(refund order)
        {
            string return_msg = "";//异常
            int Code = 0;
            string return_string = string.Empty;
            return_string = GetRefundOrderXml(order);
            string request_data = PostXmlToUrl(refund_Url, return_string, "1");
            Log.WriteLogFile(request_data, "微信退款");

            #region 解析返回结果
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
                else if (k.Key == "result_code")
                {
                    if (k.Value.ToString() == "SUCCESS")
                    {
                        Code = 1;
                    }
                }
                else if (k.Key == "err_code_des")
                {
                    if (k.Value.ToString() != "" && k.Value != null)
                    {
                        return_msg += "-" + k.Value.ToString();
                    }
                }
            }
            #endregion
            return "{\"Code\": " + Code + ", \"Message\": \"" + return_msg + "\"}";
        }
        #endregion

        #region 微信公众号现金红包
        /// <summary>
        /// 微信公众号现金红包
        /// </summary>
        /// <param name="wxpay">实体对象</param>
        /// <returns></returns>
        public string getPayCashbonus(WxPayData wxpay)
        {
            string return_msg = "";
            int Code = 0;
            string result = string.Empty;
            string return_string = getCashbonusXml(wxpay, WXconfig.paysignkey);
            string request_data = Postxmltourl(CashPayUrl, return_string);
            Log.WriteLogFile(request_data, "微信现金红包");
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
                else if (k.Key == "result_code")
                {
                    if (k.Value.ToString() == "SUCCESS")
                    {
                        Code = 1;
                    }
                }
                else if (k.Key == "err_code_des")
                {
                    if (k.Value.ToString() != "" && k.Value != null)
                    {
                        return_msg += "-" + k.Value.ToString();
                    }
                }
            }

            return "{\"Code\": " + Code + ", \"Message\": \"" + return_msg + "\"}";
        }
        #endregion


        #region 

        #region 把XML数据转换为SortedDictionary

        /// <summary>
        /// 把XML数据转换为SortedDictionary<string, string>集合
        /// </summary>
        /// <param name="strxml"></param>
        /// <returns></returns>
        private SortedDictionary<string, object> GetInfoFromXml(string xmlstring)
        {
            SortedDictionary<string, object> sParams = new SortedDictionary<string, object>();
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.XmlResolver = null;
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
                return sParams;
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }

        #endregion

        #region 微信H5统一下单接口xml参数整理
        /// <summary>
        /// 微信H5统一下单接口xml参数整理
        /// </summary>
        /// <param name="order">微信支付参数实例</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        private string getH5UnifiedOrderXml(UnifiedOrder order, string key)
        {
            string return_string = string.Empty;
            SortedDictionary<string, object> sParams = new SortedDictionary<string, object>();
            sParams.Add("appid", order.appid);
            sParams.Add("attach", order.attach);
            sParams.Add("body", order.body);
            sParams.Add("mch_id", order.mch_id);
            sParams.Add("nonce_str", order.nonce_str);
            sParams.Add("notify_url", order.notify_url);
            sParams.Add("spbill_create_ip", order.spbill_create_ip);
            sParams.Add("total_fee", order.total_fee);
            sParams.Add("trade_type", order.trade_type);
            sParams.Add("scene_info", order.scene_info);
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

        #region 微信统一下单接口xml参数整理
        /// <summary>
        /// 微信统一下单接口xml参数整理
        /// </summary>
        /// <param name="order">微信支付参数实例</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        private string getUnifiedOrderXml(UnifiedOrder order, string key)
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
                    sbPay.Append("<" + k.Key + ">" + k.Value.ToString() + "</" + k.Key + ">");
                }
            }
            return_string = string.Format("<xml>{0}</xml>", sbPay.ToString());
            byte[] byteArray = Encoding.UTF8.GetBytes(return_string);
            return_string = Encoding.GetEncoding("GBK").GetString(byteArray);
            //Byte[] temp = Encoding.UTF8.GetBytes(return_string);
            //string dataGBK = Encoding.GetEncoding("utf-8").GetString(temp);
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
        private string getQueryOrderXml(string out_trade_no)
        {
            string return_string = string.Empty;
            SortedDictionary<string, object> sParams = new SortedDictionary<string, object>();
            sParams.Add("appid", WXconfig.appid);
            sParams.Add("mch_id", WXconfig.mch_id);
            // sParams.Add("transaction_id", queryorder.transaction_id);
            sParams.Add("out_trade_no", out_trade_no);
            sParams.Add("nonce_str", getNoncestr());
            string sign = getsign(sParams, WXconfig.paysignkey);
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

        #region 微信退款单接口xml参数整理
        /// <summary>
        /// 微信统一下单接口xml参数整理
        /// </summary>
        /// <param name="order">微信退款参数实例</param>
        /// <param name="key">密钥</param>
        /// <returns></returns>
        private string GetRefundOrderXml(refund order)
        {
            string return_string = string.Empty;
            SortedDictionary<string, object> sParams = new SortedDictionary<string, object>();
            sParams.Add("appid", order.appid);
            sParams.Add("mch_id", order.mch_id);
            sParams.Add("nonce_str", order.nonce_str);
            sParams.Add("out_refund_no", order.out_refund_no);
            sParams.Add("out_trade_no", order.out_trade_no);
            sParams.Add("refund_fee", order.refund_fee);
            sParams.Add("total_fee", order.total_fee);
            sParams.Add("transaction_id", order.transaction_id);
            sParams.Add("sign", order.sign);

            //拼接成XML请求数据
            StringBuilder sbPay = new StringBuilder();
            foreach (KeyValuePair<string, object> k in sParams)
            {
                sbPay.Append("<" + k.Key + ">" + k.Value + "</" + k.Key + ">");
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

        #region 微信提现接口XML参数整理
        /// <summary>
        /// 微信提现接口XML参数整理
        /// </summary>
        /// <param name="order">微信提现参数实例</param>
        /// <param name="paysignkey">商户号</param>
        /// <returns></returns>
        private string getCashXml(Cash order, string paysignkey)
        {
            string return_string = string.Empty;
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
            string paySign = getsign(sParams, paysignkey);
            sParams.Add("sign", paySign);
            //拼接成XML请求数据
            StringBuilder sbPay = new StringBuilder();
            foreach (KeyValuePair<string, object> k in sParams)
            {
                sbPay.Append("<" + k.Key + ">" + k.Value + "</" + k.Key + ">");
            }
            return_string = string.Format("<xml>{0}</xml>", sbPay.ToString());
            byte[] byteArray = Encoding.UTF8.GetBytes(return_string);
            return_string = Encoding.GetEncoding("GBK").GetString(byteArray);
            return return_string;
        }
        #endregion

        #region 微信公众号现金红包接口XML参数整理
        /// <summary>
        /// 微信提现接口XML参数整理
        /// </summary>
        /// <param name="order">微信提现参数实例</param>
        /// <param name="paysignkey">商户号</param>
        /// <returns></returns>
        private string getCashbonusXml(WxPayData wxpay, string paysignkey)
        {
            string return_string = string.Empty;
            SortedDictionary<string, object> sParams = new SortedDictionary<string, object>();
            sParams.Add("act_name", wxpay.act_name);
            sParams.Add("client_ip", wxpay.client_ip);
            sParams.Add("mch_billno", wxpay.mch_billno);
            sParams.Add("mch_id", wxpay.mch_id);
            sParams.Add("nonce_str", wxpay.nonce_str);
            sParams.Add("remark", wxpay.remark);
            sParams.Add("re_openid", wxpay.re_openid);
            sParams.Add("send_name", wxpay.send_name);
            sParams.Add("total_amount", wxpay.total_amount);
            sParams.Add("total_num", wxpay.total_num);
            sParams.Add("wishing", wxpay.wishing);
            sParams.Add("wxappid", wxpay.wxappid);
            wxpay.sign = getsign(sParams, paysignkey);
            sParams.Add("sign", wxpay.sign);
            //拼接成XML请求数据
            StringBuilder sbPay = new StringBuilder();
            foreach (KeyValuePair<string, object> k in sParams)
            {
                sbPay.Append("<" + k.Key + "><![CDATA[" + k.Value + "]]></" + k.Key + ">");
            }
            return_string = string.Format("<xml>{0}</xml>", sbPay.ToString());
            byte[] byteArray = Encoding.UTF8.GetBytes(return_string);
            return_string = Encoding.GetEncoding("GBK").GetString(byteArray);
            return return_string;
        }
        #endregion


        #endregion
    }
}