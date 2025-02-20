using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;

namespace WpfStudyNote.Views.Controller.ControllerHelper
{
    /// <summary>
    /// RichTextBox MVVM绑定属性[可用]
    /// </summary>
    public class RichTextBoxHelperExactly : DependencyObject
    {
        public static FlowDocument GetFlowDocument(DependencyObject obj)
        {
            return (FlowDocument)obj.GetValue(FlowDocumentProperty);
        }

        public static void SetFlowDocument(DependencyObject obj, FlowDocument value)
        {
            obj.SetValue(FlowDocumentProperty, value);
        }

        // 使用文档流监视并给RichTextBox更新值
        public static readonly DependencyProperty FlowDocumentProperty =
            DependencyProperty.RegisterAttached("FlowDocument", typeof(FlowDocument), typeof(RichTextBoxHelperExactly), new PropertyMetadata(FlowDocumentPropertyChanged));

        private static void FlowDocumentPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            RichTextBox box = d as RichTextBox;
            if (box != null)
            {
                box.Document = (FlowDocument)e.NewValue;
            }
        }
    }

    /// <summary>
    /// RichTextBox MVVM绑定属性【本类暂时获取不到数据，需要后续改进】
    /// </summary>
    public class RichTextBoxHelper : DependencyObject
    {
        #region 属性
        /// <summary>
        /// 静态的线程集合字段，用以标记线程的操作(卡住)，起到后文函数防止递归调用导致的无限循环问题，即递归保护
        /// </summary>
        private static HashSet<Thread> _recursionProtection = new HashSet<Thread>();

        /// <summary>
        /// 依赖属性
        /// </summary>
        public static readonly DependencyProperty DocumentXamlProperty =
            DependencyProperty.RegisterAttached("DocumentXaml", typeof(string), typeof(RichTextBoxHelper), new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnDocumentXamlChanged)));

        private static void OnDocumentXamlChanged(DependencyObject box, DependencyPropertyChangedEventArgs e)
        {
            
            // 如果线程集合里有线程对象，则跳出当前操作
            if (_recursionProtection.Contains(Thread.CurrentThread))
                return;

            var richTextBox = box as RichTextBox;
            try
            {
                var stream = new MemoryStream(Encoding.UTF8.GetBytes(GetDocumentXaml(richTextBox)));

                var doc = (FlowDocument)XamlReader.Load(stream);

                richTextBox.Document = doc;
            }
            catch (Exception)
            {

                richTextBox.Document = new FlowDocument();
            }
            richTextBox.TextChanged += (temp, e) =>
            {
                RichTextBox tempBox = (RichTextBox)temp;
                if (tempBox != null)
                {
                    SetDocumentXaml(richTextBox, XamlWriter.Save(tempBox.Document));
                }
            };
            
        }

        #endregion


        #region 方法

        /// <summary>
        /// 获取目标的xaml文档
        /// </summary>
        /// <param name="object">目标控件</param>
        /// <returns>字符串数据</returns>
        public static string GetDocumentXaml(DependencyObject @object) => (string)@object.GetValue(DocumentXamlProperty);

        /// <summary>
        /// 设置文档
        /// </summary>
        /// <param name="object">目标属性</param>
        /// <param name="value">传入的字符串</param>
        public static void SetDocumentXaml(DependencyObject @object, string value)
        {
            // 递归保护
            _recursionProtection.Add(Thread.CurrentThread);
            @object.SetValue(DocumentXamlProperty, value);
            _recursionProtection.Remove(Thread.CurrentThread);
        }

        #endregion
    }


    
}
