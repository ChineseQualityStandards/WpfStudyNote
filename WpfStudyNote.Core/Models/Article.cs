using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace WpfStudyNote.Core.Models
{
    /// <summary>
    /// 文章信息
    /// </summary>
    public class Article
    {
        /// <summary>
        /// 文章编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string? Title { get; set; }
        /// <summary>
        /// 文章描述
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        public string? Author { get; set; }
        /// <summary>
        /// 作者ID
        /// </summary>
        public string? AuthorId { get; set; }
        //public string? AuthorUrl { get; set; }
        /// <summary>
        /// 封面图片
        /// </summary>
        public string? CoverPicture {  get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        public string? Document { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public ObservableCollection<string>? Tags { get; set; }
    }
}
