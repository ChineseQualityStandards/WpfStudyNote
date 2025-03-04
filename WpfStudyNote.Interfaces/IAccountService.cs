using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfStudyNote.Core.Models;

namespace WpfStudyNote.Interfaces
{
    public interface IAccountService<R,E> : IWebApiService<R, E>
    {
        /// <summary>
        /// 删除<typeparamref name="E"/>
        /// </summary>
        /// <param name="entity"><typeparamref name="E"/></param>
        /// <returns><typeparamref name="R"/></returns>
        Task<R> DeleteAsync(E entity);
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="accounts">用户实体</param>
        /// <returns><typeparamref name="R"/></returns>
        Task<R> LoginAsync(Accounts accounts);
        /// <summary>
        /// 修改用户数据
        /// </summary>
        /// <param name="password">旧密码</param>
        /// <param name="accounts">保存密码的用户实体</param>
        /// <returns><typeparamref name="R"/></returns>
        Task<R> UpdateAsync(string password, Accounts accounts);

    }
}
