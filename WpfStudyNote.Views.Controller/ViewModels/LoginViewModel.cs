using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Prism.Dialogs;
using System.Windows.Controls;
using Newtonsoft.Json;
using WpfStudyNote.Core.ModelBases;
using WpfStudyNote.Core.Models;
using WpfStudyNote.Interfaces;

namespace WpfStudyNote.Views.Controller.ViewModels
{
    public class LoginViewModel : RegionViewModelBase, IDialogAware
    {

        public string Title => "用户登录";

        public DelegateCommand<PasswordBox> LoginCommand { get; }

        private string userName;
        /// <summary>
        /// 用户
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { SetProperty(ref userName, value); }
        }


        public LoginViewModel(IRegionManager regionManager, ILoginService restSharpService) : base(regionManager)
        {
            
            LoginCommand = new DelegateCommand<PasswordBox>(OnLogin);
            _restSharpService = restSharpService;
        }

        private async void OnLogin(PasswordBox box)
        {
            var result = await _restSharpService.LoginAsync(UserName, box.Password);
            if (result.Code == StatusCode.OK)
            {
                Message = "登录成功";
                IDialogParameters parameters = new DialogParameters();
                Accounts accounts = JsonConvert.DeserializeObject<Accounts>(result.Object.ToString());
                parameters.Add("Accounts", accounts);
                _requestClose.Invoke(parameters,ButtonResult.OK);
            }
            else
            {
                Message = result.Message;
            }
            //
        }

        private DialogCloseListener _requestClose;
        private readonly ILoginService _restSharpService;

        public DialogCloseListener RequestClose
        {
            get
            {
                return _requestClose;
            }
        }

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }
    }
}
