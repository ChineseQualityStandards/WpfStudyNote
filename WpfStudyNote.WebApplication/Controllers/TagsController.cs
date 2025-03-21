﻿using System;
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
    public class TagsController : ControllerBase
    {
        #region 字段

        private readonly WebApplicationDbContext _context;

        #endregion

        #region 构造函数

        public TagsController(WebApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        #region 接口方法

        [HttpPost]
        [Tags("标签管理")]
        public async Task<ApiReponse> CreateAsync(Tags tags)
        {
            try
            {
                if (tags.TagName == null)
                {
                    throw new NullReferenceException("标签名不能为空");
                }
                _context.Tags.Add(tags);
                await _context.SaveChangesAsync();

                return ApiReponse.Created(tags);
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Tags("标签管理")]
        public async Task<ApiReponse> DeleteAsync(int id)
        {
            try
            {
                var tags = await _context.Tags.FindAsync(id);
                if (tags == null)
                {
                    return ApiReponse.NotFound();
                }

                _context.Tags.Remove(tags);
                await _context.SaveChangesAsync();

                return ApiReponse.Delete();
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpGet]
        [Tags("标签管理")]
        public async Task<ApiReponse> GetAllAsync()
        {
            try
            {
                return ApiReponse.Found(await _context.Tags.ToListAsync());
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Tags("标签管理")]
        public async Task<ApiReponse> GetExactAsync(int id)
        {
            try
            {
                var result = await _context.Tags.FindAsync(id);

                if (result == null)
                {
                    return ApiReponse.NotFound();
                }

                return ApiReponse.Found(result);
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        [HttpPut]
        [Tags("标签管理")]
        public async Task<ApiReponse> UpdateAsync(Tags tags)
        {
            try
            {
                _context.Entry(tags).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TagsExists(tags.TagId))
                    {
                        return ApiReponse.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return ApiReponse.Modified(tags);
            }
            catch (Exception ex)
            {
                return ApiReponse.Error(ex.Message);
            }
        }

        #endregion

        #region 辅助方法

        private bool TagsExists(int id)
        {
            return _context.Tags.Any(e => e.TagId == id);
        }

        #endregion
    }
}
