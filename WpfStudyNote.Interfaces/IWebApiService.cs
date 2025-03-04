using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfStudyNote.Core.Models;

namespace WpfStudyNote.Interfaces
{
    /// <summary>
    /// WebApi 服务接口范型
    /// </summary>
    /// <typeparam name="R"></typeparam>
    /// <typeparam name="E"></typeparam>
    public interface IWebApiService<R, E>
    {
        /// <summary>
        /// 创建<typeparamref name="E"/>
        /// </summary>
        /// <param name="entity"><typeparamref name="E"/></param>
        /// <returns><typeparamref name="R"/></returns>
        Task<R> CreateAsync(E entity);
        /// <summary>
        /// 删除<typeparamref name="E"/>
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns><typeparamref name="R"/></returns>
        Task<R> DeleteAsync(int id);
        /// <summary>
        /// 获取所有<typeparamref name="E"/>
        /// </summary>
        /// <returns><typeparamref name="R"/></returns>
        Task<R> GetAllAsync();
        /// <summary>
        /// 获取指定<paramref name="id"/>的<typeparamref name="E"/>
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        Task<R> GetExactsync(int id);
        /// <summary>
        /// 更新<typeparamref name="E"/>
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="entity"><typeparamref name="E"/></param>
        /// <returns><typeparamref name="R"/></returns>
        Task<R> UpdateAsync(int id, E entity);

    }
}
