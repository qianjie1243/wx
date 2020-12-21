using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 表结构数据
    /// </summary>
    public class TableTypeEntity
    {
        /// <summary>
        /// 表名称
        /// </summary>
        public string TbName { set; get; } = "";
        /// <summary>
        /// 表备注
        /// </summary>
        public string TbDesc { set; get; } = "";
        /// <summary>
        /// 字段序号
        /// </summary>
        public string FieldIndex { set; get; } = "";
        /// <summary>
        /// 字段名称
        /// </summary>
        public string FieldName { set; get; } = "";
        /// <summary>
        /// 是否自增
        /// </summary>
        public string IsIdentity { set; get; } = "";
        /// <summary>
        /// 主键
        /// </summary>
        public string IsKey { set; get; } = "";
        /// <summary>
        /// 字段类型
        /// </summary>
        public string FiledType { set; get; } = "";
        /// <summary>
        /// 字节长度
        /// </summary>
        public string ByteLength { set; get; } = "";
        /// <summary>
        /// 提起长度
        /// </summary>
        public string FiledLength { set; get; } = "";
        /// <summary>
        /// 数字长度
        /// </summary>
        public string DecimalLength { set; get; } = "";
        /// <summary>
        /// 是否为空
        /// </summary>
        public string IsNullable { set; get; } = "";

        public string DefaultVal { set; get; } = "";
        /// <summary>
        /// 字段备注
        /// </summary>
        public string FieldDesc { set; get; } = "";
   
    }
}
