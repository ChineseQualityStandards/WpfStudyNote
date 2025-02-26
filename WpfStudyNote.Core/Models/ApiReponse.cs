using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStudyNote.Core.Models
{
    public class ApiReponse
    {
        public StatusCode Code { get; set; }
        public string? Message { get; set; }
        public object? Object { get; set; }
    }
}
