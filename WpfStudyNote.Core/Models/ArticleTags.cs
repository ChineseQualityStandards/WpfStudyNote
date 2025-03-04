using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStudyNote.Core.Models
{
    /// <summary>
    /// 文章标签关系表
    /// </summary>
    public class ArticleTags
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int ArticleTagId { get; set; }

        /// <summary>
        /// 文章ID
        /// </summary>
        public int ArticleId { get; set; }

        /// <summary>
        /// 标签ID
        /// </summary>
        public int TagId { get; set; }
    }
}
