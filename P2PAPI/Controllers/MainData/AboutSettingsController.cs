using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2P.DTO.Input;
using P2P.DTO.Output;
using P2P.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Entities.P2P.MainData.Settings;

namespace P2P.WebApi.Controllers.MainData
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class AboutSettingsController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public AboutSettingsController(MainDataServices mainServices)
        {
            _mainDataServices = mainServices;
        }

        //GET: api/AboutSettings
        [HttpGet]
        public async Task<ActionResult<AboutSettingsODTO>> GetById(int id)
        {
            var about = await _mainDataServices.GetAboutSettingsById(id);
            if (about == null) return NotFound();
            return about;
        }

        //GET: api/AboutSettings
        [HttpGet("ByLanguageId/{id}")]
        public async Task<ActionResult<IEnumerable<AboutSettingsODTO>>> GetByLanguageId(int id)
        {
            return await _mainDataServices.GetAboutSettingsByLangId(id);
        }

        //PUT: api/AboutSettings
        [HttpPut]
        public async Task<ActionResult<AboutSettingsODTO>> PutHomeSettings(AboutSettingsIDTO aboutSettingsIDTO)
        {
            try
            {
                return await _mainDataServices.EditAboutSettings(aboutSettingsIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/AboutSettings
        [HttpPost]
        public async Task<ActionResult<AboutSettingsODTO>> PostAboutSettings(AboutSettingsIDTO aboutSettingsIDTO)
        {
            try
            {
                return await _mainDataServices.AddAboutSettings(aboutSettingsIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/AboutSettings/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<AboutSettingsODTO>> DeleteAboutSettings(int id)
        {
            try
            {
                var aboutSettings = await _mainDataServices.DeleteAboutSettings(id);
                if (aboutSettings == null) return NotFound();
                return aboutSettings;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}