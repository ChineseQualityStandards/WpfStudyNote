using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfStudyNote.Core.ModelBases;

namespace WpfStudyNote.Views.Controller.ViewModels
{
    public class PromptViewModel : RegionViewModelBase, IDialogAware
    {
        #region 字段

        #endregion

        #region 属性

        private DialogCloseListener _requestClose;
        /// <summary>
        /// 请求关闭
        /// </summary>
        public DialogCloseListener RequestClose
        {
            get
            {
                return _requestClose;
            }
        }

        #endregion

        #region 命令

        public DelegateCommand<string> DelegateCommand { get; }

        #endregion

        #region 构造函数

        public PromptViewModel(IRegionManager regionManager) : base(regionManager)
        {
            DelegateCommand = new DelegateCommand<string>(DelegateMethod);
        }


        #endregion

        #region 方法

        private void DelegateMethod(string switch_on)
        {
            switch (switch_on)
            {
                case "OK":
                    ReturnMethod("确认退出",ButtonResult.OK);
                    break;
                case "Cancel":
                    ReturnMethod("取消退出", ButtonResult.Cancel);
                    break;
                default:
                    break;
            }
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            //throw new NotImplementedException();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            SetMessage(parameters.GetValue<string>("Message"));
            //throw new NotImplementedException();
        }


        public void ReturnMethod(string result, ButtonResult buttonResult)
        {
            DialogParameters parameters = new DialogParameters();
            parameters.Add("Message", result);
            var dialogResult = new DialogResult
            {
                Result = buttonResult,
                Parameters = parameters
            };
            RequestClose.Invoke(dialogResult);
        }

        #endregion

    }
}
