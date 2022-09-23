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
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class SerpsController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public SerpsController(MainDataServices mainServices)
        {
            _mainDataServices = mainServices;
        }

        //GET: api/Serp
        [HttpGet("{id}")]
        public async Task<ActionResult<SerpODTO>> GetById(int id)
        {
            var serp = await _mainDataServices.GetSerpById(id);
            if (serp == null) return NotFound();
            return serp;
        }

        //GET: api/Serp
        [HttpGet("ByDataTypeId")]
        public async Task<ActionResult<IEnumerable<SerpODTO>>> GetByDataTypeId(int dataTypeId)
        {
            return await _mainDataServices.GetByDataTypeId(dataTypeId);
        }

        //PUT: api/Serp
        [HttpPut]
        public async Task<ActionResult<SerpODTO>> PutSerp(SerpIDTO serpIDTO)
        {
            try
            {
                return await _mainDataServices.EditSerp(serpIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/Serp
        [HttpPost]
        public async Task<ActionResult<SerpODTO>> PostSerp(SerpIDTO serpIDTO)
        {
            try
            {
                return await _mainDataServices.AddSerp(serpIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/Serp/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<SerpODTO>> DeleteSerp(int id)
        {
            try
            {
                var serp = await _mainDataServices.DeleteSerp(id);
                if (serp == null) return NotFound();
                return serp;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}