using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfStudyNote.Interfaces
{
    /// <summary>
    /// 关于<typeparamref name="T"/>的服务端接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="R"></typeparam>
    public class IApiService<T,R>
    {
        /// <summary>
        /// 创建<typeparamref name="T"/>
        /// </summary>
        /// <param name="t"><typeparamref name="T"/></param>
        /// <returns><typeparamref name="R"/></returns>
        public Task<R>? CreateAsync(T t)
        {
            return default;
        }

        /// <summary>
        /// 删除<typeparamref name="T"/>
        /// </summary>
        /// <param name="t"><typeparamref name="T"/></param>
        /// <returns><typeparamref name="R"/></returns>
        public Task<R>? DeleteAsync(T t)
        {
            return default;
        }

        /// <summary>
        /// 获取所有<typeparamref name="T"/>
        /// </summary>
        /// <param name="t"><typeparamref name="T"/></param>
        /// <returns><typeparamref name="R"/></returns>
        public Task<R>? GetAllAsync()
        {
            return default;
        }

        /// <summary>
        /// 精确搜索<typeparamref name="T"/>
        /// </summary>
        /// <param name="t"><typeparamref name="T"/></param>
        /// <returns><typeparamref name="R"/></returns>
        public Task<R>? GetExactAsync(T t)
        {
            return default;
        }

        /// <summary>
        /// 模糊搜索<typeparamref name="T"/>
        /// </summary>
        /// <param name="t"><typeparamref name="T"/></param>
        /// <returns><typeparamref name="R"/></returns>
        public Task<R>? GetFuzzyAsync(T t)
        {
            return default;
        }


        /// <summary>
        /// 更新<typeparamref name="T"/>
        /// </summary>
        /// <param name="t"><typeparamref name="T"/></param>
        /// <returns><typeparamref name="R"/></returns>
        public Task<R>? UpdateAsync(T t)
        {
            return default;
        }
    }
}
