using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2P.DTO.Input;
using P2P.DTO.Output;
using P2P.Services;
using System.Threading.Tasks;
using System;
using System.Collections;
using P2P.DTO.Output.EndPointODTO;
using System.Collections.Generic;

namespace P2P.WebApi.Controllers.MainData
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ReviewController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public ReviewController(MainDataServices mainServices)
        {
            _mainDataServices = mainServices;
        }

        //GET: api/Review
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewODTO>> GetById(int id)
        {
            var review = await _mainDataServices.GetReviewById(id);
            if (review == null)
            {
                return NotFound();
            }
            return review;
        }

        //GET: api/Review
        [HttpGet("GetReviewByRoute")]
        public async Task<ActionResult<GetReviewsByRouteODTO>> GetReviewByRoute(string url, int langId)
        {
            var review = await _mainDataServices.GetReviewsByRoute(url, langId);
            if (review == null)
            {
                return NotFound();
            }
            return review;
        }

        //GET: api/Review
        [HttpGet("GetListOfReview")]
        public async Task<ActionResult<IEnumerable<ReviewContentDropdownODTO>>> GetListOfReviews()
        {
            var review = await _mainDataServices.GetListOfReviews();
            if (review == null)
            {
                return NotFound();
            }
            return review;
        }

        //GET: api/Review
        [HttpGet("GetListOfReviewByLangId/{langId}")]
        public async Task<ActionResult<IEnumerable<ReviewContentDropdownODTO>>> GetListOfReviewByLangId(int langId)
        {
            var review = await _mainDataServices.GetListOfReviewsByLang(langId);
            if (review == null)
            {
                return NotFound();
            }
            return review;
        }

        //GET: api/Review
        [HttpGet("GetparentReview/{langId}")]
        public async Task<ActionResult<IEnumerable<GetParentReviewODTO>>> GetparentReview(int langId)
        {
            var review = await _mainDataServices.GetParentReview(langId);
            if (review == null)
            {
                return NotFound();
            }
            return review;
        }

        //GET: api/Review
        [HttpGet("GetReviewBoxInfo/{Id}")]
        public async Task<ActionResult<GetCampaignBonusODTO>> GetReviewBoxInfo(int Id)
        {
            var review = await _mainDataServices.GetReviewBoxInfo(Id);
            if (review == null)
            {
                return NotFound();
            }
            return review;
        }

        //POST: api/Review
        [HttpPost("AddCount/{name}")]
        public async Task<ActionResult> AddCount(string name)

        {
            await _mainDataServices.AddCount(name);
            return Ok();
        }

        //PUT: api/Review
        [HttpPut]
        public async Task<ActionResult<ReviewODTO>> PutReview(ReviewIDTO reviewIDTO)
        {
            try
            {
                return await _mainDataServices.EditReview(reviewIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/Review
        [HttpPost]
        public async Task<ActionResult<ReviewODTO>> PostReview(ReviewIDTO reviewIDTO)
        {
            try
            {
                return await _mainDataServices.AddReview(reviewIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/Language/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReviewODTO>> DeleteReview(int id)
        {
            try
            {
                var review = await _mainDataServices.DeleteReview(id);
                if (review == null) return NotFound();
                return review;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}