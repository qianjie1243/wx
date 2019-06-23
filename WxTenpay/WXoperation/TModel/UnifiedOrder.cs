using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
namespace WxTenpay.WXoperation
{
    /// <summary>
    /// 微信统一接口请求实体对象
    /// </summary>
    [Serializable]
    public class UnifiedOrder
    {
        /// <summary>
        /// 公众号ID(微信分配的公众账号 ID)
        /// </summary>
        public string appid = "";
        /// <summary>
        /// 商户号(微信支付分配的商户号)
        /// </summary>
        public string mch_id = "";
        /// <summary>
        /// 微信支付分配的终端设备号
        /// </summary>
        public string device_info = "";
        /// <summary>
        /// 随机字符串，不长于 32 位
        /// </summary>
        public string nonce_str = "";
        /// <summary>
        /// 签名
        /// </summary>
        public string sign = "";
        /// <summary>
        /// 商品描述
        /// </summary>
        public string body = "";
        /// <summary>
        /// 附加数据，原样返回
        /// </summary>
        public string attach = "";
        /// <summary>
        /// 商户系统内部的订单号,32个字符内、可包含字母,确保在商户系统唯一,详细说明
        /// </summary>
        public string out_trade_no = "";
        /// <summary>
        /// 订单总金额，单位为分，不能带小数点
        /// </summary>
        public int total_fee = 0;
        /// <summary>
        /// 终端IP
        /// </summary>
        public string spbill_create_ip = "";
        /// <summary>
        /// 订 单 生 成 时 间 ， 格 式 为yyyyMMddHHmmss，如 2009 年12 月 25 日 9 点 10 分 10 秒表示为 20091225091010。时区为 GMT+8 beijing。该时间取自商户服务器
        /// </summary>
        public string time_start = "";
        /// <summary>
        /// 交易结束时间
        /// </summary>
        public string time_expire = "";
        /// <summary>
        /// 商品标记 商品标记，该字段不能随便填，不使用请填空，使用说明详见第 5 节
        /// </summary>
        public string goods_tag = "";
        /// <summary>
        /// 接收微信支付成功通知
        /// </summary>
        public string notify_url = "";
        /// <summary>
        /// JSAPI、NATIVE、APP
        /// </summary>
        public string trade_type = "";
        /// <summary>
        /// 用户标识 trade_type 为 JSAPI时，此参数必传
        /// </summary>
        public string openid = "";
        /// <summary>
        /// 只在 trade_type 为 NATIVE时需要填写。
        /// </summary>
        public string product_id = "";
        /// <summary>
        /// 场景信息(用于H5支付)
        /// </summary>
        public string scene_info = "";
    }

    /// <summary>
    /// 微信提现类
    /// </summary>
    [Serializable]
    public class Cash
    {
        /// <summary>
        /// 此参数必传
        /// </summary>
        public string openid = "";
        /// <summary>
        /// 终端IP
        /// </summary>
        public string spbill_create_ip = "";
        /// <summary>
        /// 公众号ID(微信分配的公众账号 ID)
        /// </summary>
        public string mch_appid = "";
        /// <summary>
        /// 商户号(微信支付分配的商户号)
        /// </summary>
        public string mch_id = "";
        /// <summary>
        /// 微信支付分配的终端设备号
        /// </summary>
        public string device_info = "";
        /// <summary>
        /// 随机字符串，不长于 32 位
        /// </summary>
        public string nonce_str = "";
        /// <summary>
        /// 签名
        /// </summary>
        public string sign = "";
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string partner_trade_no = "";
        /// <summary>
        /// 校验用户姓名选项
        /// NO_CHECK：不校验真实姓名 
        /// FORCE_CHECK：强校验真实姓名
        /// </summary>
        public string check_name = "NO_CHECK";
        /// <summary>
        /// 收款用户姓名
        /// 收款用户真实姓名。 
        ///如果check_name设置为FORCE_CHECK，则必填用户真实姓名
        /// </summary>
        public string re_user_name = "";
        /// <summary>
        /// 金额
        /// 企业付款金额，单位为分
        /// </summary>
        public int amount = 0;
        /// <summary>
        /// 企业付款描述信息
        /// </summary>
        public string desc = "";

    }

