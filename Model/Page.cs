using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Page<T>
    {
        /// <summary>
        /// 当前页索引
        /// </summary>
        public long CurrentPage { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public long TotalPages { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public long TotalItems { get; set; }
        /// <summary>
        /// 每页的记录数
        /// </summary>
        public long ItemsPerPage { get; set; }
        /// <summary>
        /// 数据集
        /// </summary>
        public List<T> Items { get; set; }
    }


    /// <summary>
    /// 分页参数
    /// </summary>
    public class PageParm
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int page { get; set; } = 1;

        /// <summary>
        /// 每页总条数
        /// </summary>
        public int limit { get; set; } = 15;

    
    }
}
