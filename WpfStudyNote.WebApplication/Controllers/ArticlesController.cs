using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WpfStudyNote.WebApplication.DbContexts;
using WpfStudyNote.WebApplication.Models;

namespace WpfStudyNote.WebApplication.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        #region 字段

        private readonly WebApplicationDbContext _context;

        #endregion

        #region 构造函数

        public ArticlesController(WebApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region 接口方法

        [HttpPost]
        [Tags("文章管理")]
        public async Task<ApiReponse> CreateAsync(Articles article)
        {
            try
            {
                ResetArticles(article);

                _context.Articles.Add(article);
                await _context.SaveChangesAsync();
                return ApiReponse.Created(article);
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Tags("文章管理")]
        public async Task<ApiReponse> DeleteAsync(int id)
        {
            try
            {
                var articles = await _context.Articles.FindAsync(id);
                if (articles == null)
                {
                    return ApiReponse.NotFound();
                }

                _context.Articles.Remove(articles);
                await _context.SaveChangesAsync();

                return ApiReponse.Delete();
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpGet]
        [Tags("文章管理")]
        public async Task<ApiReponse> GetAllAsync()
        {
            try
            {
                return ApiReponse.Found(await _context.Articles.ToListAsync());
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Tags("文章管理")]
        public async Task<ApiReponse> GetExactAsync(int id)
        {
            try
            {
                var articles = await _context.Articles.FindAsync(id);

                if (articles == null)
                {
                    return ApiReponse.NotFound();
                }

                return ApiReponse.Found(articles);
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Tags("文章管理")]
        public async Task<ApiReponse> UpdateAsync(int id, Articles articles)
        {
            try
            {
                if (id != articles.AuthorId)
                {
                    return ApiReponse.Unauthorized();
                }

                // 更新 UpdatedAt 列
                articles.UpdatedAt = DateTime.UtcNow;
                _context.Entry(articles).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticlesExists(id))
                    {
                        return ApiReponse.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return ApiReponse.Modified();
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        #endregion

        #region 辅助方法

        private bool ArticlesExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleId == id);
        }

        ///<summary>
        /// 重置Articles数据,确保不显式设置
        ///</summary>
        private void ResetArticles(Articles article)
        {
            article.ArticleId = 0;
            article.UpdatedAt = DateTime.UtcNow;
            article.CreatedAt = DateTime.UtcNow;
        }

        #endregion

    }
}
