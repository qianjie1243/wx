using Business.Business;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using webFront.Models;

namespace webFront.API_V1._1
{
    /// <summary>
    /// 获取用户数据
    /// </summary>
    public class SysUserApiController : BaseController
    {
        #region 业务数据
        private Sys_User userbull = new Sys_User();
        private Sys_Menu Menubll = new Sys_Menu();
        private Sys_RoleAuthorization rolebll = new Sys_RoleAuthorization();
        private Sys_Button btnbll = new Sys_Button();
        private string dkey = "SYS_USER";
        #endregion

        #region 登入数据
        /// <summary>
        /// 登入验证
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public object login(string username, string userpwd, string verifyCode)
        {
            try
            {
                if (Session["CheckCode"].IsEmpty())
                {
                    return Error("验证码失效！");
                }
                var code = Session["CheckCode"].ToString();
                if (code.ToUpper() != verifyCode.ToUpper().Trim())
                    return Error("验证码错误！");
                else
                    Session["CheckCode"] = null;//清空验证码


                var model = userbull.GetModel(x => x.UserName == username && x.Pwd == userpwd);
                if (model.Id<0)
                {
                    return Error("用户名或密码错误！");
                }

                if (model.EncryPwd != DESEncrypt.Encrypt(model.Pwd, model.key))
                {
                    return Error("用户名或密码错误！");
                }

                if (model.IsDel == 1) {
                    return Error("对不起您的账号已被禁用，请联系管理员！");
                }
                var Endata = new
                {
                    model.Name,
                    model.Id,
                    model.GuId,
                    model.NickName,
                    model.Phone,
                    model.UserName,
                    LogTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")//登入时间
                };
                var data = new
                {
                    token = DESEncrypt.MD5Encrypt(Endata.ToJson(), dkey),
                };
                return Success(data);
            }
            catch (Exception ex)
            {

                return Error(ex.Message);
            }
        }
        #endregion

        #region 获取图片验证码
        /// <summary>
        /// 获取图片验证码
        /// </summary>
        /// <returns></returns>
        public object GetValidateCode()
        {
            try
            {
                var code = CreateRandomCode(4);//随机数
                Session["CheckCode"] = code;//保存数据
                return File(CreateValidateGraphic(code), "image/Jpeg");
            }
            catch (Exception ex)
            {
                return Error(ex.Message);
            }
        }
        #endregion

        #region 创建验证码图片
        /// <summary>
        /// 生成随机的字符串
        /// </summary>
        /// <param name="codeCount"></param>
        /// <returns></returns>
        public string CreateRandomCode(int codeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,a,b,c,d,e,f,g,h,i,g,k,l,m,n,o,p,q,r,F,G,H,I,G,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,s,t,u,v,w,x,y,z";
            string[] allCharArray = allChar.Split(',');
            int temp = -1;
            string randomCode = "";
            Random rand = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                if (temp != -1)
                {
                    rand = new Random(i * temp * ((int)DateTime.Now.Ticks));
                }
                int t = rand.Next(35);
                if (temp == t)
                {
                    return CreateRandomCode(codeCount);
                }
                temp = t;
                randomCode += allCharArray[t];
            }
            return randomCode;
        }

        /// <summary>
        /// 创建验证码图片
        /// </summary>
        /// <param name="validateCode"></param>
        /// <returns></returns>
        public byte[] CreateValidateGraphic(string validateCode)
        {
            Bitmap image = new Bitmap((int)Math.Ceiling(validateCode.Length * 16.0), 27);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器
                Random random = new Random();
                //清空图片背景色
                g.Clear(Color.White);
                //画图片的干扰线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, x2, y1, y2);
                }
                Font font = new Font("Arial", 13, (FontStyle.Bold | FontStyle.Italic));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(validateCode, font, brush, 3, 2);

