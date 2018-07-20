﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
namespace WxTenpay.wxconfig.wxtenpay
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




}