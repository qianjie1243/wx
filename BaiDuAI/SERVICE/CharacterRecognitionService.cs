using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using System.Web;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace BaiDuAI.SERVICE
{

    /// <summary>
    /// 文字识别，百度免费试用，每天有次数限制
    /// </summary>
    public class CharacterRecognitionService
    {
        #region 请求url
        #region 通用文字识别请求URL
        /// <summary>
        /// 普通版
        /// </summary>
        private string generalurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/general_basic";

        /// <summary>
        /// 高精度版
        /// </summary>
        private string accurateurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/accurate_basic";

        /// <summary>
        /// 含位置信息版
        /// </summary>
        private string _generalurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/general";

        /// <summary>
        /// 含位置高精度版
        /// </summary>
        private string _accurateurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/accurate";
        /// <summary>
        /// 含生僻字版
        /// </summary>
        private string general_enhancedurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/general_enhanced";
        #endregion

        #region 获取身份证URL
        /// <summary>
        /// 获取身份证URL
        /// </summary>
        private string idcardurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/idcard";
        #endregion

        #region 获取手写文字识别URl
        /// <summary>
        /// 获取手写文字识别URl
        /// </summary>
        private string handwritingurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/handwriting";
        #endregion

        #region 获取银行卡URl
        /// <summary>
        /// 获取银行卡URl
        /// </summary>
        private string bankcardurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/bankcard";

        #endregion

        #region 获取营业执照识别URl
        /// <summary>
        /// 获取营业执照识别URl
        /// </summary>
        private string businesslicenseurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/business_license";

        #endregion

        #region 获取护照识别URl
        /// <summary>
        /// 获取护照识别URl
        /// </summary>
        private string passporturl = "https://aip.baidubce.com/rest/2.0/ocr/v1/passport";

        #endregion

        #region 获取名片识别URl
        /// <summary>
        /// 获取名片识别URl
        /// </summary>
        private string businesscardurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/business_card";

        #endregion

        #region 获取户口本识别URL
        /// <summary>
        /// 获取户口本识别URL
        /// </summary>
        private string householdregisterurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/household_register";
        #endregion

        #region  获取出生医学证明识别URL
        /// <summary>
        /// 获取出生医学证明识别URL
        /// </summary>
        private string birthcertificateurl ="https://aip.baidubce.com/rest/2.0/ocr/v1/birth_certificate";
        #endregion

        #region  获取港澳通行证识别URL
        /// <summary>
        /// 获取出生医学证明识别URL
        /// </summary>
        private string HKMacauexitentrypermiturl = "https://aip.baidubce.com/rest/2.0/ocr/v1/HK_Macau_exitentrypermit";
        #endregion

        #region  获取台湾通行证识别URL
        /// <summary>
        /// 获取台湾通行证识别URL
        /// </summary>
        private string taiwanexitentrypermiturl = "https://aip.baidubce.com/rest/2.0/ocr/v1/taiwan_exitentrypermit";
        #endregion

        #region  获取驾驶证识别URL
        /// <summary>
        /// 获取驾驶证识别URL
        /// </summary>
        private string drivinglicenseurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/driving_license";
        #endregion

        #region  获取行驶证识别URL
        /// <summary>
        /// 获取行驶证识别URL
        /// </summary>
        private string vehiclelicenseurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/vehicle_license";
        #endregion

        #region  获取车牌识别URL
        /// <summary>
        /// 获取车牌识别URL
        /// </summary>
        private string licenseplateurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/license_plate";
        #endregion

        #region  获取增值税发票识别URL
        /// <summary>
        /// 获取增值税发票识别URL
        /// </summary>
        private string vatinvoiceurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/vat_invoice";
        #endregion

        #region  获取通用票据识别URL
        /// <summary>
        /// 获取通用票据识别URL
        /// </summary>
        private string receipturl = "https://aip.baidubce.com/rest/2.0/ocr/v1/receipt";
        #endregion

        #region  获取火车票识别URL
        /// <summary>
        /// 获取火车票识别URL
        /// </summary>
        private string trainticketurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/train_ticket";
        #endregion

        #region  获取出租车票识别URL
        /// <summary>
        /// 获取出租车票识别URL
        /// </summary>
        private string taxireceipturl = "https://aip.baidubce.com/rest/2.0/ocr/v1/taxi_receipt";
        #endregion

        #region  获取定额发票识别URL
        /// <summary>
        /// 获取定额发票识别URL
        /// </summary>
        private string quotainvoiceurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/quota_invoice";
        #endregion 

        #region  获取机动车销售发票识别URL
        /// <summary>
        /// 获取机动车销售发票识别URL
        /// </summary>
        private string vehicleinvoiceurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/vehicle_invoice";
        #endregion

        #region  获取车辆合格证识别URL
        /// <summary>
        /// 获取车辆合格证识别URL
        /// </summary>
        private string vehiclecertificateurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/vehicle_certificate";
        #endregion

        #region  获取VIN码识别URL
        /// <summary>
        /// 获取VIN码识别URL
        /// </summary>
        private string vincodeurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/vin_code";
        #endregion

        #region  获取二维码识别URL
        /// <summary>
        /// 获取二维码识别URL
        /// </summary>
        private string qrcodeurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/qrcode";
        #endregion

        #region  获取彩票识别URL
        /// <summary>
        /// 获取彩票识别URL
        /// </summary>
        private string lotteryurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/lottery";
        #endregion

        #region  获取保单识别URL
        /// <summary>
        /// 获取保单识别URL
        /// </summary>
        private string linsurancedocumentsurl = "https://aip.baidubce.com/rest/2.0/ocr/v1/insurance_documents";
        #endregion 
        #endregion

        #region 通用文字识别
        /// <summary>
        /// 通用文字识别
        /// </summary>
        /// <param name="path">图片路劲,1：本地路劲  2：网络路劲，只支持http</param>
        /// <param name="language_type">识别语言类型，默认为CHN_ENG</param>
        /// <param name="detect_direction">	是否检测语言，默认不检测。当前支持（中文、英语、日语、韩语）</param>
        /// <param name="probability">	是否返回识别结果中每一行的置信度</param>
        /// <param name="type">	类型 1：普通版 2：高精度版 3：含位置信息版 4：含位置高精度版 5:含生僻字版</param>
        /// <returns></returns>
        public JObject GetGeneral_basic(int type, string path, string language_type, string detect_direction, string probability)
        {
            try
            {
                var url = "";
                switch (type)
                {
                    case 1:
                        url = generalurl;
                        break;
                    case 2:
                        url = accurateurl;
                        break;
                    case 3:
                        url = _generalurl;
                        break;
                    case 4:
                        url = _accurateurl;
                        break;
                    case 5:
                        url = general_enhancedurl;
                        break;
                }
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}&language_type={language_type}&detect_direction={detect_direction}&probability={probability}";
                var result = Utils.HttpPost(url + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;

            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion

        #region 识别个人信息==============

        #region 识别身份证
        /// <summary>
        /// 识别身份证
        /// </summary>
        /// <param name="path"></param>
        /// <param name="id_card_side">front：身份证含照片的一面；back：身份证带国徽的一面</param> 
        /// <param name="detect_direction">true：检测旋转角度并矫正识别；false：不检测旋转角度，针对摆放情况不可控制的情况建议本参数置为true</param>
        /// <returns></returns>
        public JObject GetIdNumber(string path, string id_card_side, string detect_direction)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}&id_card_side={id_card_side}&detect_direction={detect_direction}";
                var result = Utils.HttpPost(idcardurl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion

        #region 获取银行卡
        /// <summary>
        /// 获取银行卡
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <returns></returns>
        public JObject GetBankcard(string path)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}";
                var result = Utils.HttpPost(bankcardurl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 护照识别
        /// <summary>
        /// 护照识别
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <returns></returns>
        public JObject Getpassport(string path)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}";
                var result = Utils.HttpPost(businesslicenseurl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 驾驶证识别
        /// <summary>
        /// 驾驶证识别
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <param name="detect_direction">是否检测图像朝向，默认不检测，即：false。朝向是指输入图像是正常方向、逆时针旋转90/180/270度。可选值包括:- true：检测朝向；- false：不检测朝向。</param>
        /// <returns></returns>
        public JObject Getdrivinglicense(string path, string detect_direction)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}&detect_direction={detect_direction}";
                var result = Utils.HttpPost(drivinglicenseurl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 行驶证识别
        /// <summary>
        /// 行驶证识别
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <param name="detect_direction">是否检测图像朝向，默认不检测，即：false。朝向是指输入图像是正常方向、逆时针旋转90/180/270度。可选值包括:- true：检测朝向；- false：不检测朝向。</param>
        /// <param name="vehicle_license_side">front：识别行驶证主页，back：识别行驶证副页,默认为正页</param>
        /// <returns></returns>
        public JObject Getvehiclelicense(string path, string detect_direction, string vehicle_license_side)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}&detect_direction={detect_direction}&vehicle_license_side={vehicle_license_side}";
                var result = Utils.HttpPost(vehiclelicenseurl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 户口本识别
        /// <summary>
        /// 户口本识别
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <returns></returns>
        public JObject Gethouseholdregister(string path)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}";
                var result = Utils.HttpPost(householdregisterurl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 出生医学证明识别
        /// <summary>
        /// 出生医学证明识别
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <returns></returns>
        public JObject Getbirthcertificate(string path)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}";
                var result = Utils.HttpPost(birthcertificateurl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 港澳通行证识别
        /// <summary>
        /// 港澳通行证识别
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <returns></returns>
        public JObject GetHKMacauexitentrypermit(string path)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}";
                var result = Utils.HttpPost(HKMacauexitentrypermiturl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 台湾通行证识别
        /// <summary>
        /// 台湾通行证识别
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <returns></returns>
        public JObject Gettaiwanexitentrypermit(string path)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}";
                var result = Utils.HttpPost(taiwanexitentrypermiturl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #endregion

        #region 票据识别===================

        #region 营业执照识别
        /// <summary>
        /// 营业执照识别
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <param name="detect_direction">可选值 true,false是否检测图像朝向，默认不检测，即：false。可选值包括true - 检测朝向；false - 不检测朝向。朝向是指输入图像是正常方向、逆时针旋转90/180/270度</param>
        /// <returns></returns>
        public JObject Getbusinesslicense(string path,  string detect_direction)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}&detect_direction={detect_direction}";
                var result = Utils.HttpPost(businesslicenseurl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 增值税发票识别
        /// <summary>
        /// 增值税发票识别
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <returns></returns>
        public JObject Getvatinvoice(string path)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}";
                var result = Utils.HttpPost(vatinvoiceurl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 通用票据识别
        /// <summary>
        /// 通用票据识别
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <param name="detect_direction">是否检测图像朝向，默认不检测，即：false。朝向是指输入图像是正常方向、逆时针旋转90/180/270度。可选值包括:- true：检测朝向；- false：不检测朝向。</param>
        /// <returns></returns>
        public JObject Getreceipt(string path, string detect_direction)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}&detect_direction={detect_direction}";
                var result = Utils.HttpPost(receipturl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 火车票识别
        /// <summary>
        /// 火车票识别
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <returns></returns>
        public JObject Gettrainticket(string path)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}";
                var result = Utils.HttpPost(trainticketurl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 出租车票识别
        /// <summary>
        /// 出租车票识别
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <returns></returns>
        public JObject Gettaxireceipt(string path)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}";
                var result = Utils.HttpPost(taxireceipturl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 定额发票识别
        /// <summary>
        /// 定额发票识别
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <returns></returns>
        public JObject Getquotainvoice(string path)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}";
                var result = Utils.HttpPost(quotainvoiceurl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 机动车销售发票识别
        /// <summary>
        /// 机动车销售发票识别
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <returns></returns>
        public JObject Getvehicleinvoice(string path)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}";
                var result = Utils.HttpPost(vehicleinvoiceurl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion
        #endregion 

        #region 手写文字识别
        /// <summary>
        /// 手写文字识别
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public JObject GetHandWriting(string path)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}";
                var result = Utils.HttpPost(handwritingurl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion   
   
        #region 名片识别
        /// <summary>
        /// 名片识别
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <returns></returns>
        public JObject Getbusinesscard(string path)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}";
                var result = Utils.HttpPost(businesscardurl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion
    
        #region 车牌识别
        /// <summary>
        /// 车牌识别
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <param name="multi_detect">是否检测多张车牌，默认为false，当置为true的时候可以对一张图片内的多张车牌进行识别</param>
        /// <returns></returns>
        public JObject Getlicenseplate(string path, bool multi_detect)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}&multi_detect={multi_detect}";
                var result = Utils.HttpPost(licenseplateurl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
              // var number= jo["words_result"]["number"];
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 车辆合格证识别
        /// <summary>
        /// 车辆合格证识别
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <returns></returns>
        public JObject Getvehiclecertificate(string path)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}";
                var result = Utils.HttpPost(vehiclecertificateurl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region VIN码识别
        /// <summary>
        /// VIN码识别:对车辆车架上、挡风玻璃上的VIN码进行识别
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <returns></returns>
        public JObject Getvincode(string path)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}";
                var result = Utils.HttpPost(vincodeurl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 二维码识别
        /// <summary>
        /// 二维码识别
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <returns></returns>
        public JObject Getqrcode(string path)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}";
                var result = Utils.HttpPost(qrcodeurl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 彩票识别
        /// <summary>
        /// 彩票识别
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <returns></returns>
        public JObject Getlottery(string path)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}";
                var result = Utils.HttpPost(lotteryurl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 保单识别
        /// <summary>
        /// 保单识别
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <param name="rkv_business">是否进行商业逻辑处理，rue：进行商业逻辑处理，false：不进行商业逻辑处理，默认true</param>
        /// <returns></returns>
        public JObject Getlinsurancedocuments(string path,string rkv_business)
        {
            try
            {
                string str = $"image={HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path))}&rkv_business={rkv_business}";
                var result = Utils.HttpPost(linsurancedocumentsurl + "?access_token=" + AccessToken.getAccessToken(), str);
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion
    }
}
