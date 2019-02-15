using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace  Common
{
    public static class IListDataSet
    {
        /// <summary>
        /// DataSet 第一个表转换为实体类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ds"></param>
        /// <returns>实体类泛型集合</returns>
        public static List<T> ConvertToModel<T>(DataSet ds)
        {

            if (ds.Tables.Count>0 && ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            return ConvertToModel<T>(ds.Tables[0]);
        }
        /// <summary>
        /// DataTable 第一个表转换为实体类
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns>实体类泛型集合</returns>
        public static List<T> ConvertToModel<T>(DataTable dt)
        {
            List<T> l = new List<T>();

            foreach (DataRow dr in dt.Rows)
            {
                T model = Activator.CreateInstance<T>();

                foreach (DataColumn dc in dr.Table.Columns)
                {
                    PropertyInfo pi = model.GetType().GetProperty(dc.ColumnName);
                    if (pi == null) continue;
                    if (pi.CanWrite == false) continue;

                    try
                    {
                        if (dr[dc.ColumnName] != DBNull.Value)
                            pi.SetValue(model, dr[dc.ColumnName], null);
                        else
                            pi.SetValue(model, default(object), null);
                    }
                    catch
                    {
                        pi.SetValue(model, GetDefaultValue(dr[pi.Name], pi.PropertyType), null);
                    }

                }
                l.Add(model);
            }

            return l;
        }
        private static object GetDefaultValue(object obj, Type type)
        {
            if (obj == DBNull.Value)
            {
                return default(object);
            }
            else
            {
                return Convert.ChangeType(obj, type);
            }
        }
        //-----

    }

    
}