﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace WxTenpay
{
    /// <summary>
    /// 获取配置文件配置
    /// </summary>
    public static class GetConfig
    {
        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private static string GetIndexConfigValue(string key)
        {
            try
            {
                string indexConfigPath = "WxTenpay.config";

                ExeConfigurationFileMap ecf = new ExeConfigurationFileMap();
                ecf.ExeConfigFilename = System.AppDomain.CurrentDomain.BaseDirectory + indexConfigPath;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(ecf, ConfigurationUserLevel.None);
                return config.AppSettings.Settings[key].Value;
            }
            catch (Exception ex) { //没有文件，读取异常不做处理
                return null;
            }
        }

        /// <summary>
        /// 重置配置文件
        /// </summary>
        /// <returns></returns>
        public static void ResetConfig()
        {
            string appid = GetIndexConfigValue("AppID");
            string Secret = GetIndexConfigValue("Secret");
            string MchId = GetIndexConfigValue("MchId");
            string TenPayKey = GetIndexConfigValue("TenPayKey");
            string URL = GetIndexConfigValue("URL");

            string SSLCERTPATH = GetIndexConfigValue("SSLCERTPATH");
            string SSLCERTPASSWORD = GetIndexConfigValue("SSLCERTPASSWORD");

            string AILACCESSKEYID = GetIndexConfigValue("AILACCESSKEYID");
            string AILACCESSKEYSECRET = GetIndexConfigValue("AILACCESSKEYSECRET");

            string BAIDUMAPAK = GetIndexConfigValue("BAIDUMAPAK");

            string AAppID = GetIndexConfigValue("AAppID");
            string AMchId = GetIndexConfigValue("AMchId");
            string ATenPayKey = GetIndexConfigValue("ATenPayKey");
            string AURL = GetIndexConfigValue("AURL");

         

            string IAppID = GetIndexConfigValue("IAppID");
            string IMchId = GetIndexConfigValue("IMchId");
            string ITenPayKey = GetIndexConfigValue("ITenPayKey");
            string IURL = GetIndexConfigValue("IURL");
        

            if (!string.IsNullOrWhiteSpace(appid))
                WXconfig.appid = appid;
            if (!string.IsNullOrWhiteSpace(Secret))
                WXconfig.secret = Secret;
            if (!string.IsNullOrWhiteSpace(URL))
                WXconfig.url = URL;
            if (!string.IsNullOrWhiteSpace(MchId))
                WXconfig.mch_id = MchId;
            if (!string.IsNullOrWhiteSpace(TenPayKey))
                WXconfig.paysignkey = TenPayKey;
            if (!string.IsNullOrWhiteSpace(SSLCERTPATH))
                WXconfig.SSLCERT_PATH = SSLCERTPATH;
            if (!string.IsNullOrWhiteSpace(SSLCERTPASSWORD))
                WXconfig.SSLCERT_PASSWORD = SSLCERTPASSWORD;

            if (!string.IsNullOrWhiteSpace(AILACCESSKEYID))
                Aliconfig.accessKeyId = AILACCESSKEYID;
            if (!string.IsNullOrWhiteSpace(AILACCESSKEYSECRET))
                Aliconfig.accessKeySecret = AILACCESSKEYSECRET;

            if (!string.IsNullOrWhiteSpace(BAIDUMAPAK))
                BaiduMap.ak = BAIDUMAPAK;

            if (!string.IsNullOrWhiteSpace(IAppID))
                APP_Iconfig.appid = AAppID;
            if (!string.IsNullOrWhiteSpace(IURL))
                APP_Iconfig.url = IURL;
            if (!string.IsNullOrWhiteSpace(IMchId))
                APP_Iconfig.mch_id = IMchId;
            if (!string.IsNullOrWhiteSpace(ITenPayKey))
                APP_Iconfig.paysignkey = ITenPayKey;


            if (!string.IsNullOrWhiteSpace(AAppID))
                APP_Aconfig.appid = AAppID;
            if (!string.IsNullOrWhiteSpace(AURL))
                APP_Aconfig.url = AURL;
            if (!string.IsNullOrWhiteSpace(AMchId))
                APP_Aconfig.mch_id = AMchId;
            if (!string.IsNullOrWhiteSpace(ATenPayKey))
                APP_Aconfig.paysignkey = ATenPayKey;

        }

    }
}