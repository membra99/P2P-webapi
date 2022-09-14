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
    public class UrlTablesController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public UrlTablesController(MainDataServices mainServices)
        {
            _mainDataServices = mainServices;
        }

        //GET: api/UrlTables
        [HttpGet("{id}")]
        public async Task<ActionResult<UrlTableODTO>> GetById(int id)
        {
            return await _mainDataServices.GetUrlTableById(id);
        }

        //GET: api/UrlTables
        [HttpGet("ByDataTypeId")]
        public async Task<ActionResult<IEnumerable<UrlTableODTO>>> GetByDataTypeId(int dataTypeId)
        {
            return await _mainDataServices.GetUrlTableByDataTypeId(dataTypeId);
        }


        //PUT: api/UrlTables
        [HttpPut]
        public async Task<ActionResult<UrlTableODTO>> PutUrlTable(UrlTableIDTO urlTableIDTO)
        {
            try
            {
                return await _mainDataServices.EditUrlTable(urlTableIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        //POST: api/UrlTables
        [HttpPost]
        public async Task<ActionResult<UrlTableODTO>> PostUrlTable(UrlTableIDTO urlTableIDTO)
        {
            try
            {
                return await _mainDataServices.AddUrlTable(urlTableIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/UrlTables/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<UrlTableODTO>> DeleteUrlTable(int id)
        {
            try
            {
                var urlTablel = await _mainDataServices.DeleteUrlTable(id);
                if (urlTablel == null) return NotFound();
                return urlTablel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}
