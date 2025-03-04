using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStudyNote.Core.Models
{
    public class AppSession
    {
        public static Accounts? User { get; private set; }

        public static Articles? Article { get; private set; }

        public static Accounts UserSessionMethod(Accounts updateUser) => User = updateUser;

        public static Articles BlogSessionMethod(Articles article) => Article = article;
    }
}
