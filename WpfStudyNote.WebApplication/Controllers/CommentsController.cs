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
    public class CommentsController : ControllerBase
    {
        #region 字段

        private readonly WebApplicationDbContext _context;

        #endregion

        #region 构造函数

        public CommentsController(WebApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region 接口方法

        [HttpPost]
        [Tags("评论管理")]
        public async Task<ApiReponse> CreateAsync(Comments comments)
        {
            try
            {
                if (comments.ArticleId == 0)
                {
                    throw new NullReferenceException("文章ID不能为空");
                }
                if (comments.AccountId == 0)
                {
                    throw new NullReferenceException("作者ID不能为空");
                }
                if (string.IsNullOrEmpty(comments.Content))
                {
                    throw new NullReferenceException("评论内容不能为空");
                }
                comments.CommentId = 0;
                _context.Comments.Add(comments);
                await _context.SaveChangesAsync();

                return ApiReponse.Created(comments);
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Tags("评论管理")]
        public async Task<ApiReponse> DeleteAsync(int id)
        {
            try
            {
                var comments = await _context.Comments.FindAsync(id);
                if (comments == null)
                {
                    return ApiReponse.NotFound();
                }

                _context.Comments.Remove(comments);
                await _context.SaveChangesAsync();

                return ApiReponse.Delete();
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Tags("评论管理")]
        public async Task<ApiReponse> GetAllAsync(int id)
        {
            try
            {
                return ApiReponse.Found(await _context.Comments.Where(c => c.ArticleId.Equals(id)).ToListAsync());
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Tags("评论管理")]
        public async Task<ApiReponse> GetExactAsync(int id)
        {
            try
            {
                var comments = await _context.Comments.FindAsync(id);

                if (comments == null)
                {
                    return ApiReponse.NotFound();
                }

                return ApiReponse.Found(comments);
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [Tags("评论管理")]
        public async Task<ApiReponse> UpdateAsync(int id,Comments comments)
        {
            if (comments == null)
            {
                throw new NullReferenceException("评论不能为空");
            }
            if(id != comments.AccountId)
            {
                return ApiReponse.Unauthorized();
            }
            _context.Entry(comments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentsExists(id))
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

        #endregion

        #region 私有方法

        private bool CommentsExists(int id)
        {
            return _context.Comments.Any(e => e.CommentId == id);
        }

        #endregion
    }
}
