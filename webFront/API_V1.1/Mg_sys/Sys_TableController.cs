using Business.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webFront.Models;
using System.Text;
using System.Web.Mvc;
using Model;
using System.IO;

namespace webFront.API
{
    /// <summary>
    /// 获取数据库表结构
    /// </summary>
    public class Sys_TableController : BaseController
    {
        #region  业务
        private TableType bll = new TableType();
        #endregion



        /// <summary>
        /// 获取表结构
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public object getTablelist()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"SELECT name FROM sysobjects WHERE xtype='U' AND name  <>  'dtproperties' order by name asc");
                var list = bll.DataSql(sb.ToString(), null).ToJson();
                return Success(list);
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "数据库表结构");
            }

        }

        /// <summary>
        /// 获取表结构
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet]
        public object getTableD(string tablename)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"SELECT
                            TbName =case when a.colorder = 1 then d.name else '' end, 
                            TbDesc =case when a.colorder = 1 then isnull(f.value,'') else '' end,
                            FieldIndex = a.colorder, 
                            FieldName = a.name, 
                            IsIdentity =case when COLUMNPROPERTY(a.id, a.name, 'IsIdentity') = 1 then '√'else '' end, 
                            IsKey =case when exists(SELECT 1 FROM sysobjects where xtype = 'PK' and name in (
                                 SELECT name FROM sysindexes WHERE indid in(
                                  SELECT indid FROM sysindexkeys WHERE id = a.id AND colid = a.colid
                               ))) then '√' else '' end, 
                            FiledType = b.name, 
                            ByteLength = a.length, 
                            FiledLength = COLUMNPROPERTY(a.id, a.name, 'PRECISION'), 
                            DecimalLength = isnull(COLUMNPROPERTY(a.id, a.name, 'Scale'), 0), 
                            IsNullable =case when a.isnullable = 1 then '√'else '' end, 
                            DefaultVal = isnull(e.text, ''), 
                            FieldDesc = isnull(g.[value], '')
                            FROM syscolumns a
                            left join systypes b on a.xtype = b.xusertype
                            inner join sysobjects d on a.id = d.id and d.xtype = 'U' and d.name <> 'dtproperties'
                            left join syscomments e on a.cdefault = e.id
                            left join sys.extended_properties g on a.id = g.major_id and a.colid = g.minor_id
                            left join sys.extended_properties f on d.id = f.major_id and f.minor_id = 0
                            where d.name = @tablename
                            order by a.id,a.colorder");

                return Success(bll.SelectSql(sb.ToString(), new { tablename = tablename }));
            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "数据库表结构");
            }

        }

        /// <summary>
        /// 生成实体
        /// </summary>
        /// <param name="tablename"></param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public object GenerateEntity(string tablename, string pathname)
        {
            var path = "";
            if (string.IsNullOrWhiteSpace(pathname)) path = System.Web.HttpContext.Current.Server.MapPath("/temp/entity");
            else
                path = Common.Base64.DecodeBase64(pathname);

            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(@"SELECT
                            TbName =case when a.colorder = 1 then d.name else '' end, 
                            TbDesc =case when a.colorder = 1 then isnull(f.value,'') else '' end,
                            FieldIndex = a.colorder, 
                            FieldName = a.name, 
                            IsIdentity =case when COLUMNPROPERTY(a.id, a.name, 'IsIdentity') = 1 then '√'else '' end, 
                            IsKey =case when exists(SELECT 1 FROM sysobjects where xtype = 'PK' and name in (
                                 SELECT name FROM sysindexes WHERE indid in(
                                  SELECT indid FROM sysindexkeys WHERE id = a.id AND colid = a.colid
                               ))) then '√' else '' end, 
                            FiledType = b.name, 
                            ByteLength = a.length, 
                            FiledLength = COLUMNPROPERTY(a.id, a.name, 'PRECISION'), 
                            DecimalLength = isnull(COLUMNPROPERTY(a.id, a.name, 'Scale'), 0), 
                            IsNullable =case when a.isnullable = 1 then '√'else '' end, 
                            DefaultVal = isnull(e.text, ''), 
                            FieldDesc = isnull(g.[value], '')
                            FROM syscolumns a
                            left join systypes b on a.xtype = b.xusertype
                            inner join sysobjects d on a.id = d.id and d.xtype = 'U' and d.name <> 'dtproperties'
                            left join syscomments e on a.cdefault = e.id
                            left join sys.extended_properties g on a.id = g.major_id and a.colid = g.minor_id
                            left join sys.extended_properties f on d.id = f.major_id and f.minor_id = 0
                            where d.name = @tablename
                            order by a.id,a.colorder");

                var tablelist = bll.SelectSql(sb.ToString(), new { tablename = tablename });//获取当前表结构
                if (tablelist.Count == 0) return Error("数据异常！");
                var entity = Entity();
                string content = "";
                foreach (var item in tablelist)
                {
                    string type = "string";
                    switch (item.FiledType)
                    {
                        case "varchar":
                            type = "string";
                            break;
                        case "nvarchar":
                            type = "string";
                            break;
                        case "int":
                            type = (item.IsNullable == "√" ? "int?" : "int");
                            break;
                        case "datetime":
                            type = (item.IsNullable == "√" ? "datetime?" : "datetime");
                            break;
                        case "decimal":
                            type = (item.IsNullable == "√" ? "decimal?" : "decimal");
                            break;
                        case "float":
                            type = (item.IsNullable == "√" ? "float?" : "float");
                            break;
                        case "money":
                            type = (item.IsNullable == "√" ? "float?" : "float");
                            break;

                    }

                    StringBuilder sbstring = new StringBuilder();
                    sbstring.Append("/// <summary>\r\n");
                    sbstring.Append("/// " + item.FieldDesc + "\r\n");
                    sbstring.Append("/// </summary>\r\n");
                    sbstring.Append("public " + type + " " + item.FieldName + " {set;get;} \r\n");

                    content += sbstring.ToString();
                }
                entity = entity.Replace("@tablename", tablelist[0].TbName );
                entity = entity.Replace("@content", content);
                //在将文本写入文件前，处理文本行
                //StreamWriter一个参数默认覆盖
                //StreamWriter第二个参数为false覆盖现有文件，为true则把文本追加到文件末尾
                //检查上传的物理路径是否存在，不存在则创建
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (StreamWriter file = new StreamWriter(path + "/" + tablelist[0].TbName + ".cs", false))
                {
                    file.WriteLine(entity);// 直接追加文件末尾，换行 
                }

                return Success("操作成功！");
            }
            catch (Exception ex)
            {

                return ErrorLog(ex, "数据库表生成实体");
            }


        }

        /// <summary>
        /// 生成业务
        /// </summary>
        /// <param name="tablename"></param>
        /// <param name="pathname"></param>
        /// <returns></returns>
        [HttpGet]
        public object GetBll(string tablename, string pathname)
        {
            try
            {
                var path = "";
                if (string.IsNullOrWhiteSpace(pathname)) path = System.Web.HttpContext.Current.Server.MapPath("/temp/bll");
                else
                    path = Common.Base64.DecodeBase64(pathname);



                string Ibll = GetBLLTemp(2);
                Ibll = Ibll.Replace("@name", tablename);

                string bll = GetBLLTemp();
                bll = bll.Replace("@name", tablename);
                bll = bll.Replace("@entity", tablename);
                //在将文本写入文件前，处理文本行
                //StreamWriter一个参数默认覆盖
                //StreamWriter第二个参数为false覆盖现有文件，为true则把文本追加到文件末尾
                //检查上传的物理路径是否存在，不存在则创建
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (StreamWriter file = new StreamWriter(path + "/" + tablename + ".cs", false))
                {
                    file.WriteLine(bll);// 直接追加文件末尾，换行 
                }

                using (StreamWriter file = new StreamWriter(path + "/I" + tablename + ".cs", false))
                {
                    file.WriteLine(Ibll);// 直接追加文件末尾，换行 
                }
                return Success("操作成功！");

            }
            catch (Exception ex)
            {
                return ErrorLog(ex, "数据库表生成实体");
            }

        }





        #region 其他操作
        /// <summary>
        /// 实体模板类型
        /// </summary>
        /// <returns></returns>
        private string Entity()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("using System;\r\n");
                sb.Append("using System.Collections.Generic;\r\n");
                sb.Append("using System.Linq;\r\n");
                sb.Append("using System.Text;\r\n");
                sb.Append("namespace Model\r\n");
                sb.Append("{\r\n");
                sb.Append(" public class @tablename\r\n");
                sb.Append("  {\r\n");
                sb.Append("   @content     \r\n");
                sb.Append("  }     \r\n");
                sb.Append("}     \r\n");


                return sb.ToString();

            }
            catch (Exception)
            {

                throw;
            }

        }

     

        /// <summary>
        /// 业务模板
        /// </summary>
        /// <returns></returns>
        private string GetBLLTemp(int type = 1)
        {
            if (type == 1)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("using Business.Service;\r\n");
                sb.Append("using Model;\r\n");
                sb.Append(" namespace Business.Business\r\n");
                sb.Append("{\r\n");
                sb.Append(" public class @name: BaseService<@entity>\r\n");
                sb.Append("  {\r\n");
                sb.Append("  \r\n");
                sb.Append("  }\r\n");
                sb.Append("}\r\n");
                return sb.ToString();
            }
            else
            {

                StringBuilder sb = new StringBuilder();
                sb.Append("using Business.Service;\r\n");
                sb.Append("using Model;\r\n");
                sb.Append(" namespace Business.IBusiness\r\n");
                sb.Append("{\r\n");
                sb.Append("  public interface @name\r\n");
                sb.Append("  {\r\n");
                sb.Append("  \r\n");
                sb.Append("  }\r\n");
                sb.Append("}\r\n");
                return sb.ToString();
            }

        }
        #endregion

    }
}