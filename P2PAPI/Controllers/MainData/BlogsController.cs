using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2P.DTO.Input;
using P2P.DTO.Output;
using P2P.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using P2P.DTO.Output.EndPointODTO;
using P2P.DTO.Input.EndpointIDTO;

namespace P2P.WebApi.Controllers.MainData
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class BlogsController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public BlogsController(MainDataServices mainDataServices)
        {
            _mainDataServices = mainDataServices;
        }

        //GET: api/Blogs
        [HttpGet("ById")]
        public async Task<ActionResult<BlogODTO>> GetById(int id)
        {
            var blog = await _mainDataServices.GetBlogById(id);
            if (blog == null) return NotFound();
            return blog;
        }

        //GET: api/Blogs
        [HttpGet("ByName")]
        public async Task<ActionResult<BlogODTO>> GetByName(string name)
        {
            var blog = await _mainDataServices.GetBlogByName(name);
            if (blog == null) return NotFound();
            return blog;
        }

        //GET: api/Blogs/ByLanguageId
        [HttpGet("ByLanguageId")]
        public async Task<ActionResult<List<BlogODTO>>> GetByLanguageId(int languageId)
        {
            var blog = await _mainDataServices.GetBlogsByLang(languageId);
            if (blog == null) return NotFound();
            return blog;
        }

        //GET: api/Blogs/ByCategoryId
        [HttpGet("ByCategoryId")]
        public async Task<ActionResult<List<BlogODTO>>> GetByCategory(int categoryId)
        {
            var blog = await _mainDataServices.GetBlogsByCategory(categoryId);
            if (blog == null) return NotFound();
            return blog;
        }

        //GET: api/Blogs/GetListOfAuthorsByLanguageId
        [HttpGet("GetListOfAuthorsByLanguageId")]
        public async Task<ActionResult<List<AuthorODTO>>> GetListOfAuthorsByLanguageId(int languageId)
        {
            var blog = await _mainDataServices.GetAuthorsByLanguageId(languageId);
            if (blog == null) return NotFound();
            return blog;
        }

        //GET: api/Blogs/GetListOfAuthorsByLanguageId
        [HttpGet("GetBlogsByRoute")]
        public async Task<ActionResult<GetBlogsByRouteODTO>> GetBlogsByRoute(string route, int langId)
        {
            var blog = await _mainDataServices.GetBlogsByRoute(route, langId);
            if (blog == null) return NotFound();
            return blog;
        }

        //GET: api/Blogs/GetItemContent
        [HttpGet("GetItemContent")]
        public async Task<ActionResult<GetItemContentODTO>> GetItemContent(int id)
        {
            var blog = await _mainDataServices.GetBlogItemContent(id);
            if (blog == null) return NotFound();
            return blog;
        }
        //GET: api/Blogs/GetBlogFull
        [HttpGet("GetBlogFull")]
        public async Task<ActionResult<BlogODTO>> GetFullBlog(int id)
        {
            var blog = await _mainDataServices.GetBlogFull(id);
            if (blog == null) return NotFound();
            return blog;
        }

        //PUT: api/Blogs
        [HttpPut]
        public async Task<ActionResult<BlogODTO>> PutBlog(BlogIDTO blogIDTO)
        {
            try
            {
                return await _mainDataServices.EditBlog(blogIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //PUT: api/Blogs
        [HttpPut("Content")]
        public async Task<ActionResult<BlogODTO>> PutBlogContent(PutContentIDTO contentIDTO)
        {
            try
            {
                return await _mainDataServices.EditBlogContent(contentIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/Blogs
        [HttpPost]
        public async Task<ActionResult<BlogODTO>> PostBlog(BlogIDTO blogIDTO)
        {
            try
            {
                return await _mainDataServices.AddBlog(blogIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/Blogs/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<BlogODTO>> DeleteBlog(int id)
        {
            try
            {
                var blog = await _mainDataServices.DeleteBlog(id);
                if (blog == null) return NotFound();
                return blog;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}