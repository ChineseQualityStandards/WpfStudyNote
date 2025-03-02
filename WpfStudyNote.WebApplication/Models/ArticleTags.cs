using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WpfStudyNote.WebApplication.Models
{
    /// <summary>
    /// 文章标签关系表
    /// </summary>
    public class ArticleTags
    {
        [Key]
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
