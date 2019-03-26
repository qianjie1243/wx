using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxTenpay;
using WxTenpay.wxconfig.wxconfiguration;
using BaiDuAI;


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
                BaiDu_CharacterRecognition ce = new BaiDu_CharacterRecognition();
                var result = ce.Getlicenseplate(@"E://新建文件夹/WxTenpay/ConsoleApplication1/111.png");
                var number = result["words_result"]["number"];
                Console.Write(result);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
