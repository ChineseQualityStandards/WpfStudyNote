using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WpfStudyNote.WebApplication.Models
{
    /// <summary>
    /// 文章标签关系表
    /// </summary>
    [Keyless]
    public class ArticleTags
    {
        /// <summary>
        /// 文章ID
        /// </summary>
        [Key]
        public int ArticleId { get; set; }

        /// <summary>
        /// 标签ID
        /// </summary>
        [Key]
        public int TagId { get; set; }
    }
}
