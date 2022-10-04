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

namespace P2P.WebApi.Controllers.MainData
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class FaqTitlesController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public FaqTitlesController(MainDataServices mainDataServices)
        {
            _mainDataServices = mainDataServices;
        }

        //GET: api/FaqTitle
        [HttpGet("{id}")]
        public async Task<ActionResult<FaqTitleODTO>> GetById(int id)
        {
            var faqTitle = await _mainDataServices.GetFaqTitleById(id);
            if (faqTitle == null) return NotFound();
            return faqTitle;
        }

        //GET: api/FaqTitle/ByReviewId
        [HttpGet("ByReviewId")]
        public async Task<ActionResult<IEnumerable<GetFaqTitleByReviewIdODTO>>> GetFaqTitleByReview(int reviewId)
        {
            var faqTitles = await _mainDataServices.GetFaqTitleByReviewId(reviewId);
            if (faqTitles == null) return NotFound();
            return faqTitles;
        }

        //GET: api/FaqTitle/ByPageId
        [HttpGet("ByPageId")]
        public async Task<ActionResult<IEnumerable<GetFaqTitleByPageIdODTO>>> GetFaqTitleByPage(int pageId)
        {
            var faqTitles = await _mainDataServices.GetFaqTitleByPageId(pageId);
            if (faqTitles == null) return NotFound();
            return faqTitles;
        }

        //GET: api/FaqTitle/ByBlogId
        [HttpGet("ByBlogId")]
        public async Task<ActionResult<IEnumerable<GetFaqTitleByBlogIdODTO>>> GetFaqTitleByBlog(int blogId)
        {
            var faqTitles = await _mainDataServices.GetFaqTitleByBlogId(blogId);
            if (faqTitles == null) return NotFound();
            return faqTitles;
        }

        //PUT: api/FaqTitle
        [HttpPut]
        public async Task<ActionResult<FaqTitleODTO>> PutFaqTitle(FaqTitleIDTO faqTitleIDTO)
        {
            try
            {
                return await _mainDataServices.EditFaqTitle(faqTitleIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/FaqTitle
        [HttpPost]
        public async Task<ActionResult<FaqTitleODTO>> PostFaqTitle(FaqTitleIDTO faqTitleIDTO)
        {
            try
            {
                return await _mainDataServices.AddFaqTitle(faqTitleIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/FaqTitle/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<FaqTitleODTO>> DeleteFaqTitle(int id)
        {
            try
            {
                var faqTitle = await _mainDataServices.DeleteFaqTitle(id);
                if (faqTitle == null) return NotFound();
                return faqTitle;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}