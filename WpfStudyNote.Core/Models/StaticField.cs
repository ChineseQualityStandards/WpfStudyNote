using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStudyNote.Core.Models
{
    public class StaticField
    {
        #region WebBaseLink
        public string Web_Host = AppSettings.Default.WebApiUrl;
        public const string LocalHost = "https://localhost:7076/";
        #endregion

        #region PageName
        public const string Tags = "Tags/";
        public const string Categories = "Categories/";
        public const string Comments = "Comments/";
        public const string ArticleTags = "ArticleTags/";
        public const string Articles = "Articles/";
        public const string Accounts = "Accounts/";
        #endregion

        #region MethodName

        public const string Create = "Create/";
        public const string Delete = "Delete/";
        public const string GetAll = "GetAll/";
        public const string GetExact = "GetExact/";
        public const string Update = "Update/";
        public const string Login = "Login/";

        #endregion

        #region Other

        public const string WSN = "wsn.com";

        #endregion
    }
}
