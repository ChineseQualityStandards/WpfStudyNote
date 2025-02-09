using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using WpfStudyNote.Core.ModelBases;

namespace WpfStudyNote.Views.Controller.ViewModels
{
    public class MainViewModel : RegionViewModelBase
    {
        #region 字段

        private readonly IRegionManager _regionManager;

        #endregion

        #region 属性

        #endregion

        #region 构造函数

        public MainViewModel(IRegionManager regionManager) : base(regionManager)
        {
            _regionManager = regionManager;
        }

        #endregion

        #region 方法

        #endregion
    }
}
