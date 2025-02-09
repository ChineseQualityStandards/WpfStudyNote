﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStudyNote.Core.Models
{
    /// <summary>
    /// 消息类
    /// </summary>
    public class Messages : BindableBase
    {
        #region 属性

        private string? errorMessage;
        /// <summary>
        /// 错误消息
        /// </summary>
        public string? ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        private string? message;
        /// <summary>
        /// 普通消息
        /// </summary>
        public string? Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        private string? warningMessage;
        /// <summary>
        /// 警告消息
        /// </summary>
        public string? WarningMessage
        {
            get { return warningMessage; }
            set { SetProperty(ref warningMessage, value); }
        }

        #endregion
    }
}
