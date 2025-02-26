
using Microsoft.EntityFrameworkCore;
using WpfStudyNote.WebApplication.Models;

namespace WpfStudyNote.WebApplication.DbContexts
{
    public class WebApplicationDbContext : DbContext
    {
        public WebApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        /// <summary>
        /// 用户表
        /// </summary>
        public DbSet<Accounts> Accounts => Set<Accounts>();
        /// <summary>
        /// 文章表
        /// </summary>
        public DbSet<Articles> Articles => Set<Articles>();
        /// <summary>
        /// 文章标签关系表
        /// </summary>
        public DbSet<ArticleTags> ArticleTags => Set<ArticleTags>();
        /// <summary>
        /// 分类表
        /// </summary>
        public DbSet<Categories> Categories => Set<Categories>();
        /// <summary>
        /// 评论表
        /// </summary>
        public DbSet<Comments> Comments => Set<Comments>();
        /// <summary>
        /// 标签表
        /// </summary>
        public DbSet<Tags> Tags => Set<Tags>();
    }
}
