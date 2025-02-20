using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfStudyNote.Views.Controller.Views
{
    /// <summary>
    /// CreateNoteView.xaml 的交互逻辑
    /// </summary>
    public partial class CreateNoteView : UserControl
    {
        public CreateNoteView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string rtf1;
            TextRange textRange = new TextRange(FristBox.Document.ContentStart, FristBox.Document.ContentEnd);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                textRange.Save(memoryStream, DataFormats.Rtf);
                rtf1 = Encoding.UTF8.GetString(memoryStream.ToArray());
            }

            TextRange secondTextRange = new TextRange(SecondBox.Document.ContentStart, SecondBox.Document.ContentEnd);
            using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(rtf1)))
            {
                secondTextRange.Load(memoryStream, DataFormats.Rtf);
            }

            // 将 secondTextRange 的内容转换为字符串并输出到调试控制台
            using (MemoryStream memoryStream = new MemoryStream())
            {
                secondTextRange.Save(memoryStream, DataFormats.Rtf);
                string secondRtf = Encoding.UTF8.GetString(memoryStream.ToArray());
                System.Diagnostics.Debug.WriteLine(secondRtf);
            }
        }
    }
}
