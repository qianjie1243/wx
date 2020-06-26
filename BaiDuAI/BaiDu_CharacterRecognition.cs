using BaiDuAI.SERVICE;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiDuAI
{
    /// <summary>
    /// 百度AI文字识别
    /// </summary>
    public class BaiDu_CharacterRecognition
    {
        #region 业务
        CharacterRecognitionService _cr = new CharacterRecognitionService();
        #endregion

        #region 功能

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
        public JObject GetGeneral_basic(int type, string path, string language_type= "CHN_ENG", string detect_direction="false", string probability= "false")
        {
            try
            {
                return _cr.GetGeneral_basic(type, path, language_type, detect_direction, probability);

            }
            catch (Exception )
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
        public JObject GetIdNumber(string path, string id_card_side= "front", string detect_direction= "true")
        {
            try
            {
                return _cr.GetIdNumber(path,id_card_side, detect_direction);
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
                return _cr.GetBankcard(path);
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
                return _cr.Getpassport(path);
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
        public JObject Getdrivinglicense(string path ,string detect_direction= "false")
        {
            try
            {
                return _cr.Getdrivinglicense(path, detect_direction);
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
        public JObject Getvehiclelicense(string path,string detect_direction="false", string vehicle_license_side= "front")
        {
            try
            {
                return _cr.Getvehiclelicense(path, detect_direction, vehicle_license_side);
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
                return _cr.Gethouseholdregister(path);
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
                return _cr.Getbirthcertificate(path);
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
                return _cr.GetHKMacauexitentrypermit(path);
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
                return _cr.Gettaiwanexitentrypermit(path);
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
        public JObject Getbusinesslicense(string path,string detect_direction= "true")
        {
            try
            {
                return _cr.Getbusinesslicense(path, detect_direction);
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
                return _cr.Getvatinvoice(path);
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
        public JObject Getreceipt(string path,string detect_direction="true")
        {
            try
            {
                return _cr.Getreceipt(path,  detect_direction);
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
                return _cr.Gettrainticket(path);
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
                return _cr.Gettaxireceipt(path);
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
                return _cr.Getquotainvoice(path);
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
                return _cr.Getvehicleinvoice(path);
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
                return _cr.GetHandWriting(path);
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
                return _cr.Getbusinesscard(path);
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
        public JObject Getlicenseplate(string path, bool multi_detect=false)
        {
            try
            {
                return _cr.Getlicenseplate(path, multi_detect);
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
                return _cr.Getvehiclecertificate(path);
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
                return _cr.Getvincode(path);
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
                return _cr.Getqrcode(path);
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
                return _cr.Getlottery(path);
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
        public JObject Getlinsurancedocuments(string path,string rkv_business= "true")
        {
            try
            {
                return _cr.Getlinsurancedocuments(path, rkv_business);
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #endregion

    }
}
