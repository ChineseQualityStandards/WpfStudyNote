using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly WebApplicationDbContext _context;

        public AccountsController(WebApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Accounts
        [HttpGet]
        [Tags("用户管理")]
        public async Task<ApiReponse> GetAccounts()
        {
            var accounts = await _context.Accounts.ToListAsync();
            // 不返回密码哈希，避免泄露
            foreach (var account in accounts)
            {
                account.PasswordHash = null;
            }
            return ApiReponse.Ok(accounts);
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        [Tags("用户管理")]
        public async Task<ApiReponse> GetAccounts(int id)
        {
            var accounts = await _context.Accounts.FindAsync(id);

            if (accounts == null)
            {
                return ApiReponse.NoContent();
            }
            // 不返回密码哈希，避免泄露
            accounts.PasswordHash = null;
            return ApiReponse.Ok(accounts);
        }

        // POST: api/Accounts/Login
        [HttpPost]
        [Tags("用户管理")]
        public async Task<ApiReponse> Login(string value, string password)
        {
            Accounts account = null;

            if (int.TryParse(value, out int intValue))
            {
                account = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == intValue);
            }
            /*
             if (account == null)
            {
                account = await _context.Accounts
                    .FirstOrDefaultAsync(a => a.AccountName == value && a.PasswordHash == HashSHA256(password));
            }
            */
            if (account == null)
            {
                account = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == value);
            }
            if (account == null)
            {
                return ApiReponse.NotFound();
            }
            if(account.PasswordHash != HashSHA256(password))
            {
                return ApiReponse.PasswordError();
            }
            // 不返回密码哈希，避免泄露
            account.PasswordHash = null;
            return ApiReponse.Ok(account);
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Tags("用户管理")]
        public async Task<ApiReponse> PutAccounts(int id, Accounts account)
        {
            if (id != account.AccountId)
            {
                return ApiReponse.Error("用户ID无法匹配");
            }

            _context.Entry(account).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountsExists(id))
                {
                    return ApiReponse.NotFound();
                }
                else
                {
                    throw;
                }
            }
            account.PasswordHash = null;
            return ApiReponse.Ok(account);
        }

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Tags("用户管理")]
        public async Task<ApiReponse> PostAccounts(Accounts account)
        {
            // 确保不显式设置 AccountId
            account.AccountId = 0;

            if (account.PasswordHash == null)
            {
                return ApiReponse.Error("密码不能为空");
            }
            account.CreatedAt = DateTime.UtcNow;
            account.PasswordHash = HashSHA256(account.PasswordHash);
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            account.PasswordHash = null;
            return ApiReponse.Created(account); 
        }

        // DELETE: api/Accounts/5
        [HttpDelete]
        [Tags("用户管理")]
        public async Task<ApiReponse> DeleteAccounts(int id, string password)
        {
            var accounts = await _context.Accounts.FirstOrDefaultAsync(a => a.AccountId == id);
            if (accounts == null)
            {
                return ApiReponse.NotFound();
            }
            if (accounts.PasswordHash != HashSHA256(password))
            {
                return ApiReponse.PasswordError();
            }

            _context.Accounts.Remove(accounts);
            await _context.SaveChangesAsync();

            return ApiReponse.Gone();
        }

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

        #region 密文处理

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
