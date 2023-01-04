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
    public class FooterSettingsController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public FooterSettingsController(MainDataServices mainDataServices)
        {
            _mainDataServices = mainDataServices;
        }

        //GET: api/FooterSettings
        [HttpGet("{id}")]
        public async Task<ActionResult<FooterSettingsODTO>> GetById(int id)
        {
            var footer = await _mainDataServices.GetFooterSettingsById(id);
            if (footer == null) return NotFound();
            return footer;
        }

        //GET: api/FooterSettings
        [HttpGet("ByLanguageId")]
        public async Task<ActionResult<IEnumerable<FooterSettingsODTO>>> GetByLanguageId(int id, string UseCase)
        {
            return await _mainDataServices.GetFooterSettingsByLangId(id, UseCase);
        }

        //PUT: api/FooterSettings
        [HttpPut]
        public async Task<ActionResult<FooterSettingsODTO>> PutFooterSettings(FooterSettingsIDTO footerSettingsIDTO)
        {
            try
            {
                return await _mainDataServices.EditFooterSettings(footerSettingsIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/FooterSettings
        [HttpPost]
        public async Task<ActionResult<FooterSettingsODTO>> PostFooterSettings(FooterSettingsIDTO footerSettingsIDTO)
        {
            try
            {
                return await _mainDataServices.AddFooterSettings(footerSettingsIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/FooterSettings/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<FooterSettingsODTO>> DeleteFooterSettings(int id)
        {
            try
            {
                var navigationSettings = await _mainDataServices.DeleteFooterSettings(id);
                if (navigationSettings == null) return NotFound();
                return navigationSettings;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}