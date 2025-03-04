using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media.Imaging;
using WpfStudyNote.Core.Constants;
using WpfStudyNote.Core.ModelBases;
using WpfStudyNote.Core.Models;
using WpfStudyNote.Services;

namespace WpfStudyNote.Views.Controller.ViewModels
{
    public class DrawerViewModel : RegionViewModelBase
    {
        #region 字段

        private readonly IRegionManager _regionManager;

        #endregion

        #region 属性

        private Accounts account;

        public Accounts Account
        {
            get { return AppSession.User; }
            set { SetProperty(ref account, value); }
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

        #endregion

        #region 命令

        public DelegateCommand<string> DelegateCommand { set; get; }

        #endregion

        #region 构造函数

        public DrawerViewModel(IRegionManager regionManager) : base(regionManager)
        {
            _regionManager = regionManager;

            DelegateCommand = new DelegateCommand<string>(DelegateMethod);

            ReLoadAppSession();

            SetMessage("This is Drawer!");
        }

        private void DelegateMethod(string switch_on)
        {
            switch (switch_on)
            {
                case "CreateArticle":
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, ViewNames.CreateArticleView);
                    break;
                case "GoArticle":
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, ViewNames.ShowArticleView);
                    break;
                case "GoHome":
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, ViewNames.HomeView);
                    break;
                case "GoSetting":
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, ViewNames.SettingView);
                    break;
                case "GoTest":
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, ViewNames.TestView);
                    break;
                default:
                    break;
            }
        }


        private void ReLoadAppSession()
        {
            if (!string.IsNullOrEmpty(Account.HeadPicture))
                ImageSource = ImageHelper.Base64ToBitmapImage(Account.HeadPicture);
        }

        #endregion
    }
}
