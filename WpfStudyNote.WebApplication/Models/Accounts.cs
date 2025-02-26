using System.ComponentModel.DataAnnotations;

namespace WpfStudyNote.WebApplication.Models
{
    /// <summary>
    /// 用户类
    /// </summary>
    public class Accounts
    {
        /// <summary>
        /// 用户主键ID
        /// </summary>
        [Key]
        public int AccountId { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        ///
        [MinLength(3)]
        [MaxLength(50)]
        public string? AccountName { get; set; }

        /// <summary>
        /// 邮箱  
        /// </summary>
        [MaxLength(100)]
        public string? Email { get; set; }

        /// <summary>
        /// 哈希密码
        /// </summary>
        [MaxLength(100)]
        public string? PasswordHash { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
