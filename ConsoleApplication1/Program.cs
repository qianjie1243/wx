using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxTenpay;
using WxTenpay.wxconfig.wxconfiguration;
using BaiDuAI;
using System.Security.Cryptography;
using System.Web;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    class Program
    {


        /// <summary>
        /// 测试自定义菜单
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                #region  微信公众号菜单测试
                //Wechat_Menu wx = new Wechat_Menu();
                //List<MenuModel> list = new List<MenuModel> { new MenuModel { name = "菜单1", url = "https://baidu.com", type = "view" }, new MenuModel { name = "菜单2", url = "https://baidu.com", type = "view" } };
                //List<MenuModel> _MenuParameter = new List<MenuModel>();//多按钮列表
                //MenuModel model = new MenuModel();//
                //model.name = "菜单3-1";
                //model.type = "view";
                //model.url = "https://baidu.com";
                //_MenuParameter.Add(model);

                //MenuModel model2 = new MenuModel();
                //model2.name = "菜单3-2";
                //model2.type = "view";
                //model2.url = "https://baidu.com";
                //_MenuParameter.Add(model2);

                //MenuModel _model = new MenuModel();//多按钮主列表名称
                //_model.name = "菜单3";
                //_model.sub_button = _MenuParameter;
                //list.Add(_model);

                //Dictionary<string, object> diy = new Dictionary<string, object>();
                //diy.Add("button", list);
                //wx.Menu(diy, 1);
                #endregion

                #region 百度Ai测试
                //  BaiDu_CharacterRecognition ce = new BaiDu_CharacterRecognition();
                //  var result = ce.GetIdNumber(@"E:/c#项目/新建文件夹/WxTenpay/ConsoleApplication1/111.png");
                //var number = result["words_result"]["number"];
                // var res= HttpUtility.UrlDecode("cK1ryyENDj3uPBgLy3iQUT4M9LhSjWArGUjMcg8uNK0uiwtMsxvPSlx4FAkCZYujr1rKS0O5Um7r5iyyqcxpIyavMkex1I20F%2B5cQU6XsPrTFMbrswO%2BnxH5s%2FSLc4uJ8TmBgGSzKzTkqhH5hezXPVFLGzx%2Bk3fo%2FVjUUWPuBKE%3D", System.Text.Encoding.GetEncoding("utf-8"));
                // var rets = RSADecrypt(key, res); 
                #endregion

                #region  微信公众号模板消息测试
                //WechatPublic wx = new WechatPublic();
                //List<Template> list = new List<Template>() {
                //    new Template {Name= "first", values=new Templatetext { value="first" } },
                //    new Template {Name= "tradeDateTime", values=new Templatetext { value="tradeDateTime" } },
                //    new Template {Name= "orderType", values=new Templatetext { value="orderType" } },
                //    new Template {Name= "orderItemName", values=new Templatetext { value="orderItemName" } },
                //};

                //wx.WeiXinTemplate("测试", "测试", list, "测试");

                #endregion 

                Console.Write("");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
