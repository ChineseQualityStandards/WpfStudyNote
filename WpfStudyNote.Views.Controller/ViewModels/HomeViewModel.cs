using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfStudyNote.Core.ModelBases;
using WpfStudyNote.Core.Models;

namespace WpfStudyNote.Views.Controller.ViewModels
{
    public class HomeViewModel : RegionViewModelBase
    {
        #region 字段

        private readonly IRegionManager regionManager;

        #endregion

        #region 属性

        /// <summary>
        /// 存储和管理轮播图片的轮播图片集
        /// </summary>
        public ObservableCollection<Carousels> Carousels { get; set; }

        #endregion

        #region 构造函数

        public HomeViewModel(IRegionManager regionManager) : base(regionManager)
        {
            this.regionManager = regionManager;

            Carousels = new ObservableCollection<Carousels>()
            {
                new Carousels()
                {
                    Context = "正在直播LPL AL - WE",
                    Interval = "0:0:0.625",
                    IsPlaying = "True",
                    Link = "null",
                    Source = "C:\\Users\\ZFREE\\Pictures\\素材\\程序\\QQ20250210-184839.png",
                    ToolTip = "正在直播LPL AL - WE",
                },
                new Carousels()
                {
                    Context = "iPhone SE 4 to launch this week? India price, specs, key features and all we know so far",
                    Interval = "0:0:0.625",
                    IsPlaying = "True",
                    Link = "null",
                    Source ="C:\\Users\\ZFREE\\Pictures\\素材\\程序\\futuristic-7789214_1920.jpg",
                    ToolTip = "iPhone SE 4 to launch this week? India price, specs, key features and all we know so far",
                },
                new Carousels()
                {
                    Context = "侧边栏",
                    Interval = "0:0:0.125",
                    IsPlaying = "True",
                    Link = "null",
                    Source ="C:\\Users\\ZFREE\\Pictures\\素材\\程序\\侧边栏.jpg",
                    ToolTip = "侧边栏",
                },
            };

            SetMessage("This is HomeView!");
        }

        #endregion
    }
}
