using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Web;

namespace BaiDuAI.SERVICE
{
    /// <summary>
    /// 图片识别
    /// </summary>
    public class ImageRecognitionService
    {
        #region 请求URL

        /// <summary>
        /// 人脸检测与属性分析URL
        /// </summary>
        private const string detecturl = "https://aip.baidubce.com/rest/2.0/face/v3/detect";

        /// <summary>
        /// 人脸对比URL
        /// </summary>
        private const string matchurl = "https://aip.baidubce.com/rest/2.0/face/v3/match";

        /// <summary>
        /// 通用图像分析URL
        /// </summary>
        private const string advancedgeneralurl = "https://aip.baidubce.com/rest/2.0/image-classify/v2/advanced_general";

        /// <summary>
        /// 车辆分析—车型识别URL
        /// </summary>
        private const string carurl = "https://aip.baidubce.com/rest/2.0/image-classify/v1/car";

        /// <summary>
        /// 车辆分析—车辆属性识别（邀测）
        /// </summary>
        private const string vehicleattrurl = "https://aip.baidubce.com/rest/2.0/image-classify/v1/vehicle_attr";
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
                var image = "";
                if (!path.ToLower().Contains("http://") && !path.ToLower().Contains("https://"))
                {
                    image = HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path));
                }
                else
                    image = path;

                var data = new
                {
                    image = image,
                    image_type = image_type,
                    face_field= "faceshape,facetype",
                };
                var result = Utils.HttpPost(detecturl + "?access_token=" + AccessToken.getAccessToken(), JsonConvert.SerializeObject(data), "application/json");
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
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
        public JObject GetMatch(string path, string path1, string image_type)
        {
            try
            {
                var image = "";
                var image1 = "";
                if (!path.ToLower().Contains("http://") && !path.ToLower().Contains("https://"))
                {
                    image = HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path));
                }
                else
                    image = path;

                if (!path1.ToLower().Contains("http://") && !path1.ToLower().Contains("https://"))
                {
                    image1 = HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path1));
                }
                else
                    image1 = path1;

                var list = new List<object>();
                list.Add(new
                {
                    image = image,
                    image_type = image_type,
                    face_field="faceshape,facetype"
                });
                list.Add(new
                {
                    image = image1,
                    image_type = image_type,
                    face_field = "faceshape,facetype"
                });

                var result = Utils.HttpPost(matchurl + "?access_token=" + AccessToken.getAccessToken(), JsonConvert.SerializeObject(list), "application/json");
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
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
        public JObject GetCar(string path, string image_type)
        {
            try
            {
                var data = new
                {
                    image = HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path)),
                    image_type = image_type,
                    face_field = "faceshape,facetype"
                };
                var result = Utils.HttpPost(carurl + "?access_token=" + AccessToken.getAccessToken(), JsonConvert.SerializeObject(data));
                JObject jo = (JObject)JsonConvert.DeserializeObject(result);
                return jo;
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
        public JObject GetVehicleattr(string path, string image_type)
        {
            try
            {
                var data = new
                {
                    image = HttpUtility.UrlEncode(Thumbnail.ImgToBase64String(path)),
                    image_type = image_type,
                    face_field = "faceshape,facetype",
                };
                var result = Utils.HttpPost(vehicleattrurl + "?access_token=" + AccessToken.getAccessToken(), JsonConvert.SerializeObject(data));
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
