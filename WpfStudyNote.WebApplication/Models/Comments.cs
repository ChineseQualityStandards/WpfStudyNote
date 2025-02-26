using System.ComponentModel.DataAnnotations;

namespace WpfStudyNote.WebApplication.Models
{
    /// <summary>
    /// 评论表
    /// </summary>
    public class Comments
    {
        /// <summary>
        /// 评论ID
        /// </summary>
        [Key]
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
        public DateTime CreateAt { get; set; }
    }
}
