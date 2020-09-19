using DB;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Business.Service
{
    public class BaseService<T> : DbContext where T : class, new()
    {
        #region 添加操作
        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="parm">T</param>
        /// <returns></returns>
        public int Add(T parm)
        {
            try
            {
                return Db.Insertable<T>(parm).ExecuteCommand();
            }
            catch (Exception ex)
            {
                throw;

            }
        }

        /// <summary>
        /// 批量添加数据
        /// </summary>
        /// <param name="parm">List<T></param>
        /// <returns></returns>
        public int AddList(List<T> parm)
        {
            try
            {
                return Db.Insertable<T>(parm).ExecuteCommand();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region 查询操作
        /// <summary>
        /// 获得一条数据
        /// </summary>
        /// <param name="where">Expression<Func<T, bool>></param>
        /// <returns></returns>
        public T GetModel(Expression<Func<T, bool>> where)
        {
            try
            {
                return Db.Queryable<T>().Where(where).First() ?? new T() { };
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// 获得一条数据
        /// </summary>
        /// <param name="parm">string</param>
        /// <returns></returns>
        public T GetModel(string parm)
        {
            try
            {
                return Db.Queryable<T>().Where(parm).First() ?? new T() { };
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
		/// 获得列表——分页
		/// </summary>
		/// <param name="parm">PageParm</param>
		/// <returns></returns>
        public Page<T> GetPages(PageParm parm)
        {
            try
            {
                return Db.Queryable<T>().ToPage(parm.page, parm.limit);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 分页
        /// </summary>
        /// <param name="parm">分页参数</param>
        /// <param name="where">条件</param>
        /// <param name="order">排序值</param>
        /// <param name="orderEnum">排序方式OrderByType</param>
        /// <returns></returns>
        public Page<T> GetPages(PageParm parm, Expression<Func<T, bool>> where,
            Expression<Func<T, object>> order, int orderEnum)
        {

            try
            {
                var query = Db.Queryable<T>()
                        .Where(where)
                        .OrderByIF((int)orderEnum == 1, order, SqlSugar.OrderByType.Asc)
                        .OrderByIF((int)orderEnum == 2, order, SqlSugar.OrderByType.Desc);
                return query.ToPage(parm.page, parm.limit);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        /// <summary>
		/// 获得列表
		/// </summary>
		/// <param name="parm">PageParm</param>
		/// <returns></returns>
        public List<T> GetList(Expression<Func<T, bool>> where,
            Expression<Func<T, object>> order, int OrderByType)
        {
            try
            {
                var query = Db.Queryable<T>()
                        .Where(where)
                        .OrderByIF(OrderByType == 1, order, SqlSugar.OrderByType.Asc)
                        .OrderByIF(OrderByType == 2, order, SqlSugar.OrderByType.Desc);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 获得列表，不需要任何条件
        /// </summary>
        /// <returns></returns>
        public List<T> GetList()
        {

            try
            {
                return Db.Queryable<T>().ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region 修改操作
        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="parm">T</param>
        /// <returns></returns>
        public int Update(T parm)
        {
            try
            {
                return Db.Updateable<T>(parm).ExecuteCommand();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="parm">T</param>
        /// <returns></returns>
        public int Update(List<T> parm)
        {

            try
            {
                return Db.Updateable<T>(parm).ExecuteCommand();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        /// <summary>
        /// 修改一条数据，可用作假删除
        /// </summary>
        /// <param name="columns">修改的列=Expression<Func<T,T>></param>
        /// <param name="where">Expression<Func<T,bool>></param>
        /// <returns></returns>
        public int Update(Expression<Func<T, T>> columns,
            Expression<Func<T, bool>> where)
        {

            try
            {
                return Db.Updateable<T>().SetColumns(columns).Where(where).ExecuteCommand();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        #endregion

        #region 删除操作
        /// <summary>
        /// 删除一条或多条数据
        /// </summary>
        /// <param name="parm">string</param>
        /// <returns></returns>
        public int Delete(string parm)
        {
            try
            {
                var list = parm.Split(',');
                return Db.Deleteable<T>().In(list).ExecuteCommand();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除一条或多条数据
        /// </summary>
        /// <param name="where">Expression<Func<T, bool>></param>
        /// <returns></returns>
        public int Delete(Expression<Func<T, bool>> where)
        {

            try
            {
                return Db.Deleteable<T>().Where(where).ExecuteCommand();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        #endregion

        #region 查询Count
        public int Count(Expression<Func<T, bool>> where)
        {

            try
            {
                return Db.Queryable<T>().Count(where);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region 是否存在
        public bool IsExist(Expression<Func<T, bool>> where)
        {

            try
            {
                return Db.Queryable<T>().Any(where);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion
    }


    public static class QueryableExtension
    {

        /// <summary>
        /// 读取列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="isOrderBy"></param>
        /// <returns></returns>
        public static Page<T> ToPage<T>(this ISugarQueryable<T> query,
                int pageIndex,
                int pageSize,
                bool isOrderBy = false)
        {
            var page = new Page<T>();
            var totalItems = 0;
            page.Items = query.ToPageList(pageIndex, pageSize, ref totalItems);
            var totalPages = totalItems != 0 ? (totalItems % pageSize) == 0 ? (totalItems / pageSize) : (totalItems / pageSize) + 1 : 0;
            page.CurrentPage = pageIndex;
            page.ItemsPerPage = pageSize;
            page.TotalItems = totalItems;
            page.TotalPages = totalPages;
            return page;
        }
    }

}
