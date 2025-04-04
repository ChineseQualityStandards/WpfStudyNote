﻿using System.ComponentModel.DataAnnotations;

namespace WpfStudyNote.WebApplication.Models
{
    /// <summary>
    /// 分类表
    /// </summary>
    public class Categories
    {
        /// <summary>
        /// 分类ID
        /// </summary>
        [Key]
        public int CategoryId { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string? CategoryName { get; set; }
    }
}
