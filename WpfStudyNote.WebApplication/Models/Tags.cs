using System.ComponentModel.DataAnnotations;

namespace WpfStudyNote.WebApplication.Models
{
    /// <summary>
    /// 标签表
    /// </summary>
    public class Tags
    {
        /// <summary>
        /// 标签ID
        /// </summary>
        [Key]
        public int TagId { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        [MaxLength(50)]
        public string? TagName { get; set; }
    }
}