                //画图片的前景干扰线
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                //保存图片数据
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);

                //输出图片流
                return stream.ToArray();
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }

        #endregion


        #region 用户管理
        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public object GetPageList(PageParm parm, string queryjson)
        {
            try
            {
                var query = queryjson.ToJObject();
                #region 
                var expression = LinqExtensions.True<Sys_UserEntity>();
                expression = expression.And(t => t.IsDel>-1);//不显示超级管理员
                if (!query["Name"].IsEmpty())
                {
                    expression = expression.And(t => t.Name.Contains(query["Name"].ToString()));
                }
                if (!query["IsDel"].IsEmpty())
                {
                    expression = expression.And(t => t.IsDel.ToString() == query["IsDel"].ToString());
                }
                if (!query["UserName"].IsEmpty())
                {
                    expression = expression.And(t => t.UserName.ToString().Contains( query["UserName"].ToString()));
                }
                if (!query["NickName"].IsEmpty())
                {
                    expression = expression.And(t => t.NickName.ToString().Contains(query["NickName"].ToString()));
                }
                #endregion
                return Success(userbull.GetPages(parm, expression, x => x.CreateTime, 2));
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "用户管理");
            }

        }


        /// <summary>
        /// 获取用户详情
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public object GetDetails(string Keyvalue)
        {
            try
            {
                var model = userbull.GetModel(x => x.GuId == Keyvalue);
                return Success(model);
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "用户管理");
            }

        }

        /// <summary>
        /// 禁用用户
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public object GetDelete(string Keyvalue)
        {
            try
            {
                var model = userbull.GetModel(x => x.GuId == Keyvalue);
                model.IsDel = 1;
                userbull.Update(model);
                return Success("操作成功！");
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "用户管理");
            }

        }


        /// <summary>
        /// 编辑用户
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public object SaveFrom(Sys_UserEntity entity)
        {
            try
            {
                entity.UserName = entity.UserName.Trim();
                if (string.IsNullOrWhiteSpace(entity.GuId))
                { //新增

                    if (userbull.GetModel(x => x.UserName == entity.UserName).Id>0)
                    {
                        return Error("对不起您的用户名已存在！");
                    }
                    entity.key = CreateRandomCode(15);
                    entity.EncryPwd = DESEncrypt.Encrypt(entity.Pwd, entity.key);
                    entity.Create();
                    userbull.Add(entity);
                }
                else { //编辑
                    var model = userbull.GetModel(x => x.GuId == entity.GuId);
                    model.Name = entity.Name;
                    model.NickName = entity.NickName;
                    model.Phone = entity.Phone;
                    if (model.Pwd != entity.Pwd)
                    {
                        model.Pwd = entity.Pwd;
                        model.EncryPwd = DESEncrypt.Encrypt(entity.Pwd, model.key);
                    }
                    if (model.UserName != entity.UserName)
                    {
                        model.UserName = entity.UserName;
                        if (userbull.GetModel(x => x.UserName == entity.UserName).Id > 0) {
                            return Error("对不起您的用户名已存在！");
                        }
                    }
                  
                    userbull.Update(model);
                }            
                return Success("操作成功！");
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "用户管理");
            }

        }

        /// <summary>
        /// 解开用户
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public object GetUnlock(string Keyvalue)
        {
            try
            {
                var model = userbull.GetModel(x => x.GuId == Keyvalue);
                model.IsDel = 0;
                userbull.Update(model);
                return Success("操作成功！");
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "用户管理");
            }

        }



        /// <summary>
        /// 获取授权用户数据
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public object GetUserMenuList(string keyvalue)
        {
            try
            {


                var model = userbull.GetModel(x => x.GuId == keyvalue);
                var rolelist = rolebll.GetList(x => x.UserGid == model.GuId);
                List<string> Menuids = new List<string>();
                var lis = Menubll.GetList(x => x.IsDel == 0).Select(x =>
                {
                    var checkbtns = "[]";
                    var rolemodel = rolelist.Where(m => m.MenuGid == x.GuId).FirstOrDefault();
                    if (rolemodel!=null)
                    {
                        Menuids.Add(x.Id.ToString());
                        checkbtns = rolemodel.ButtonLis;
                    }
                    return new
                    {
                        name = x.Name,
                        url = x.Address,
                        idx = x.Sort,
                        parentId = x.SuperiorId,
                        x.GuId,
                        x.Id,
                        x.Number,
                        buttons = btnbll.GetList(a => a.MenuId == x.GuId),
                        checkbtns = checkbtns,
                    };

                }).OrderBy(c => c.idx).ToList();
                var res = new
                {
                    ids = Menuids,
                    data = lis,
                    //msg = true,
                    //code = 0
                };
                return Success(res);
             //   return Json(res, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "菜单列表API");
            }
        }


        /// <summary>
        /// 获取授权用户数据
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public object AddUserMenu(string keyvalue,string[] ids,List<checks> ches )
        {
            try
            {
                List<Sys_RoleAuthorizationEntity> lis = new List<Sys_RoleAuthorizationEntity>();
                var model = userbull.GetModel(x => x.GuId == keyvalue);
                if (model.Id < 0)
                    return Error("用户数据异常！");
                rolebll.Delete(x=>x.UserGid==model.GuId);//移除全部权限重新配置
                var Menulist = Menubll.GetList(x => x.IsDel == 0);
                foreach (var item in ids) {
                  var menumodel=  Menulist.Where(x => x.Id.ToString() == item).FirstOrDefault();
                    if (menumodel != null)
                    {
                        var ButtonLis = "[]";
                        if (ches != null)
                        {
                            var chemodel = ches.Where(p => p.fguid == item).FirstOrDefault();                          
                            if (chemodel != null)
                            {
                                ButtonLis = (chemodel.btnlis == null ? "[]" : chemodel.btnlis.ToJson());
                            }
                        }
                        Sys_RoleAuthorizationEntity entity = new Sys_RoleAuthorizationEntity();
                        entity.MenuGid = menumodel.GuId;
                        entity.UserGid = model.GuId;
                        entity.ButtonLis = ButtonLis;
                        entity.Create();
                        lis.Add(entity);

                    }
                }
                rolebll.AddList(lis);
                return Success("操作成功！");

            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "配置用户权限");
            }
        }
        #endregion


    }


    public class checks {
        public string fguid { set; get; } = "";

        public string[] btnlis { set; get; }
    }
}