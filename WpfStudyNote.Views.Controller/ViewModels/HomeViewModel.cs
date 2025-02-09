using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfStudyNote.Core.ModelBases;

namespace WpfStudyNote.Views.Controller.ViewModels
{
    public class HomeViewModel : RegionViewModelBase
    {
        #region 字段

        private readonly IRegionManager regionManager;

        #endregion

        #region 构造函数

        public HomeViewModel(IRegionManager regionManager) : base(regionManager)
        {
            this.regionManager = regionManager;

            SetMessage("This is HomeView!");
        }

        #endregion
    }
}
