using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using WpfStudyNote.Core.ModelBases;

namespace WpfStudyNote.Views.Controller.ViewModels
{
    public class TestViewModel : RegionViewModelBase
    {
        #region 字段

        private readonly IRegionManager _regionManager;

        #endregion

        #region 构造函数

        public TestViewModel(IRegionManager regionManager) : base(regionManager)
        {
            _regionManager = regionManager;

            SetMessage("This's TestView!");
        }
        #endregion
    }
}
