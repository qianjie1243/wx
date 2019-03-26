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
    /// 百度图像识别
    /// </summary>
   public  class BaiDu_ImageRecognition
    {
        #region 业务
        ImageRecognitionService _image = new ImageRecognitionService();
        #endregion

        #region 人脸检测与属性分析
        /// <summary>
        /// 人脸检测与属性分析
        /// </summary>
        /// <param name="path"></param>
        /// <param name="image_type">图片类型:BASE64,URL,FACE_TOKEN</param>
        /// <returns></returns>
        public JObject GetDetect(string path, string image_type)
        {
            try
            {
                return _image.GetDetect(path, image_type);
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 人脸对比
        /// <summary>
        /// 人脸对比
        /// </summary>
        /// <param name="path">图片路劲</param>
        /// <param name="path1">图片路劲</param>
        /// <param name="image_type">图片类型:BASE64,URL,FACE_TOKEN</param>
        /// <returns></returns>
        public JObject GetMatch(string path, string path1,  string image_type)
        {
            try
            {
                return _image.GetMatch(path, path1, image_type);
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 车辆分析—车型识别URL
        /// <summary>
        /// 车辆分析—车型识别URL
        /// </summary>
        /// <param name="path"></param>   
        /// <param name="image_type">图片类型:BASE64,URL,FACE_TOKEN</param>
        public JObject GetCar(string path,  string image_type)
        {
            try
            {
                return _image.GetCar(path, image_type);
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region 车辆分析—车辆属性识别（邀测）
        /// <summary>
        /// 车辆分析—车辆属性识别（邀测）
        /// </summary>
        /// <param name="path"></param>  
        /// <param name="image_type">图片类型:BASE64,URL,FACE_TOKEN</param>
        public JObject GetVehicleattr(string path,string image_type)
        {
            try
            {
                return _image.GetVehicleattr(path, image_type);
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion
    }
}
