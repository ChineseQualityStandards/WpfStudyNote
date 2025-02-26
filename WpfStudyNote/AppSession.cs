using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfStudyNote.Core.Models;

namespace WpfStudyNote
{
    public class AppSession
    {
        public static Accounts? User { get; private set; }

        public static Article? Article { get; private set; }

        public static Accounts UserSessionMethod(Accounts updateUser) => User = updateUser;

        public static Article BlogSessionMethod(Article article) => Article = article;
    }
}
