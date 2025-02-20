using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Documents;
using WpfStudyNote.Core.ModelBases;

namespace WpfStudyNote.Views.Controller.ViewModels
{
    public class CreateNoteViewModel : RegionViewModelBase
    {
        

        #region 字段

        private readonly IRegionManager _regionManager;

        #endregion

        #region 属性

        private FlowDocument? doc;

        public FlowDocument? Doc
        {
            get { return doc; }
            set { SetProperty(ref doc, value); }
        }

        private FlowDocument? doc2;

        public FlowDocument? Doc2
        {
            get { return doc2; }
            set { SetProperty(ref doc2, value); }
        }

        #endregion

        #region 命令

        public DelegateCommand<string> DelegateCommand { get; set; }
        /// <summary>
        /// 如果绑定不了数据就把整个控件丢进来 (╯°皿°）╯︵ ┻━┻
        /// </summary>
        public DelegateCommand<RichTextBox> DelegateCommandRtx { get; set; }

        #endregion

        #region 构造函数

        public CreateNoteViewModel(IRegionManager regionManager) : base(regionManager)
        {
            _regionManager = regionManager;

            Doc = new FlowDocument();
            Doc2 = new FlowDocument();

            DelegateCommand = new DelegateCommand<string>(DelegateMethod);
            DelegateCommandRtx = new DelegateCommand<RichTextBox>(DelegateMethod);

            SetMessage("This is CreateNoteView!");
        }

        



        #endregion

        #region 方法

        private void DelegateMethod(string command)
        {
            try
            {
                switch (command)
                {
                    case "Show":
                        //string rtf1;
                        //TextRange textRange = new TextRange(Doc.ContentStart, Doc.ContentEnd);
                        //using (MemoryStream memoryStream = new MemoryStream())
                        //{
                        //    textRange.Save(memoryStream, DataFormats.Rtf);
                        //    rtf1 = Encoding.UTF8.GetString(memoryStream.ToArray());
                        //}
                        //System.Diagnostics.Debug.WriteLine($"{rtf1}");
                        break;
                    case "Copy":
                        string rtf1;
                        TextRange textRange = new TextRange(Doc.ContentStart, Doc.ContentEnd);
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            textRange.Save(memoryStream, DataFormats.Rtf);
                            rtf1 = Encoding.UTF8.GetString(memoryStream.ToArray());
                        }
                        TextRange secondTextRange = new TextRange(Doc2.ContentStart, Doc2.ContentEnd);
                        using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(rtf1)))
                        {
                            secondTextRange.Load(memoryStream, DataFormats.Rtf);
                        }
                        break;
                    default:
                        System.Diagnostics.Debug.WriteLine("按下了按钮。");
                        break;
                }
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void DelegateMethod(RichTextBox box)
        {
            try
            {
                string rtf1;
                TextRange textRange = new TextRange(box.Document.ContentStart, box.Document.ContentEnd);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    textRange.Save(memoryStream, DataFormats.Rtf);
                    rtf1 = Encoding.UTF8.GetString(memoryStream.ToArray());
                }

                TextRange secondTextRange = new TextRange(Doc2.ContentStart, Doc2.ContentEnd);
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
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
