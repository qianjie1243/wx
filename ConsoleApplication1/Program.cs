using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WxTenpay;
using WxTenpay.wxconfig.wxconfiguration;

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
            Wechat_Menu wx = new Wechat_Menu();

            List<MenuModel> list = new List<MenuModel> { new MenuModel {name="cesi",url= "https://baidu.com",type="view" }, new MenuModel { name = "cesi", url = "https://baidu.com", type = "view" } };

            List<MenuModel> _MenuParameter = new List<MenuModel>();//多按钮列表

            MenuModel model = new MenuModel();
            model.name = "测试";
            model.type = "view";
            model.url = "https://baidu.com";
            _MenuParameter.Add(model);

            MenuModel model2 = new MenuModel();
            model2.name = "测试";
            model2.type = "view";
            model2.url = "https://baidu.com";
            _MenuParameter.Add(model2);

            MenuModel _model = new MenuModel();
            _model.name = "测试1";
            _model.sub_button = _MenuParameter;
            list.Add(_model);

            Dictionary<string, object> diy = new Dictionary<string, object>();
            diy.Add("button",list);
            wx.Menu(diy, 1);
        }
    }
}
