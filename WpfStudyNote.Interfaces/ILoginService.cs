using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfStudyNote.Core.Models;

namespace WpfStudyNote.Interfaces
{
    public interface ILoginService
    {
        public Task<ApiReponse> LoginAsync(string value, string password);
    }
}
