using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
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

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<ControllerModule>();
        }
    }

}
