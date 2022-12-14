using Microsoft.AspNetCore.Cors;
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
            var url = await _mainDataServices.GetUrlTableById(id);
            if (url == null) return NotFound();
            return url;
        }

        //GET: api/UrlTables
        [HttpGet("ByDataTypeId")]
        public async Task<ActionResult<IEnumerable<UrlTableODTO>>> GetByDataTypeId(int dataTypeId)
        {
            return await _mainDataServices.GetUrlTableByDataTypeId(dataTypeId);
        }

        //GET: api/UrlTables
        [HttpGet("GetUrlTableByDataTypeIdAndLang")]
        public async Task<ActionResult<IEnumerable<GetUrlTableByDataTypeIdAndLangODTO>>> GetUrlTableByDataTypeIdAndLang(int dataTypeId, int langId)
        {
            var url = await _mainDataServices.GetUrlTableByDataTypeIdAndLang(dataTypeId, langId);
            if (url == null) return NotFound();
            return url;
        }

        //GET: api/UrlTables
        [HttpGet("GetUrl")]
        public async Task<ActionResult<IEnumerable<GetUrlODTO>>> GetUrl(string urlLink)
        {
            var url = await _mainDataServices.GetUrl(urlLink);
            if (url == null) return NotFound();
            return url;
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