using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WxTenpay.WXoperation
{
    /// <summary>
    /// 微信APP支付实体
    /// </summary>
  public class Wx_pay
    {
        /// <summary>
        /// 应用ID
        /// </summary>
        public string appid { set; get; } = "";
        /// <summary>
        /// 商户号
        /// </summary>
        public string partnerid { set; get; } = "";
        /// <summary>
        /// 预支付交易会话ID
        /// </summary>
        public string prepayid { set; get; } = "";
        /// <summary>
        /// 扩展字段
        /// </summary>
        public string wxpackage { set; get; } = "Sign=WXPay";
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string noncestr { set; get; } = "";
        /// <summary>
        /// 时间戳
        /// </summary>
        public string timestamp { set; get; } = "";

        /// <summary>
        /// 签名
        /// </summary>
        public string sign { set; get; } = "";
    }
}
