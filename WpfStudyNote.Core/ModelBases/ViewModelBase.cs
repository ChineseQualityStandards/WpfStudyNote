using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfStudyNote.Core.Models;

namespace WpfStudyNote.Core.ModelBases
{
    /// <summary>
    /// ViewModel基类
    /// </summary>
    public class ViewModelBase : Messages, IDestructible
    {
        #region 方法

        /// <summary>
        /// 构造函数
        /// </summary>
        public ViewModelBase() { }

        /// <summary>
        /// 销毁
        /// </summary>
        public void Destroy() { }

        /// <summary>
        /// 设置错误消息
        /// </summary>
        /// <param name="errorMessage">错误消息</param>
        public void SetErrorMessage(string errorMessage) => ErrorMessage = errorMessage;
        /// <summary>
        /// 设置普通消息
        /// </summary>
        /// <param name="message">普通消息</param>
        public void SetMessage(string message) => Message = message;
        /// <summary>
        /// 设置警告消息
        /// </summary>
        /// <param name="warningMessage">警告消息</param>
        public void SetWarningMessage(string warningMessage) => WarningMessage = warningMessage;

        #endregion
    }
}
