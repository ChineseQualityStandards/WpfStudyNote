using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfStudyNote.Core.ModelBases;
using WpfStudyNote.Core.Models;
using WpfStudyNote.Interfaces;

namespace WpfStudyNote.Views.Controller.ViewModels
{
    public class RegisterViewModel : RegionViewModelBase, IDialogAware
    {
        #region 字段

        private readonly IAccountService<ApiReponse<Accounts>, Accounts> _registerService;
        private readonly IRegionManager _regionManager;

        #endregion

        #region 属性

        private Accounts? account;

        public Accounts? Account
        {
            get { return account; }
            set { SetProperty(ref account, value); }
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

        public DelegateCommand<PasswordBox> RegisterCommand { get; }

        #endregion

        #region 构造函数

        public RegisterViewModel(IAccountService<ApiReponse<Accounts>, Accounts> registerService, IRegionManager regionManager) : base(regionManager)
        {
            _registerService = registerService;
            _regionManager = regionManager;

            Account = new Accounts()
            {
                AccountId = -1,
                AccountName = "测试用户",
                Email = "测试邮箱",
                Introduction = "这是测试账户的说明",
            };

            RegisterCommand = new DelegateCommand<PasswordBox>(RegisterMethod);


        }

        



        #endregion

        #region 方法

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {
            
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            
        }

        private async void RegisterMethod(PasswordBox box)
        {
            try
            {
                if(account.AccountId != 0) account.AccountId = 0;
                Account.PasswordHash = box.Password;
                ApiReponse<Accounts> reponse = await _registerService.CreateAsync(Account);
                if (reponse.Code == StatusCode.Created)
                {
                    DialogParameters parameters = new DialogParameters();
                    parameters.Add("Message", "注册成功");
                    var dialogResult = new DialogResult
                    {
                        Result = ButtonResult.OK,
                        Parameters = parameters
                    };
                    _requestClose.Invoke(dialogResult);
                }
                else
                {
                    throw new Exception(reponse.Message);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        #endregion



    }
}
