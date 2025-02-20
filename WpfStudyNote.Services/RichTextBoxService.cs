using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using WpfStudyNote.Interfaces;

namespace WpfStudyNote.Services
{
    public class RichTextBoxService : IRichTextBoxService
    {
        public string GetStringInUTF8(FlowDocument fd)
        {
            // 定义一个承载数据的字符串
            string result;
            // 从富文本控件中读取需要的内容
            TextRange textRange = new TextRange(fd.ContentStart, fd.ContentEnd);
            // 通过MemoryStream转换数据
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // 从textRange读取数据流
                textRange.Save(memoryStream, DataFormats.Rtf);
                // 将数据流转换为UTF-8格式的字符串
                result = Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            return result;
        }

        public void LoadStringInUTF8(string text,FlowDocument fd)
        {
            TextRange textRange = new TextRange(fd.ContentStart, fd.ContentEnd);
            using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(text)))
            {
                textRange.Load(memoryStream, DataFormats.Rtf);
            }
        }
    }
}
