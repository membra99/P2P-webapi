using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2P.DTO.Input;
using P2P.DTO.Output;
using P2P.Services;
using System.Threading.Tasks;
using System;

namespace P2P.WebApi.Controllers.MainData
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]

    public class FaqListsController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public FaqListsController(MainDataServices mainDataServices)
        {
            _mainDataServices = mainDataServices;
        }

        //GET: api/FaqList
        [HttpGet("{id}")]
        public async Task<ActionResult<FaqListODTO>> GetById(int id)
        {
            var faqList = await _mainDataServices.GetFaqListById(id);
            if (faqList == null) return NotFound();
            return faqList;
        }

        //PUT: api/FaqList
        [HttpPut]
        public async Task<ActionResult<FaqListODTO>> PutFaqList(FaqListIDTO faqListIDTO)
        {
            try
            {
                return await _mainDataServices.EditFaqList(faqListIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        //POST: api/FaqList
        [HttpPost]
        public async Task<ActionResult<FaqListODTO>> PostFaqList(FaqListIDTO faqListIDTO)
        {
            try
            {
                return await _mainDataServices.AddFaqList(faqListIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/FaqList/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<FaqListODTO>> DeleteFaqList(int id)
        {
            try
            {
                var faqList = await _mainDataServices.DeleteFaqList(id);
                if (faqList == null) return NotFound();
                return faqList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
