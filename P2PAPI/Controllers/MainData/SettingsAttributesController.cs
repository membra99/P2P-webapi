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
    public class SettingsAttributesController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public SettingsAttributesController(MainDataServices mainServices)
        {
            _mainDataServices = mainServices;
        }

        //GET: api/SettingsAttributes
        [HttpGet]
        public async Task<ActionResult<SettingsAttributeODTO>> GetById(int id)
        {
            var settingsAttribute = await _mainDataServices.GetSettingsAttributeById(id);
            if (settingsAttribute == null) return NotFound();
            return settingsAttribute;
        }

        //GET: api/SettingsAttributes
        [HttpGet("ByLanguageId/{langId}")]
        public async Task<ActionResult<IEnumerable<SettingsAttributeODTO>>> GetByLanguageId(int langId)
        {
            return await _mainDataServices.GetSettingsAttributeByLangId(langId);
        }

        //GET: api/SettingsAttributes
        [HttpGet("ByDataTypeId/{dataTypeId}")]
        public async Task<ActionResult<IEnumerable<SettingsAttributeODTO>>> GetByDataTypeId(int dataTypeId)
        {
            return await _mainDataServices.GetSettingsAttributeByDataTypeId(dataTypeId);
        }

        //PUT: api/SettingsAttributes
        [HttpPut]
        public async Task<ActionResult<IEnumerable<SettingsAttributeODTO>>> PutSettingsAttributes(List<SettingsAttributeIDTO> settingsAttributeIDTO)
        {
            try
            {
                return await _mainDataServices.EditSettingsAttribute(settingsAttributeIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/SettingsAttributes
        [HttpPost]
        public async Task<ActionResult<IEnumerable<SettingsAttributeODTO>>> PostSettingsAttribute(List<SettingsAttributeIDTO> settingsAttributeIDTO)
        {
            try
            {
                return await _mainDataServices.AddSettingsAttribute(settingsAttributeIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/SettingsAttributes/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<SettingsAttributeODTO>> DeleteSettingsAttribute(int id)
        {
            try
            {
                var settingsAttribute = await _mainDataServices.DeleteSettingsAttribute(id);
                if (settingsAttribute == null) return NotFound();
                return settingsAttribute;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}