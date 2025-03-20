using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DryIoc.ImTools;
using Prism.Commands;
using Prism.Mvvm;
using WpfStudyNote.Core.Constants;
using WpfStudyNote.Core.ModelBases;
using WpfStudyNote.Core.Models;
using WpfStudyNote.Interfaces;

namespace WpfStudyNote.Views.Controller.ViewModels
{
    public class SearchViewModel : RegionViewModelBase
    {
        #region 字段

        private readonly IWebApiService<ApiReponse<Articles>, Articles> _articleService;
        private readonly IRegionManager _regionManager;

        #endregion

        #region 属性

        private int count;

        public int Count
        {
            get { return count; }
            set { SetProperty(ref count, value); }
        }

        private int page;

        public int Page
        {
            get { return page; }
            set { SetProperty(ref page, value); }
        }

        private int pages;

        public int Pages
        {
            get { return pages; }
            set { SetProperty(ref pages, value); }
        }

        private ObservableCollection<Articles> articlesList;

        public ObservableCollection<Articles> ArticlesList
        {
            get { return articlesList; }
            set { SetProperty(ref articlesList, value); }
        }

        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set { SetProperty(ref searchText, value); }
        }


        #endregion

        #region 命令

        public DelegateCommand<object> DelegateCommand { get; }

        #endregion

        #region 构造函数

        public SearchViewModel(IWebApiService<ApiReponse<Articles>, Articles> articleService,IRegionManager regionManager) : base(regionManager)
        {
            _articleService = articleService;
            _regionManager = regionManager;
            DelegateCommand = new DelegateCommand<object>(DelegateMethod);
            
            SetMessage("我是有底线的");

            GetAllArticles();

        }



        #endregion

        #region 方法

        private void DelegateMethod(object switch_on)
        {
            switch (switch_on.ToString())
            {
                case "Search":
                    if (string.IsNullOrEmpty(SearchText))
                        GetAllArticles();
                    break;
                default:
                    var article = ArticlesList.Where(o => o.ArticleId == (int)switch_on).FirstOrDefault();
                    AppSession.BlogSessionMethod(article);
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, ViewNames.ShowArticleView);
                    //SetMessage(switch_on.ToString());
                    break;
            }
        }


        public async void GetAllArticles()
        {
            try
            {
                ArticlesList = await _articleService.GetAllAsync();
                AppSession.ArticlesSessionMethod(ArticlesList);
                Count = ArticlesList.Count;
                Page = 1;
                Pages = (int)Math.Ceiling((double)Count / 10);
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }

        }



        #endregion
    }      
    
}
