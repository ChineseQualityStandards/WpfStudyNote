using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;
using WpfStudyNote.Core.ModelBases;
using WpfStudyNote.Core.Models;
using WpfStudyNote.Interfaces;

namespace WpfStudyNote.Views.Controller.ViewModels
{
	public class ShowArticleViewModel : RegionViewModelBase
	{

        #region 字段

        private readonly IRegionManager _regionManager;
        private readonly IRichTextBoxService _richTextBoxService;

        #endregion

        #region 属性

        private Articles article;
        
        public Articles Article
        {
            get { return article; }
            set { SetProperty(ref article, value); }
        }


        private FlowDocument? data;
        /// <summary>
        /// 用于存储NoteBox的数据
        /// </summary>
        public FlowDocument? Data
        {
            get { return data; }
            set { SetProperty(ref data, value); }
        }

        private FontsProperties? richTextBoxFonts;
        /// <summary>
        /// 存储字体属性
        /// </summary>
        public FontsProperties? RichTextBoxFonts
        {
            get { return richTextBoxFonts; }
            set { SetProperty(ref richTextBoxFonts, value); }
        }


        #endregion

        #region 命令

        public DelegateCommand<string> DelegateCommand { get; set; }

        #endregion

        #region 构造函数

        public ShowArticleViewModel(IRegionManager regionManager,  IRichTextBoxService richTextBoxService) : base(regionManager)
        {
            _regionManager = regionManager;
            
            _richTextBoxService = richTextBoxService;

            Data = new FlowDocument();

            DelegateCommand = new DelegateCommand<string>(DelegateMethod);
           

            SetMessage("This is CreateArticleView!");
        }





        #endregion

        #region 方法

        private void DelegateMethod(string value)
        {
            try
            {
                if (Data != null)
                    System.Diagnostics.Debug.WriteLine(_richTextBoxService.GetStringInUTF8(Data));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }


        public void LoadArticle()
        {
            if(AppSession.Article != null)
            {
                Article = AppSession.Article;
                _richTextBoxService.LoadStringInUTF8(Article.Content, Data);
            }
        }
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            LoadArticle();
        }

        #endregion
    }
}
