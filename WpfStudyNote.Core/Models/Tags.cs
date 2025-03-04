using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStudyNote.Core.Models
{
    /// <summary>
    /// 标签表
    /// </summary>
    public class Tags
    {
        /// <summary>
        /// 标签ID
        /// </summary>
        public int TagId { get; set; }

        /// <summary>
        /// 标签名称
        /// </summary>
        public string? TagName { get; set; }
    }
}
