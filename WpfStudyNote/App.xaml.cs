using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using WpfStudyNote.Interfaces;
using WpfStudyNote.Services;
using WpfStudyNote.Views;
using WpfStudyNote.Views.Controller;

namespace WpfStudyNote
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }

        /// <summary>
        /// 依赖/服务注册
        /// </summary>
        /// <param name="containerRegistry">注册容器</param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IFontsService, FontsService>();
            containerRegistry.RegisterSingleton<IRichTextBoxService,RichTextBoxService>();
        }

        /// <summary>
        /// 模块化配置列表
        /// </summary>
        /// <param name="moduleCatalog">管理和提供模块的集合</param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ControllerModule>();
        }
    }

}
