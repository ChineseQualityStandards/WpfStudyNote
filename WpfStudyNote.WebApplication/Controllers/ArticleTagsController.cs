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
    public class ArticleTagsController : ControllerBase
    {
        #region 字段

        private readonly WebApplicationDbContext _context;

        #endregion

        #region 构造函数

        public ArticleTagsController(WebApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region 接口方法

        [HttpPost]
        [Tags("文章标签关联管理")]
        public async Task<ApiReponse> CreateAsync(ArticleTags articleTags)
        {
            try
            {
                if (ArticleTagsExists(articleTags))
                    throw new Exception("已存在对应关系");
                _context.ArticleTags.Add(articleTags);
                await _context.SaveChangesAsync();

                return ApiReponse.Created(articleTags);
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Tags("文章标签关联管理")]
        public async Task<ApiReponse> DeleteAsync(int id)
        {
            try
            {
                var articleTags = await _context.ArticleTags.FindAsync(id);
                if (articleTags == null)
                {
                    return ApiReponse.NotFound();
                }

                _context.ArticleTags.Remove(articleTags);
                await _context.SaveChangesAsync();

                return ApiReponse.Delete();
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpGet]
        [Tags("文章标签关联管理")]
        public async Task<ApiReponse> GetAllAsync()
        {
            try
            {
                return ApiReponse.Found(await _context.ArticleTags.ToListAsync());
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Tags("文章标签关联管理")]
        public async Task<ApiReponse> GetExactAsync(int id)
        {
            try
            {
                var articleTags = await _context.ArticleTags.FindAsync(id);

                if (articleTags == null)
                {
                    return ApiReponse.NotFound();
                }

                return ApiReponse.Found(articleTags);
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpPut]
        [Tags("文章标签关联管理")]
        public async Task<ApiReponse> UpdateAsync(ArticleTags articleTags)
        {
            try
            {
                _context.Entry(articleTags).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleTagsExists(articleTags.ArticleTagId))
                    {
                        return ApiReponse.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return ApiReponse.Modified(articleTags);
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        #endregion

        #region 辅助方法

        private bool ArticleTagsExists(int id)
        {
            return _context.ArticleTags.Any(e => e.ArticleTagId == id);
        }

        private bool ArticleTagsExists(ArticleTags articleTags)
        {
            return _context.ArticleTags.Any(e => e.ArticleId == articleTags.ArticleId && e.TagId == articleTags.TagId);
        }
        #endregion
    }
}
