using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WpfStudyNote.Core.Constants;
using WpfStudyNote.Core.ModelBases;

namespace WpfStudyNote.Views.Controller.ViewModels
{
    public class TitleViewModel : RegionViewModelBase
    {
        #region 字段

        private readonly IRegionManager _regionManager;

        #endregion

        #region 属性

        public DelegateCommand<string> DelegateCommand { set; get; }
        
        #endregion
        
        #region 命令 
        
        #endregion

        #region 构造函数

        public TitleViewModel(IRegionManager regionManager) : base(regionManager)
        {
            _regionManager = regionManager;

            DelegateCommand = new DelegateCommand<string>(DelegateMethod);
        }



        #endregion

        #region 方法


        private void DelegateMethod(string switch_on)
        {
            switch (switch_on)
            {
                case "Minimize":
                    Application.Current.MainWindow.WindowState = WindowState.Minimized;
                    break;
                case "FullScreenOrReturn":
                    Application.Current.MainWindow.WindowState = Application.Current.MainWindow.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
                    break;
                case "Exit":
                    Exit();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 退出程序
        /// </summary>
        private void Exit()
        {
            if (MessageBox.Show("确认退出应用？", "请选择", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
            {
                return;
            }
        }

        #endregion

    }
}
