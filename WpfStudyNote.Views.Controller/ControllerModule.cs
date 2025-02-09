using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStudyNote.Views.Controller
{
    /// <summary>
    /// 控制器模块，用于初始化区域管理器、注册类型到依赖注入容器、以及在模块初始化时执行的逻辑和注册导航视图等操作
    /// </summary>
    public class ControllerModule : IModule
    {
        #region 属性

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
            
        }

        /// <summary>
        /// 注册类型到依赖注入容器
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        #endregion
    }
}
