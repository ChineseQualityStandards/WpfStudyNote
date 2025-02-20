using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfStudyNote.Core.Constants;
using WpfStudyNote.Views.Controller.ViewModels;
using WpfStudyNote.Views.Controller.Views;

namespace WpfStudyNote.Views.Controller
{
    /// <summary>
    /// 控制器模块，用于初始化区域管理器、注册类型到依赖注入容器、以及在模块初始化时执行的逻辑和注册导航视图等操作
    /// </summary>
    public class ControllerModule : IModule
    {
        #region 字段

        /// <summary>
        /// 区域管理器
        /// </summary>
        private readonly IRegionManager _regionManager;

        #endregion

        #region 构造函数

        /// <summary>
        /// 用于初始化区域管理器的构造函数
        /// </summary>
        /// <param name="regionManager">区域管理器</param>
        public ControllerModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 在模块初始化时执行的逻辑
        /// </summary>
        /// <param name="containerProvider"></param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, ViewNames.HomeView);
            _regionManager.RegisterViewWithRegion(RegionNames.DrawerRegion, ViewNames.DrawerView);
            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion, ViewNames.MainView);
            _regionManager.RegisterViewWithRegion(RegionNames.TitleRegion, ViewNames.TitleView);
        }

        /// <summary>
        /// 注册类型到依赖注入容器
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<CreateNoteView, CreateNoteViewModel>();
            containerRegistry.RegisterForNavigation<DrawerView, DrawerViewModel>();
            containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
            containerRegistry.RegisterForNavigation<TitleView, TitleViewModel>();
            containerRegistry.RegisterForNavigation<HomeView, HomeViewModel>();
            containerRegistry.RegisterForNavigation<SettingView, SettingViewModel>();
            containerRegistry.RegisterForNavigation<SearchView, SearchViewModel>();
            containerRegistry.RegisterForNavigation<TestView, TestViewModel>();
        }

        #endregion
    }
}
