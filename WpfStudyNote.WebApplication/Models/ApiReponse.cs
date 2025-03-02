namespace WpfStudyNote.WebApplication.Models
{
    /// <summary>
    /// API响应
    /// </summary>
    public class ApiReponse
    {
        public ApiReponse(object @object, StatusCode code = StatusCode.OK)
        {
            Code = code;
            Object = @object;
        }

        public ApiReponse(object? @object)
        {
            Object = @object;
        }

        /// <summary>
        /// ApiResponse构造函数
        /// </summary>
        /// <param name="message">提示信息</param>
        /// <param name="status">返回状态</param>
        /// <param name="object">代入实体</param>
        public ApiReponse(StatusCode code, string? message, object? @object) : this(message, code)
        {
            Message = message;
            Object = @object;
        }

        public StatusCode Code { get; set; }
        public string? Message { get; set; }
        public object? Object { get; set; }

        /// <summary>
        /// 请求成功
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static ApiReponse Accepted(object? @object = null) => new ApiReponse(StatusCode.Accepted, "请求成功", @object);
        /// <summary>
        /// 创建成功
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static ApiReponse Created(object? @object = null) => new ApiReponse(StatusCode.Created, "创建成功", @object);
        /// <summary>
        /// 删除成功
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static ApiReponse Delete(object? @object = null) => new ApiReponse(StatusCode.Deleted, "删除成功", @object);
        /// <summary>
        /// 错误请求
        /// </summary>
        /// <param name="message">错误信息</param>
        /// <param name="object"></param>
        /// <returns></returns>
        public static ApiReponse Error(string message, object? @object = null) => new ApiReponse(StatusCode.BadRequest,message, @object);
        /// <summary>
        /// 查询完成
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static ApiReponse Found(object? @object = null) => new ApiReponse(StatusCode.Found, "查询完成", @object);
        /// <summary>
        /// 操作完成
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static ApiReponse Gone(object? @object = null) => new ApiReponse(StatusCode.Gone, "操作完成", @object);
        /// <summary>
        /// 修改完成
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static ApiReponse Modified(object? @object = null) => new ApiReponse(StatusCode.Modified,"修改完成",@object);
        public static ApiReponse NoContent(object? @object = null) => new ApiReponse(StatusCode.NoContent, "查无对象", @object);
        public static ApiReponse NotFound(object? @object = null) => NotFound("未找到对象", @object);
        public static ApiReponse NotFound(string message, object? @object = null) => new ApiReponse(StatusCode.NotFound,message, @object);
        public static ApiReponse Ok(object? @object = null) => new ApiReponse(@object,StatusCode.OK);
        public static ApiReponse Ok(string message, object? @object) => new ApiReponse(StatusCode.OK, message, @object);
        /// <summary>
        /// 密码错误
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static ApiReponse PasswordError(object? @object = null) => new ApiReponse(StatusCode.PasswordError,"密码错误", @object);
        /// <summary>
        /// 没有权限
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static ApiReponse Unauthorized(object? @object = null) => new ApiReponse(StatusCode.Unauthorized, "没有权限", @object);

    }
}
