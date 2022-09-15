using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2P.DTO.Input;
using P2P.DTO.Output;
using P2P.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

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

        //GET: api/FaqTitle
        [HttpGet("ByPageId/{id}")]
        public async Task<ActionResult<IEnumerable<FaqTitleODTO>>> GetByPageId(int id)
        {
            var faqTitles = await _mainDataServices.GetFaqTitleByPageId(id);
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
