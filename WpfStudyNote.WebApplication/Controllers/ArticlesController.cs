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
        private readonly WebApplicationDbContext _context;

        public ArticlesController(WebApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Articles
        [HttpGet]
        [Tags("文章管理")]
        public async Task<ApiReponse> GetArticles()
        {
            return ApiReponse.Ok(await _context.Articles.ToListAsync());
        }

        // GET: api/Articles/5
        [HttpGet("{id}")]
        [Tags("文章管理")]
        public async Task<ApiReponse> GetArticles(int id)
        {
            var articles = await _context.Articles.FindAsync(id);

            if (articles == null)
            {
                return ApiReponse.NotFound();
            }

            return ApiReponse.Ok(articles);
        }

        // PUT: api/Articles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Tags("文章管理")]
        public async Task<ApiReponse> PutArticles(int id, Articles articles)
        {
            if (id != articles.ArticleId)
            {
                return ApiReponse.Error("没有修改权限");
            }

            // 更新 UpdatedAt 列
            articles.UpdatedAt = DateTime.UtcNow;
            _context.Entry(articles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ArticlesExists(id))
                {
                    return ApiReponse.NotFound();
                }
                else
                {
                    return ApiReponse.Error(ex.Message);
                }
            }

            return ApiReponse.Modified();
        }

        // POST: api/Articles
        [HttpPost]
        [Tags("文章管理")]
        public async Task<ApiReponse> PostArticles(Articles article)
        {
            // 确保不显式设置 ArticleId
            article.ArticleId = 0;
            article.UpdatedAt = DateTime.UtcNow;
            article.CreatedAt = DateTime.UtcNow;

            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
            return ApiReponse.Created(article);
        }

        // DELETE: api/Articles/5
        [HttpDelete("{id}")]
        [Tags("文章管理")]
        public async Task<ApiReponse> DeleteArticles(int id)
        {
            var articles = await _context.Articles.FindAsync(id);
            if (articles == null)
            {
                return ApiReponse.NotFound();
            }

            _context.Articles.Remove(articles);
            await _context.SaveChangesAsync();

            return ApiReponse.Gone();
        }

        private bool ArticlesExists(int id)
        {
            return _context.Articles.Any(e => e.ArticleId == id);
        }
    }
}
