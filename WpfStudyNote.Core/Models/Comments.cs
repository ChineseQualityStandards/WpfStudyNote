using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStudyNote.Core.Models
{
    /// <summary>
    /// 评论表
    /// </summary>
    public class Comments
    {
        /// <summary>
        /// 评论ID
        /// </summary>
        public int CommentId { get; set; }

        /// <summary>
        /// 关联文章ID
        /// </summary>
        public int ArticleId { get; set; }

        /// <summary>
        /// 作者ID
        /// </summary>
        public int AccountId { get; set; }

        /// <summary>
        /// 评论内容
        /// </summary>
        public string? Content { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
