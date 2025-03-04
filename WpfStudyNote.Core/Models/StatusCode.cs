using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStudyNote.Core.Models
{
    /// <summary>
    /// 状态码
    /// </summary>
    public enum StatusCode
    {
        /// <summary>
        /// 请求成功
        /// </summary>
        OK = 200,
        /// <summary>
        /// 创建成功
        /// </summary>
        Created = 201,
        /// <summary>
        /// 请求已接受
        /// </summary>
        Accepted = 202,
        /// <summary>
        /// 删除成功
        /// </summary>
        Deleted = 203,
        /// <summary>
        /// 无内容
        /// </summary>
        NoContent = 204,
        /// <summary>
        /// 重定向
        /// </summary>
        MovedPermanently = 301,
        /// <summary>
        /// 已经发现
        /// </summary>
        Found = 302,
        /// <summary>
        /// 未修改
        /// </summary>
        NotModified = 304,
        /// <summary>
        /// 已修改
        /// </summary>
        Modified = 307,
        /// <summary>
        /// 错误请求
        /// </summary>
        BadRequest = 400,
        /// <summary>
        /// 未授权
        /// </summary>
        Unauthorized = 401,
        /// <summary>
        /// 禁止
        /// </summary>
        Forbidden = 403,
        /// <summary>
        /// 未找到
        /// </summary>
        NotFound = 404,
        /// <summary>
        /// 方法不允许
        /// </summary>
        MethodNotAllowed = 405,
        /// <summary>
        /// 请求超时
        /// </summary>
        RequestTimeout = 408,
        /// <summary>
        /// 冲突
        /// </summary>
        Conflict = 409,
        /// <summary>
        /// 已删除
        /// </summary>
        Gone = 410,
        /// <summary>
        /// 长度必需
        /// </summary>
        PreconditionFailed = 412,
        /// <summary>
        /// 不支持的媒体类型
        /// </summary>
        UnsupportedMediaType = 415,
        /// <summary>
        /// 请求范围不符合要求
        /// </summary>
        InternalServerError = 500,
        /// <summary>
        /// 未实现
        /// </summary>
        NotImplemented = 501,
        /// <summary>
        /// 错误网关
        /// </summary>
        BadGateway = 502,
        /// <summary>
        /// 服务不可用
        /// </summary>
        ServiceUnavailable = 503,
        /// <summary>
        /// 网关超时
        /// </summary>
        GatewayTimeout = 504,
        /// <summary>
        /// HTTP版本不支持
        /// </summary>
        HttpVersionNotSupported = 505,
        /// <summary>
        /// 需要代理身份验证
        /// </summary>
        InsufficientStorage = 507,
        /// <summary>
        /// 循环检测
        /// </summary>
        LoopDetected = 508,
        /// <summary>
        /// 带宽限制超出
        /// </summary>
        BandwidthLimitExceeded = 509,
        /// <summary>
        /// 未扩展
        /// </summary>
        NotExtended = 510,
        /// <summary>
        /// 网络身份验证要求
        /// </summary>
        NetworkAuthenticationRequired = 511,
        /// <summary>
        /// 网络连接超时
        /// </summary>
        NetworkConnectTimeoutError = 599,
        /// <summary>
        /// 未知错误
        /// </summary>
        Unknown = 999,
        /// <summary>
        /// 密码错误
        /// </summary>
        PasswordError = 1000,
        /// <summary>
        /// 退出
        /// </summary>
        Exit = 1001,
    }
}
