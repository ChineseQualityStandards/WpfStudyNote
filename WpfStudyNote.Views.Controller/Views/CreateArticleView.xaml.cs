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
    /// CreateArticleView.xaml 的交互逻辑
    /// </summary>
    public partial class CreateArticleView : UserControl
    {
        public CreateArticleView()
        {
            InitializeComponent();
        }

        private void FontSizeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(NoteBox.Selection.Text))
            {
                return;
            }
            else
            {
                if (double.TryParse(FontSizeComboBox.SelectedValue.ToString(), out double fontSize))
                {
                    NoteBox.Selection.ApplyPropertyValue(FontSizeProperty, fontSize); // 应用新的字体大小到选中内容上
                }
                else
                {
                    return;
                }
            }
        }
    }
}
