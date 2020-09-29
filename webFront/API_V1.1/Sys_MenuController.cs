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
        #endregion


        /// <summary>
        /// 获取菜单配置
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public object GetAdminList()
        {
            try
            {
                var lis = Menubll.GetList().Where(x => x.IsDel == 0).ToList();
                var reslis = new List<Sys_MenuEntity>();
                foreach (var item in lis.Where(x => x.SuperiorId == "0").ToList())
                {
                    item.PSysMenu = Getlis(lis, item);
                    reslis.Add(item);
                }

                var res = new
                {
                    mnue = reslis.OrderBy(x => x.Sort),
                    lis
                };
                return Success(res);

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

                }).ToList();

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
        public object GetMenuLis() {
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
        public object SaveFrom(Sys_MenuEntity entity, string Keyvalue)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Keyvalue))
                {
                    var model = Menubll.GetModel(x => x.GuId == Keyvalue);
                    if (model != null)
                    {
                        model.Name = entity.Name;
                        model.Address = entity.Address;
                        model.Number = entity.Number;
                        model.Sort = entity.Sort;
                        model.SuperiorId = entity.SuperiorId;
                        model.Type = entity.Type;
                        Menubll.Update(model);
                    }
                    else
                        return Error("参数错误");
                }
                else
                {
                    entity.Create();
                    Menubll.Add(entity);
                }

                return Success("操作成功！");

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
                    }
                    else
                        return Error("参数错误");
                }
                else
                    return Error("参数错误");

                return Success("操作成功！");

            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "移除菜单API");
            }
        }



        #region 扩展方法
        private List<Sys_MenuEntity> Getlis(List<Sys_MenuEntity> countlis, Sys_MenuEntity model) {
            try
            {
                List<Sys_MenuEntity> fff = new List<Sys_MenuEntity>();

                var lis = countlis.Where(p => p.SuperiorId == model.Id.ToString());
                if (lis.Count() > 0)
                {
                    lis.ForEach(x =>
                    {
                        x.PSysMenu = Getlis(countlis, x).OrderBy(c=>c.Sort).ToList();
                    });
                    return lis.ToList();
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