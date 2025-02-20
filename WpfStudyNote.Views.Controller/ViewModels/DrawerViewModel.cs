using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using WpfStudyNote.Core.Constants;
using WpfStudyNote.Core.ModelBases;

namespace WpfStudyNote.Views.Controller.ViewModels
{
    public class DrawerViewModel : RegionViewModelBase
    {
        #region 字段

        private readonly IRegionManager _regionManager;

        #endregion

        #region 属性

        public DelegateCommand<string> DelegateCommand { set; get; }

        #endregion

        #region 构造函数

        public DrawerViewModel(IRegionManager regionManager) : base(regionManager)
        {
            _regionManager = regionManager;

            DelegateCommand = new DelegateCommand<string>(DelegateMethod);
            SetMessage("This is Drawer!");
        }

        private void DelegateMethod(string switch_on)
        {
            switch (switch_on)
            {
                case "CreateNote":
                    _regionManager.RequestNavigate(RegionNames.ContentRegion, ViewNames.CreateNoteView);
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

        #endregion
    }
}
