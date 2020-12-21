using Business.IBusiness;
using Business.Service;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business
{
  public  class Sys_log : BaseService<Sys_logEntity>
    {
        #region 扩展

        #endregion

        #region 基础查询
  //      #region 添加操作
  //      /// <summary>
  //      /// 添加一条数据
  //      /// </summary>
  //      /// <param name="parm">T</param>
  //      /// <returns></returns>
  //      public int _Add(Sys_logEntity parm)
  //      {
  //          try
  //          {
  //              return Add(parm);
  //          }
  //          catch (Exception ex)
  //          {
  //              throw;
  //          }
  //      }
  //      #endregion


  //      #region 查询操作
  //      /// <summary>
  //      /// 获得一条数据
  //      /// </summary>
  //      /// <param name="where">Expression<Func<T, bool>></param>
  //      /// <returns></returns>
  //      public Sys_logEntity _GetModel(Expression<Func<Sys_logEntity, bool>> where)
  //      {
  //          try
  //          {
  //             // Expression<Func<Sys_logEntity, bool>> where = null;
  //              return GetModel(where);
  //          }
  //          catch (Exception)
  //          {
  //              throw;
  //          }
  //      }

  //      /// <summary>
  //      /// 获得一条数据
  //      /// </summary>
  //      /// <param name="parm">string</param>
  //      /// <returns></returns>
  //      public Sys_logEntity _GetModel(string parm)
  //      {
  //          try
  //          {
  //              return GetModel(parm);
  //          }
  //          catch (Exception)
  //          {
  //              throw;
  //          }
  //      }

  //      /// <summary>
  //      /// 分页
  //      /// </summary>
  //      /// <param name="parm">分页参数</param>
  //      /// <param name="where">条件</param>
  //      /// <param name="order">排序值</param>
  //      /// <param name="orderEnum">排序方式OrderByType</param>
  //      /// <returns></returns>
  //      public Page<Sys_logEntity> _GetPages(PageParm parm, int orderEnum, Expression<Func<Sys_logEntity, bool>> where, Expression<Func<Sys_logEntity, object>> order)
  //      {

  //          try
  //          {
  //              //Expression<Func<Sys_logEntity, bool>> where = null;
  //              //Expression<Func<Sys_logEntity, object>> order = null;

  //              return GetPages(parm, where, order, orderEnum);
  //          }
  //          catch (Exception ex)
  //          {
  //              throw;
  //          }

  //      }

  //      /// <summary>
		///// 获得列表
		///// </summary>
		///// <param name="parm">PageParm</param>
		///// <returns></returns>
  //      public List<Sys_logEntity> _GetList(int OrderByType, Expression<Func<Sys_logEntity, bool>> where, Expression<Func<Sys_logEntity, object>> order)
  //      {
  //          try
  //          {
  //              //Expression<Func<Sys_logEntity, bool>> where = null;
  //              //Expression<Func<Sys_logEntity, object>> order = null;
  //              return GetList(where, order, OrderByType);
  //          }
  //          catch (Exception ex)
  //          {
  //              throw;
  //          }
  //      }

  //      /// <summary>
  //      /// 获得列表，不需要任何条件
  //      /// </summary>
  //      /// <returns></returns>
  //      public List<Sys_logEntity> _GetList()
  //      {

  //          try
  //          {
  //              return GetList();
  //          }
  //          catch (Exception ex)
  //          {
  //              throw;
  //          }
  //      }
  //      #endregion

  //      #region 修改操作
  //      /// <summary>
  //      /// 修改一条数据
  //      /// </summary>
  //      /// <param name="parm">T</param>
  //      /// <returns></returns>
  //      public int _Update(Sys_logEntity parm)
  //      {
  //          try
  //          {
  //              return Update(parm);
  //          }
  //          catch (Exception ex)
  //          {
  //              throw;
  //          }
  //      }

  //      /// <summary>
  //      /// 批量修改
  //      /// </summary>
  //      /// <param name="parm">T</param>
  //      /// <returns></returns>
  //      public int _Update(List<Sys_logEntity> parm)
  //      {

  //          try
  //          {
  //              return Update(parm);
  //          }
  //          catch (Exception ex)
  //          {
  //              throw;
  //          }

  //      }


  //      #endregion

  //      #region 删除操作


  //      /// <summary>
  //      /// 删除一条或多条数据
  //      /// </summary>
  //      /// <param name="where">Expression<Func<T, bool>></param>
  //      /// <returns></returns>
  //      public int _Delete(Expression<Func<Sys_logEntity, bool>> where)
  //      {

  //          try
  //          {
  //              return Delete(where);
  //          }
  //          catch (Exception ex)
  //          {
  //              throw;
  //          }

  //      }
  //      #endregion

  //      #region 是否存在
  //      public bool _IsExist(Expression<Func<Sys_logEntity, bool>> where)
  //      {

  //          try
  //          {
  //              return _IsExist(where);
  //          }
  //          catch (Exception ex)
  //          {
  //              throw;
  //          }
  //      }
  //      #endregion
        #endregion
    }
}
