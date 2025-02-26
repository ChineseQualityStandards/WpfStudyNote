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
            Object = @object;
        }

        public StatusCode Code { get; set; }
        public string? Message { get; set; }
        public object? Object { get; set; }

        public static ApiReponse Ok(object? @object = null) => new ApiReponse(@object,StatusCode.OK);

        public static ApiReponse Created(object? @object = null) => new ApiReponse(@object, StatusCode.Created);

        public static ApiReponse Accepted(object? @object = null) => new ApiReponse(@object, StatusCode.Accepted);

        public static ApiReponse NoContent(object? @object = null) => new ApiReponse(@object, StatusCode.NoContent);

        public static ApiReponse Unauthorized(string message, object? @object = null) => new ApiReponse(@object, StatusCode.Unauthorized);

        public static ApiReponse Error(string message, object? @object = null) => new ApiReponse(@object, StatusCode.BadRequest);

        public static ApiReponse Gone(object? @object = null) => new ApiReponse(@object, StatusCode.Gone);

        public static ApiReponse NotFound(object? @object = null) => NotFound("数据库中未找到对象", @object);
        public static ApiReponse NotFound(string message, object? @object = null) => new ApiReponse(@object, StatusCode.NotFound);
        public static ApiReponse Modified(object? @object = null) => new ApiReponse(StatusCode.Modified,"内容已修改",@object);
        public static ApiReponse PasswordError(object? @object = null) => new ApiReponse(@object, StatusCode.PasswordError);
    }
}
