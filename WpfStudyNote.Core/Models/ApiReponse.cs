using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStudyNote.Core.Models
{
    /// <summary>
    /// API响应
    /// </summary>
    public class ApiReponse<T>
    {

        /// <summary>
        /// ApiResponse构造函数
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <param name="status">返回状态</param>
        /// <param name="object">代入实体</param>
        public ApiReponse(StatusCode code, string? message, T? @object)
        {
            Code = code;
            Message = message;
            Object = @object;
        }

        public StatusCode Code { get; set; }
        public string? Message { get; set; }
        public T? Object { get; set; }

        /// <summary>
        /// 返回请求内容
        /// </summary>
        /// <param name="code">状态码</param>
        /// <param name="message">信息字段</param>
        /// <param name="object">返回实体</param>
        /// <returns></returns>
        public static ApiReponse<T> Reponse(StatusCode code, string message, T @object) => new ApiReponse<T>(code, message, @object);
    }
}
