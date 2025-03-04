using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStudyNote.Core.Models
{
    /// <summary>
    /// 分类表
    /// </summary>
    public class Categories
    {
        /// <summary>
        /// 分类ID
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string? CategoryName { get; set; }
    }
}
