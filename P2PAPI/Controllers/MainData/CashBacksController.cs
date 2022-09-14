using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using P2P.DTO.Input;
using P2P.DTO.Output;
using P2P.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace P2P.WebApi.Controllers.MainData
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class CashBacksController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public CashBacksController(MainDataServices mainDataServices)
        {
            _mainDataServices = mainDataServices;
        }

        //GET: api/CashBack
        [HttpGet("{id}")]
        public async Task<ActionResult<CashBackODTO>> GetById(int id)
        {
            var cashback = await _mainDataServices.GetCashBackById(id);
            if(cashback == null) return NotFound();
            return cashback;
        }

        //GET: api/CashBack
        [HttpGet("ByLanguageId")]
        public async Task<ActionResult<IEnumerable<CashBackODTO>>> GetByLanguageId(int langId)
        {
            return await _mainDataServices.GetCashBackByLangId(langId);
        }


        //PUT: api/CashBack
        [HttpPut]
        public async Task<ActionResult<CashBackODTO>> PutFooterSettings(CashBackIDTO cashBackIDTO)
        {
            try
            {
                return await _mainDataServices.EditCashBack(cashBackIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        //POST: api/CashBack
        [HttpPost]
        public async Task<ActionResult<CashBackODTO>> PostFooterSettings(CashBackIDTO cashBackIDTO)
        {
            try
            {
                return await _mainDataServices.AddCashBack(cashBackIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/CashBack/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<CashBackODTO>> DeleteFooterSettings(int id)
        {
            try
            {
                var cashBack = await _mainDataServices.DeleteCashBack(id);
                if (cashBack == null) return NotFound();
                return cashBack;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
