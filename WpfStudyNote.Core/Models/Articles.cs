using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using WpfStudyNote.Core.Constants;

namespace WpfStudyNote.Core.Models
{
    /// <summary>
    /// 文章表
    /// </summary>
    public class Articles
    {
        /// <summary>
        /// 文章主键
        /// </summary>
        [Key]
        public int ArticleId { get; set; }

        /// <summary>
        /// 文章标题
        /// </summary>
        [MaxLength(255)]
        public string? Title { get; set; }

        /// <summary>
        /// 文章内容
        /// </summary>
        public string? Content { get; set; }

        /// <summary>
        /// 封面图片
        /// </summary>
        public string? CoverPicture { get; set; }

        /// <summary>
        /// 文章简介
        /// </summary>
        public string? Introduction { get; set; }

        /// <summary>
        /// 作者ID
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// 分类ID
        /// </summary>
        public int CategoryId { get; set; }
    }
}