    /// <summary>
    /// 微信退款订单明细实体对象
    /// </summary>
    [Serializable]
    public class refund
    {
        /// <summary>
        /// 公众账号ID
        /// </summary>
        public string appid { set; get; } = "";
        /// <summary>
        /// 商户号
        /// </summary>
        public string mch_id { set; get; } = "";
        /// <summary>
        /// 随机字符串
        /// </summary>
        public string nonce_str { set; get; } = "";
        /// <summary>
        /// 签名
        /// </summary>
        public string sign { set; get; } = "";
        /// <summary>
        /// 签名类型
        /// </summary>
        public string sign_type { set; get; } = "MD5";//目前支持HMAC-SHA256和MD5，默认为MD5
                                                      /// <summary>
                                                      /// 微信订单号
                                                      /// </summary>
        public string transaction_id { set; get; } = ""; // 微信生成的订单号，在支付通知中有返回
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string out_trade_no { set; get; } = "";
        /// <summary>
        /// 商户退款单号
        /// </summary>
        public string out_refund_no { set; get; } = "";//商户系统内部的退款单号，商户系统内部唯一，只能是数字、大小写字母_-|*@ ，同一退款单号多次请求只退一笔。 
        /// <summary>
        /// 订单金额
        /// </summary>
        public string total_fee { set; get; } = ""; // 订单总金额，单位为分，只能为整数，详见支付金额
        /// <summary>
        /// 退款金额
        /// </summary>
        public string refund_fee { set; get; } = ""; // 退款总金额，订单总金额，单位为分，只能为整数，详见支付金额
        /// <summary>
        /// 退款货币种类
        /// </summary>
        public string refund_fee_type { set; get; } = "CNY"; // CNY 退款货币类型，需与支付一致，或者不填。符合ISO 4217标准的三位字母代码，默认人民币：CNY，其他值列表详见货币类型
        /// <summary>
        /// 退款原因
        /// </summary>
        public string refund_desc { set; get; } = "";// 商品已售完 若商户传入，会在下发给用户的退款消息中体现退款原因
        /// <summary>
        /// 退款资金来源
        /// </summary>
        public string refund_account { set; get; } = "REFUND_SOURCE_UNSETTLED_FUNDS"; // REFUND_SOURCE_RECHARGE_FUNDS 仅针对老资金流商户使用REFUND_SOURCE_UNSETTLED_FUNDS---未结算资金退款（默认使用未结算资金退款）REFUND_SOURCE_RECHARGE_FUNDS---可用余额退款
        /// <summary>
        /// 退款结果通知url
        /// </summary>
        public string notify_url { set; get; } = ""; //异步接收微信支付退款结果通知的回调地址，通知URL必须为外网可访问的url，不允许带参数

    }


    /// <summary>
    /// 微信公众号现金红包实体对象
    /// </summary>
    [Serializable]
    public class WxPayData
    {
        /// <summary>
        /// 随机字符串，不长于32位
        /// </summary>
        public string nonce_str { set; get; } = "";
        /// <summary>
        /// 签名 
        /// </summary>
        public string sign { set; get; } = "";
        /// <summary>
        /// 商户订单号
        /// </summary>
        public string mch_billno { set; get; }
        /// <summary>
        /// 商户号 
        /// </summary>
        public string mch_id { set; get; } = "";
        /// <summary>
        /// 公众账号appid
        /// </summary>
        public string wxappid { set; get; } = "";
        /// <summary>
        /// 红包发送者名称
        /// </summary>
        public string send_name { set; get; } = "";
        /// <summary>
        /// 用户的openid
        /// </summary>
        public string re_openid { set; get; } = "";
        /// <summary>
        /// 付款金额，单位分
        /// </summary>
        public int total_amount { set; get; } = 0;
        /// <summary>
        /// 红包发放总人数
        /// </summary>
        public int total_num { set; get; } = 1;
        /// <summary>
        /// 红包祝福语
        /// </summary>
        public string wishing { set; get; } = "";
        /// <summary>
        /// 调用接口的机器Ip地址
        /// </summary>
        public string client_ip { set; get; } = "";
        /// <summary>
        /// 活动名称
        /// </summary>
        public string act_name { set; get; } = "";
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { set; get; } = "";

    }
}