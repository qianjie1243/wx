using AliYun.AliYun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AliYun
{
    /// <summary>
    /// 阿里云短信
    /// </summary>
    public class AliyunSMS
    {
        /// <summary>
        ///  加载配置文件
        /// </summary>
        //public AliyunSMS()
        //{
        //    GetConfig.ResetConfig();
        //}
        /// <summary>
        /// 发送阿里云短信
        /// </summary>
        /// <param name="PhoneNumbers">手机号码</param>
        /// <param name="TemplateCode">短信模板ID</param>
        /// <param name="SignName">短信签名</param>
        /// <param name="TemplateParam">模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为</param>
        /// TemplateParam如 "{\"code\":\"" + 短信验证码 + "\"}";
        /// <returns> Code=1 成功，0失败， Message 错误提示</returns>
        public object sendSms(string PhoneNumbers, string TemplateParam, string SignName, string TemplateCode)
        {
            return SMS.sendSms(PhoneNumbers, TemplateParam, SignName, TemplateCode);

        }
    }
}
