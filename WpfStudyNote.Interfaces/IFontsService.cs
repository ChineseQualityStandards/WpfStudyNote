using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfStudyNote.Core.Models;

namespace WpfStudyNote.Interfaces
{
    /// <summary>
    /// 字体属性服务
    /// </summary>
    public interface IFontsService
    {
        /// <summary>
        /// 获取字体属性
        /// </summary>
        /// <returns>FontsProperties</returns>
        public FontsProperties GetFontsProperties();
    }
}
