using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfStudyNote.Core.ModelBases;

namespace WpfStudyNote.ViewModels
{
    public class MainWindowViewModel : RegionViewModelBase
    {
        private readonly IRegionManager _regionManager;

        private string title = "标题";

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }


        public MainWindowViewModel(IRegionManager regionManager) : base(regionManager)
        {
            _regionManager = regionManager;

            SetMessage("普通消息。");
        }
    }
}
