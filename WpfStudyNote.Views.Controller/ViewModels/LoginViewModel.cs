using System.Windows.Controls;
using WpfStudyNote.Core.ModelBases;
using WpfStudyNote.Core.Models;
using WpfStudyNote.Interfaces;
using System.Net.Mail;
using RestSharp;
using Newtonsoft.Json;

namespace WpfStudyNote.Views.Controller.ViewModels
{
    public class LoginViewModel : RegionViewModelBase, IDialogAware
    {
        #region 字段

        private readonly IDialogService _dialogService;
        private readonly IRegionManager _regionManager;
        private readonly IAccountService<ApiReponse<Accounts>,Accounts> _loginService;

        public string Title => "用户登录";

        #endregion

        #region 属性

        private string? inputField;

        public string? InputField
        {
            get { return inputField; }
            set { SetProperty(ref inputField, value); }
        }


        private Accounts? user;
        /// <summary>
        /// 用户
        /// </summary>
        public Accounts? User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }

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

        public DelegateCommand<PasswordBox> LoginCommand { get; }

        public DelegateCommand<string> DelegateCommand { get; }

        #endregion

        #region 构造函数

        public LoginViewModel(IDialogService dialogService,IRegionManager regionManager, IAccountService<ApiReponse<Accounts>,Accounts> loginService) : base(regionManager)
        {
            _dialogService = dialogService;
            _regionManager = regionManager;
            _loginService = loginService;
            
            LoginCommand = new DelegateCommand<PasswordBox>(OnLogin);

            DelegateCommand = new DelegateCommand<string>(DelegateMethod);

            User = new Accounts();
            Message = "请输入用户名和密码";
        }

        #endregion

        #region 方法

        private void DelegateMethod(string switch_on)
        {
            switch (switch_on)
            {
                case "注册":
                    ShowDialog("RegisterView");
                    break;
                default:
                    break;
            }
        }



        public bool CanCloseDialog() => true;

        /// <summary>
        /// 判断是否是邮箱
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool IsEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private async void OnLogin(PasswordBox box)
        {
            User.AccountName = InputField;
            User.PasswordHash = box.Password;
            ApiReponse<Accounts> result = await _loginService.LoginAsync(User);

            if (result.Code == StatusCode.Accepted)
            {
                Message = "登录成功";
                DialogParameters parameters = new DialogParameters();
                parameters.Add("Accounts", result.Object);
                parameters.Add("Message", result.Message);
                var dialogResult = new DialogResult
                {
                    Result = ButtonResult.OK,
                    Parameters = parameters
                };
                RequestClose.Invoke(dialogResult);
                //RequestClose.Invoke(new DialogResult(ButtonResult.OK));
            }
            else
            {
                Message = result.Message;
            }
            //Message = result.Message;
        }
        

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

        /// <summary>
        /// 显示对话框
        /// </summary>
        /// <param name="name">窗口名称</param>
        public void ShowDialog(string name)
        {
            var keyValues = new DialogParameters();
            _dialogService.ShowDialog(name, keyValues,
                callback => 
                {
                    // 获取对话框返回的结果
                    var result = callback.Parameters;
                    SetMessage(result.GetValue<string>("Message"));
                });
        }

        #endregion
    }
}
