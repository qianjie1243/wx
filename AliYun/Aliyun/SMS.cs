﻿using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using System;


namespace AliYun.AliYun
{
    /// <summary>
    /// 发送短信验证码
    /// </summary>
    public class SMS
    {

        //产品名称:云通信短信API产品,开发者无需替换
        const String product = "Dysmsapi";
        //产品域名,开发者无需替换
        const String domain = "dysmsapi.aliyuncs.com";

        #region 发送短信验证码
        /// <summary>
        /// 发送短信验证码
        /// </summary>
        /// <param name="PhoneNumbers">手机号码</param>
        /// <param name="TemplateCode">短信模板ID</param>
        /// <param name="SignName">短信签名</param>
        /// <param name="TemplateParam">模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为</param>
        /// <returns></returns>
        public static SendSmsResponse sendSms(string PhoneNumbers,string TemplateParam,string SignName,string TemplateCode)
        {
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", Aliconfig.accessKeyId, Aliconfig.accessKeySecret);
            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", product, domain);
            IAcsClient acsClient = new DefaultAcsClient(profile);
            SendSmsRequest request = new SendSmsRequest();
            SendSmsResponse response = null;
            try
            {
                //必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为1000个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式
                request.PhoneNumbers = PhoneNumbers;
                //必填:短信签名-可在短信控制台中找到
                request.SignName = SignName;
                //必填:短信模板-可在短信控制台中找到
                request.TemplateCode = TemplateCode;
                //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
                request.TemplateParam = TemplateParam;
                //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                // request.OutId = "yourOutId";
                //请求失败这里会抛ClientException异常
                response = acsClient.GetAcsResponse(request);

            }
            catch (Exception )
            {

            }
            return response;


        }
        #endregion
    }
}
