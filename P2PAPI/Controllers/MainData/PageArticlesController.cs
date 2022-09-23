using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2P.DTO.Input;
using P2P.DTO.Output;
using P2P.Services;
using System.Threading.Tasks;
using System;
using Entities.P2P.MainData;

namespace P2P.WebApi.Controllers.MainData
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class PageArticlesController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public PageArticlesController(MainDataServices mainServices)
        {
            _mainDataServices = mainServices;
        }

        //GET: api/PageArticles
        [HttpGet("{id}")]
        public async Task<ActionResult<PageArticlesODTO>> GetPageArticlesById(int id)
        {
            var pageArticles = await _mainDataServices.GetPageArticlesById(id);
            if (pageArticles == null)
            {
                return NotFound();
            }
            return pageArticles;
        }

        //PUT: api/PageArticles
        [HttpPut]
        public async Task<ActionResult<PageArticlesODTO>> PutPageArticles(PagesArticlesIDTO pageArticlesIDTO)
        {
            try
            {
                return await _mainDataServices.EditPageArticles(pageArticlesIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/PageArticles
        [HttpPost]
        public async Task<ActionResult<PageArticlesODTO>> PostPageArticles(PagesArticlesIDTO pageArticlesIDTO)
        {
            try
            {
                return await _mainDataServices.AddPageArticles(pageArticlesIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/PageArticles/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<PageArticlesODTO>> DeletePageArticles(int id)
        {
            try
            {
                var pageArticles = await _mainDataServices.DeletePageArticles(id);
                if (pageArticles == null) return NotFound();
                return pageArticles;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}