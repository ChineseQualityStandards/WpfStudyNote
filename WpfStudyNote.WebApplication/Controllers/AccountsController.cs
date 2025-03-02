using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WpfStudyNote.WebApplication.DbContexts;
using WpfStudyNote.WebApplication.Models;

namespace WpfStudyNote.WebApplication.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        #region 字段

        private readonly WebApplicationDbContext _context;

        #endregion

        #region 构造函数

        public AccountsController(WebApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region 接口方法

        [HttpPost]
        [Tags("用户管理")]
        public async Task<ApiReponse> CreateAsync(Accounts account)
        {
            try
            {
                // 确保不显式设置 AccountId
                account.AccountId = 0;
                if (string.IsNullOrEmpty(account.AccountName) || string.IsNullOrEmpty(account.Email))
                {
                    throw new NullReferenceException("用户名和邮箱为必须值");
                }
                if (string.IsNullOrEmpty(account.PasswordHash))
                {
                    throw new NullReferenceException("密码为必须值");
                }
                if (AccountNameExists(account.AccountName))
                {
                    throw new Exception("用户名已存在");
                }
                if (EmailExists(account.Email))
                {
                    throw new Exception("邮箱已存在");
                }
                account.CreatedAt = DateTime.UtcNow;
                account.PasswordHash = HashSHA256(account.PasswordHash);
                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();
                account.PasswordHash = null;
                return ApiReponse.Created(account);
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpDelete]
        [Tags("用户管理")]
        public async Task<ApiReponse> DeleteAsync(Accounts account)
        {
            try
            {
                if (string.IsNullOrEmpty(account.PasswordHash) || account.AccountId == 0)
                {
                    throw new NullReferenceException("密码和用户ID为必须值");
                }
                var result = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == account.AccountId);
                if (result == null)
                {
                    return ApiReponse.NotFound();
                }
                if (result.PasswordHash != HashSHA256(account.PasswordHash))
                {
                    return ApiReponse.PasswordError();
                }

                _context.Accounts.Remove(result);
                await _context.SaveChangesAsync();

                return ApiReponse.Delete();
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpGet]
        [Tags("用户管理")]
        public async Task<ApiReponse> GetAllAsync()
        {
            try
            {
                var results = await _context.Accounts.ToListAsync();
                if (results.Count == 0)
                {
                    return ApiReponse.NoContent();
                }
                // 不返回密码哈希，避免泄露
                foreach (var account in results)
                {
                    account.PasswordHash = null;
                }
                return ApiReponse.Found(results);
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Tags("用户管理")]
        public async Task<ApiReponse> GetExactAsync(int id)
        {
            try
            {
                var result = await _context.Accounts.FindAsync(id);
                if (result == null)
                {
                    return ApiReponse.NoContent();
                }
                // 不返回密码哈希，避免泄露
                result.PasswordHash = null;
                return ApiReponse.Found(result);
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpPut("{password}")]
        [Tags("用户管理")]
        public async Task<ApiReponse> UpdateAsync(string password,Accounts account)
        {
            try
            {
                var user = await _context.Accounts.FindAsync(account.AccountId);
                if (user == null) return ApiReponse.NotFound();
                if (user.PasswordHash != HashSHA256(password))
                {
                    return ApiReponse.PasswordError();
                }

                // 更新用户属性
                user.AccountName = account.AccountName;
                user.Email = account.Email;
                user.PasswordHash = HashSHA256(account.PasswordHash);
                _context.Entry(user).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountsExists(user.AccountId))
                    {
                        return ApiReponse.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                user.PasswordHash = null;
                return ApiReponse.Modified(user);
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }


        }   

        [HttpPost]
        [Tags("用户管理")]
        public async Task<ApiReponse> LoginAsync(Accounts accounts)
        {
            Accounts result = null;

            if (accounts.AccountId != 0)
            {
                result = await _context.Accounts.FindAsync(accounts.AccountId);
            }
            else if (accounts.AccountName != null)
            {
                result = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountName == accounts.AccountName);
            }
            else if (accounts.Email != null)
            {
                result = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == accounts.Email);
            }
            else
            {
                throw new NullReferenceException("用户名或邮箱不能为空");
            }
            if (result == null)
            {
                return ApiReponse.NotFound();
            }
            if (result.PasswordHash != HashSHA256(accounts.PasswordHash))
            {
                return ApiReponse.PasswordError();
            }
            // 不返回密码哈希，避免泄露
            result.PasswordHash = null;
            return ApiReponse.Accepted(result);
        }



        #endregion

        #region 辅助方法


        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool AccountsExists(int id)
        {
            return _context.Accounts.Any(e => e.AccountId == id);
        }

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="accountName"></param>
        /// <returns></returns>
        private bool AccountNameExists(string accountName)
        {
            return _context.Accounts.Any(e => e.AccountName == accountName);
        }

        /// <summary>
        /// 判断用户是否存在
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool EmailExists(string email)
        {
            return _context.Accounts.Any(e => e.Email == email);
        }

        /// <summary>
        /// 判断是否是邮箱
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool IsEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 字符串转字节数组
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private byte[] StringToByte(string input)
        {
            return Encoding.UTF8.GetBytes(input);
        }

        /// <summary>
        /// 字节数组转字符串
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string ByteToString(byte[] input)
        {
            return Convert.ToBase64String(input);
        }

        /// <summary>
        /// SHA256加密
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string HashSHA256(string s)
        {
            SHA256 cryptogram = SHA256.Create();
            byte[] bytes = cryptogram.ComputeHash(StringToByte(s));
            return ByteToString(bytes);
        }

        #endregion
    }
}
