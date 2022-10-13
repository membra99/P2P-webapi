using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using P2P.DTO.Input;
using P2P.DTO.Output;
using P2P.Services;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;

namespace P2P.WebApi.Controllers.MainData
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ReviewAttributesController : Controller
    {
        private readonly MainDataServices _mainDataServices;

        public ReviewAttributesController(MainDataServices mainServices)
        {
            _mainDataServices = mainServices;
        }

        //GET: api/ReviewAttribute
        [HttpGet]
        public async Task<ActionResult<ReviewAttributeODTO>> GetById(int id)
        {
            var review = await _mainDataServices.GetReviewAttribute(id);
            if (review == null) return NotFound();
            return review;
        }

        //GET: api/ReviewAttribute
        [HttpGet("GetReviewAttributeByReviewID/{ReviewId}")]
        public async Task<ActionResult<IEnumerable<ReviewAttributeODTO>>> GetReviewAttributeByReviewID(int ReviewId)
        {
            var review = await _mainDataServices.GetReviewAttributeByReviewID(ReviewId);
            if (review == null) return NotFound();
            return review;
        }

        //PUT: api/ReviewAttribute
        [HttpPut]
        public async Task<ActionResult<ReviewAttributeODTO>> PutReviewAttribute(ReviewAttributeIDTO reviewAttributeIDTO)
        {
            try
            {
                return await _mainDataServices.EditReviewAttribute(reviewAttributeIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/ReviewAttribute
        [HttpPost]
        public async Task<ActionResult<ReviewAttributeODTO>> PostReviewAttribute(ReviewAttributeIDTO reviewAttributeIDTO)
        {
            try
            {
                return await _mainDataServices.AddReviewAttribute(reviewAttributeIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/ReviewAttribute
        [HttpPost("PostReviewAttributes")]
        public async Task<ActionResult<IEnumerable<ReviewAttributeODTO>>> PostReviewAttributes(List<ReviewAttributeIDTO> reviewAttributeIDTO)
        {
            try
            {
                return await _mainDataServices.AddReviewAttributes(reviewAttributeIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/ReviewAttribute/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReviewAttributeODTO>> DeleteReviewAttribute(int id)
        {
            try
            {
                var language = await _mainDataServices.DeleteReviewAttribute(id);
                if (language == null) return NotFound();
                return language;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}