using Business.Business;
using Business.IBusiness;
using Microsoft.Ajax.Utilities;
using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webFront.Models;
using System.Transactions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace webFront.API
{

    /// <summary>
    /// 获取菜单列表
    /// </summary>
    /// 
    public class Sys_MenuController : BaseController
    {

        #region  业务
        private Sys_log logbll = new Sys_log();
        private Sys_Menu Menubll = new Sys_Menu();
        private Sys_RoleAuthorization rolebll = new Sys_RoleAuthorization();
        private Sys_Button btnbll = new Sys_Button();
        #endregion


        /// <summary>
        /// 获取菜单配置
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public object GetAdminList(string token)
        {
            try
            {
                var usermolde = GetUserInfo(token);//获取用户信息

                var lis = Menubll.GetList().Where(x => x.IsDel == 0).ToList();
                var reslis = new List<Sys_MenuEntity>();
                if (usermolde.UserName.ToLower() == "system")//管理员显示全部列表数据
                {
                    foreach (var item in lis.Where(x => x.SuperiorId == "0").ToList())
                    {
                        item.PSysMenu = Getlis(lis, item);
                        reslis.Add(item);
                    }
                    var res = new
                    {
                        mnue = reslis.OrderBy(x => x.Sort),
                        model = usermolde
                    };
                    return Success(res);
                }
                else
                {//其他用户数据
                    var rolelist = rolebll.GetList(x => x.UserGid == usermolde.GuId, x => x.Id, 1);
                    foreach (var item in lis.Where(x => x.SuperiorId == "0" && rolelist.Where(m => m.MenuGid == x.GuId).Count() > 0).ToList())
                    {
                        item.PSysMenu = GetRolelis(lis, item, rolelist);
                        reslis.Add(item);
                    }
                    var res = new
                    {
                        mnue = reslis.OrderBy(x => x.Sort),
                        model = usermolde
                    };
                    return Success(res);

                }
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "菜单列表API");
            }
        }


        /// <summary>
        /// 获取菜单列表
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public object GetList()
        {
            try
            {
                var lis = Menubll.GetList().Where(x => x.IsDel == 0).Select(x =>
                {
                    return new
                    {
                        name = x.Name,
                        url = x.Address,
                        idx = x.Sort,
                        parentId = x.SuperiorId,
                        x.GuId,
                        x.Id,
                        x.Number
                    };

                }).OrderBy(c => c.idx).ToList();

                var res = new
                {
                    data = lis,
                    msg = true,
                    code = 0
                };
                return Json(res, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "菜单列表API");
            }
        }



        /// <summary>
        /// 获取菜单所有数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public object GetMenuLis()
        {
            try
            {
                var lis = Menubll.GetList().Where(x => x.IsDel == 0).ToList();
                return Success(lis);
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "获取菜单所有数据API");
            }

        }
        /// <summary>
        /// 保存数据
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public object SaveFrom(Sys_MenuEntity entity, List<Sys_ButtonEntity> btnlis)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(entity.GuId))
                {
                    var model = Menubll.GetModel(x => x.GuId == entity.GuId);
                    if (model != null)
                    {
                        using (TransactionScope tran = new TransactionScope())
                        {
                            btnbll.Delete(x => x.MenuId == model.GuId);

                            model.Name = entity.Name;
                            model.Address = entity.Address;
                            model.Number = entity.Number;
                            model.Sort = entity.Sort;
                            model.SuperiorId = entity.SuperiorId;
                            model.Type = entity.Type;
                            Menubll.Update(model);
                            if (btnlis != null)
                            {
                                foreach (var item in btnlis)//保存按钮事件
                                {
                                    item.MenuId = model.GuId;
                                    item.Create();
                                    btnbll.Add(item);
                                }
                            }
                            tran.Complete();
                        }
                        return SuccessLog("操作成功！", model, "菜单编辑", 2);
                    }
                    else
                        return Error("参数错误");
                }
                else
                {
                    using (TransactionScope tran = new TransactionScope())
                    {
                        entity.Create();
                        Menubll.Add(entity);
                        if (btnlis != null)
                        {
                            foreach (var item in btnlis)//保存按钮事件
                            {
                                item.MenuId = entity.GuId;
                                item.Create();
                                btnbll.Add(item);
                            }
                        }
                        tran.Complete();
                    }
                    return SuccessLog("操作成功！", entity, "菜单编辑", 1);
                }
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "编辑菜单API");
            }
        }


        /// <summary>
        /// 获取菜单详情
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public object GetDes(string Keyvalue)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Keyvalue)) return Error("参数错误！");

                var model = Menubll.GetModel(x => x.GuId == Keyvalue);
                if (model != null) {
                    model.buttons = btnbll.GetList(x => x.MenuId == model.GuId);
                }
                return Success(model);

            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "获取菜单详情API");
            }
        }

        /// <summary>
        /// 移除数据
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpPost]
        public object Delete(string Keyvalue)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Keyvalue))
                {
                    var model = Menubll.GetModel(x => x.GuId == Keyvalue);
                    if (model != null)
                    {
                        model.IsDel = 1;
                        Menubll.Update(model);
                        return SuccessLog("操作成功！", model, "菜单编辑", 3);
                    }
                    else
                        return Error("参数错误");
                }
                else
                    return Error("参数错误");




            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "移除菜单API");
            }
        }





        #region 扩展方法
        /// <summary>
        /// system 获取权限
        /// </summary>
        /// <param name="countlis"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        private List<Sys_MenuEntity> Getlis(List<Sys_MenuEntity> countlis, Sys_MenuEntity model)
        {
            try
            {
                List<Sys_MenuEntity> fff = new List<Sys_MenuEntity>();

                var lis = countlis.Where(p => p.SuperiorId == model.Id.ToString());
                if (lis.Count() > 0)
                {
                    lis.ForEach(x =>
                    {
                        x.PSysMenu = Getlis(countlis, x).OrderBy(c => c.Sort).ToList();
                        x.buttons= btnbll.GetList(l => l.MenuId == x.GuId);//获取全部设置的按钮事件
                    });
                    return lis.OrderBy(c => c.Sort).ToList();
                }
                else
                    return fff;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// 其他用户获取权限
        /// </summary>
        /// <param name="countlis">全部菜单列表</param>
        /// <param name="model">当前对象</param>
        /// <param name="roles">授权列表</param>
        /// <returns></returns>
        private List<Sys_MenuEntity> GetRolelis(List<Sys_MenuEntity> countlis, Sys_MenuEntity model, List<Sys_RoleAuthorizationEntity> roles)
        {
            try
            {
                List<Sys_MenuEntity> fff = new List<Sys_MenuEntity>();

                var lis = countlis.Where(p => p.SuperiorId == model.Id.ToString() && roles.Where(m => m.MenuGid == p.GuId).Count() > 0);
                if (lis.Count() > 0)
                {
                  

                    lis.ForEach(x =>
                    {
                        x.buttons = new List<Sys_ButtonEntity>();
                        var Authorization = roles.Where(m => m.MenuGid ==x.GuId).FirstOrDefault();//获取授权功能菜单
                        x.PSysMenu = GetRolelis(countlis, x, roles).OrderBy(c => c.Sort).ToList();
                        if (Authorization.ButtonLis != null)
                        {
                            var ja = (JArray)JsonConvert.DeserializeObject(Authorization.ButtonLis);

                            foreach (var item in ja)
                            {
                                var btnmodel = btnbll.GetModel(l => l.GuId == item.ToString());
                                x.buttons.Add(btnmodel);
                            };
                        }

                    });
                    return lis.OrderBy(c => c.Sort).ToList();
                }
                else
                    return fff;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion

    }
}