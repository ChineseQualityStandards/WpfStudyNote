using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStudyNote.Core.Models
{
    /// <summary>
    /// 字体属性
    /// </summary>
    public class FontsProperties
    {
        public ObservableCollection<string>? FontFamily { get; set; } = new ObservableCollection<string>();
        /// <summary>
        /// 存储字体大小的集合
        /// </summary>
        public ObservableCollection<float>? FontSize { get; set; } = new ObservableCollection<float>();
    }
}
