using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using WpfStudyNote.Core.Models;

namespace WpfStudyNote.Interfaces
{
    /// <summary>
    /// RestClient 服务接口
    /// </summary>
    public interface IRestClientService<R>
    {
        /// <summary>
        /// 执行请求
        /// </summary>
        /// <param name="request">请求体</param>
        /// <returns></returns>
        Task<ApiReponse<R>> ExecuteAsync(RestRequest request);
    }
}
