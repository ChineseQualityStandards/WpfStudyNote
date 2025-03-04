using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows;
using MaterialDesignThemes.Wpf;
using Prism.Ioc;
using Prism.Modularity;
using WpfStudyNote.Core.Models;
using WpfStudyNote.Interfaces;
using WpfStudyNote.Services;
using WpfStudyNote.Views;
using WpfStudyNote.Views.Controller;
using WpfStudyNote.Views.Controller.Views;

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
            IDialogService dialogService = Container.Resolve<IDialogService>();
            dialogService.ShowDialog("LoginView", callback =>
            {
                if (callback.Result == ButtonResult.OK)
                {
                    AppSession.UserSessionMethod(callback.Parameters.GetValue<Accounts>("Accounts"));
                    //MessageBox.Show(callback.Parameters.GetValue<string>("Message"));
                    return;
                }
                else
                {
                    Current.Shutdown();
                }
            });
            base.OnInitialized();
        }

        /// <summary>
        /// 依赖/服务注册
        /// </summary>
        /// <param name="containerRegistry">注册容器</param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IFontsService, FontsService>();
            containerRegistry.RegisterSingleton<IAccountService<ApiReponse<Accounts>, Accounts>, AccountsService>();
            containerRegistry.RegisterSingleton<IWebApiService<ApiReponse<Articles>, Articles>, ArticleService>();
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
