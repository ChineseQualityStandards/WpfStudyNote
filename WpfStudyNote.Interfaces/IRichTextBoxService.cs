using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace WpfStudyNote.Interfaces
{
    /// <summary>
    /// 富文本框数据相关的操作
    /// </summary>
    public interface IRichTextBoxService
    {
        /// <summary>
        /// 将富文本控件的文档流内容转换为UTF-8格式的字符串
        /// </summary>
        /// <param name="fd">需要读取的文档流</param>
        /// <returns>UTF-8格式的字符串</returns>
        public string GetStringInUTF8(FlowDocument fd);

        /// <summary>
        /// 将指定UTF-8格式的字符串加载到文档流中
        /// </summary>
        /// <param name="text">需要传入的字符串</param>
        /// <param name="fd">需要载入的文档流</param>
        public void LoadStringInUTF8(string text, FlowDocument fd);
    }
}
