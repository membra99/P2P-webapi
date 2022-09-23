using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2P.DTO.Input;
using P2P.DTO.Output;
using P2P.Services;
using System.Threading.Tasks;
using System;
using P2P.DTO.Output.EndPointODTO;
using System.Collections;
using System.Collections.Generic;

namespace P2P.WebApi.Controllers.MainData
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class NewsFeedController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public NewsFeedController(MainDataServices mainServices)
        {
            _mainDataServices = mainServices;
        }

        //GET: api/NewsFeed
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsFeedODTO>> GetNewsFeedById(int id)
        {
            var newsFeed = await _mainDataServices.GetNewsFeedById(id);
            if (newsFeed == null)
            {
                return NotFound();
            }
            return newsFeed;
        }

        [HttpGet("GetList/{langId}")]
        public async Task<ActionResult<IEnumerable<GetNewsFeedListODTO>>> GetListNewsFeedByLangId(int langId)
        {
            var newsFeed = await _mainDataServices.GetListNewsFeedByLangId(langId);
            if (newsFeed == null)
            {
                return NotFound();
            }
            return newsFeed;
        }

        [HttpGet("GetAllNews")]
        public async Task<ActionResult<IEnumerable<GetNewsFeedListODTO>>> GetAllNews(int Id)
        {
            var newsFeed = await _mainDataServices.GetAllNews(Id);
            if (newsFeed == null)
            {
                return NotFound();
            }
            return newsFeed;
        }

        //PUT: api/NewsFeed
        [HttpPut]
        public async Task<ActionResult<NewsFeedODTO>> PutNewsFeed(NewsFeedIDTO newsFeedIDTO)
        {
            try
            {
                return await _mainDataServices.EditNewsFeed(newsFeedIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/NewsFeed
        [HttpPost]
        public async Task<ActionResult<NewsFeedODTO>> PostNewsFeed(NewsFeedIDTO newsFeedIDTO)
        {
            try
            {
                return await _mainDataServices.AddNewsFeed(newsFeedIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/NewsFeed/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<NewsFeedODTO>> DeleteNewsFeed(int id)
        {
            try
            {
                var newsFeed = await _mainDataServices.DeleteNewsFeed(id);
                if (newsFeed == null) return NotFound();
                return newsFeed;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}