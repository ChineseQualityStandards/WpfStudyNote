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
using WpfStudyNote.Interfaces;
using WpfStudyNote.Core.Models;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Media.Imaging;
using WpfStudyNote.Services;
using System.Security.Policy;
using System.Xml.Linq;
using WpfStudyNote.Core.Constants;

namespace WpfStudyNote.Views.Controller.ViewModels
{
    public class CreateArticleViewModel : RegionViewModelBase
    {


        #region 字段

        private readonly IDialogService _dialogService;
        private readonly IWebApiService<ApiReponse<Articles>, Articles> _articleService;
        private readonly IWebApiService<ApiReponse<Categories>, Categories> _categoriesService;
        private readonly IWebApiService<ApiReponse<Tags>, Tags> _tagsService;
        private readonly IRegionManager _regionManager;
        private readonly IFontsService _fontsService;
        private readonly IRichTextBoxService _richTextBoxService;

        #endregion

        #region 属性

        private Articles? article;
        /// <summary>
        /// 文章
        /// </summary>
        public Articles? Article
        {
            get { return article; }
            set { SetProperty(ref article, value); }
        }

        private BitmapImage _imageSource;
        /// <summary>
        /// 位图源码
        /// </summary>
        public BitmapImage ImageSource
        {
            get { return _imageSource; }
            set { SetProperty(ref _imageSource, value); }
        }

        private string? coverPictureLink;
        /// <summary>
        /// 封面图片链接
        /// </summary>
        public string? CoverPictureLink
        {
            get { return coverPictureLink; }
            set { SetProperty(ref coverPictureLink, value); }
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

        private ObservableCollection<Categories>? categories;

        public ObservableCollection<Categories>? Categories
        {
            get { return categories; }
            set { SetProperty(ref categories, value); }
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

        private ObservableCollection<Tags> tags;

        public ObservableCollection<Tags> Tags
        {
            get { return tags; }
            set { SetProperty(ref tags, value); }
        }

        private ObservableCollection<Tags> tagsList;

        public ObservableCollection<Tags> TagsList
        {
            get { return tagsList; }
            set { SetProperty(ref tagsList, value); }
        }

        #endregion

        #region 命令

        public DelegateCommand<string> DelegateCommand { get; set; }
        /// <summary>
        /// 如果绑定不了数据就把整个控件丢进来 (╯°皿°）╯︵ ┻━┻
        /// </summary>
        //public DelegateCommand<RichTextBox> DelegateCommand { get; set; }



        #endregion

        #region 构造函数

        public CreateArticleViewModel(IDialogService dialogService, IWebApiService<ApiReponse<Articles>, Articles> articleService, IWebApiService<ApiReponse<Categories>, Categories> categoriesService, IWebApiService<ApiReponse<Tags>, Tags> tagsService, IRegionManager regionManager, IFontsService fontsService, IRichTextBoxService richTextBoxService) : base(regionManager)
        {
            _dialogService = dialogService;
            _articleService = articleService;
            _categoriesService = categoriesService;
            _tagsService = tagsService;
            _regionManager = regionManager;
            _fontsService = fontsService;
            _richTextBoxService = richTextBoxService;

            Article = new Articles();

            Categories = new ObservableCollection<Categories>();

            Data = new FlowDocument();

            TagsList = new ObservableCollection<Tags>();

            Load();

            DelegateCommand = new DelegateCommand<string>(DelegateMethod);

            RichTextBoxFonts = _fontsService.GetFontsProperties();

            

            //SetMessage("This is CreateArticleView!");
        }

        



        #endregion

        #region 方法

        private async void DelegateMethod(string switch_on)
        {
            try
            {
                ApiReponse<Articles> response;
                switch (switch_on)
                {
                    case "LoadCoverPicture":
                        BitmapImage bitmap = new BitmapImage();
                        bitmap.BeginInit();
                        bitmap.UriSource = new Uri(CoverPictureLink, UriKind.RelativeOrAbsolute);
                        bitmap.EndInit();
                        ImageSource = bitmap;

                        // 更新 Article 的 CoverPicture 属性
                        if (Article != null)
                        {
                            Article.CoverPicture = ImageHelper.BitmapImageToBase64(bitmap);
                        }
                        SetMessage("图片已加载");
                        break;
                    case "Return":
                        var keyValues = new DialogParameters();
                        keyValues.Add("Message", "您还没有上传文章,确定返回上层？");
                        _dialogService.ShowDialog("PromptView", keyValues,
                            callback =>
                            {
                                // 获取对话框返回的结果
                                if(callback.Result == ButtonResult.OK)
                                {
                                    Clear();
                                    SetMessage(string.Empty);
                                }
                                else if(callback.Result == ButtonResult.Cancel)
                                {
                                    var result = callback.Parameters;
                                    SetMessage(result.GetValue<string>("Message"));
                                }
                            });
                        break;
                    case "Submit":
                        GetArticleProperty();
                        if (Article != null)
                        {
                            //Article.CategoryId = Article.CategoryId + 1;
                            response = await _articleService.CreateAsync(Article);
                            SetMessage(response.Message);
                            if(response.Code == StatusCode.Created)
                            {
                                Clear();
                                _regionManager.RequestNavigate(RegionNames.ContentRegion, ViewNames.HomeView);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }


        private void GetArticleProperty()
        {
            try
            {
                if (string.IsNullOrEmpty(Article.Title))
                    throw new ArgumentNullException("标题栏不能为空");
                if (Data is null)
                    throw new ArgumentNullException("文章内容不能为空");
                else
                    Article.Content = _richTextBoxService.GetStringInUTF8(Data);
                Article.AuthorId = AppSession.User.AccountId;
                if(string.IsNullOrEmpty(Article.CoverPicture))
                    throw new ArgumentNullException("封面图片不能为空");
                if (string.IsNullOrEmpty(Article.Introduction))
                    throw new ArgumentNullException("简介不能为空");
                Article.CreatedAt = DateTime.Now;
                Article.UpdatedAt = DateTime.Now;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            Load();
        }

        public async void Load()
        {
            try
            {
                Categories = await _categoriesService.GetAllAsync();
                TagsList = await _tagsService.GetAllAsync();
                
            }
            catch (Exception ex)
            {
                SetMessage(ex.Message);
            }
        }

        public void Clear()
        {
            Article = new Articles();
            AppSession.BlogSessionMethod(Article);
            ImageSource = new BitmapImage();
            CoverPictureLink = string.Empty;
            Data = new FlowDocument();
            TagsList.Clear();
        }

        #endregion
    }
}