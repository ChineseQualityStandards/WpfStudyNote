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
    public class CategoriesController : ControllerBase
    {
        #region 字段

        private readonly WebApplicationDbContext _context;

        #endregion

        #region 构造函数

        public CategoriesController(WebApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region 接口方法

        [HttpPost]
        [Tags("分类管理")]
        public async Task<ApiReponse> CreateAsync(Categories categories)
        {
            try
            {
                _context.Categories.Add(categories);
                await _context.SaveChangesAsync();

                return ApiReponse.Created(categories);
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        [Tags("分类管理")]
        public async Task<ApiReponse> DeleteAsync(int id)
        {
            try
            {
                var categories = await _context.Categories.FindAsync(id);
                if (categories == null)
                {
                    return ApiReponse.NotFound();
                }

                _context.Categories.Remove(categories);
                await _context.SaveChangesAsync();

                return ApiReponse.Delete();
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpGet]
        [Tags("分类管理")]
        public async Task<ApiReponse> GetAllAsync()
        {
            try
            {
                return ApiReponse.Found(await _context.Categories.ToListAsync());
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Tags("分类管理")]
        public async Task<ApiReponse> GetExactAsync(int id)
        {
            try
            {
                var categories = await _context.Categories.FindAsync(id);

                if (categories == null)
                {
                    return ApiReponse.NotFound();
                }

                return ApiReponse.Found(categories);
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpPut]
        [Tags("分类管理")]
        public async Task<ApiReponse> UpdateAsync(Categories categories)
        {
            try
            {
                _context.Entry(categories).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriesExists(categories.CategoryId))
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

        private bool CategoriesExists(int id)
        {
            return _context.Categories.Any(e => e.CategoryId == id);
        }

        #endregion
    }
}
