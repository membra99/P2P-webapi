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
    public class HomeSettingsController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public HomeSettingsController(MainDataServices mainServices)
        {
            _mainDataServices = mainServices;
        }

        //GET: api/HomeSettings
        [HttpGet]
        public async Task<ActionResult<HomeSettingsODTO>> GetById(int id)
        {
            var home = await _mainDataServices.GetHomeSettingsById(id);
            if (home == null) return NotFound();
            return home;
        }

        //GET: api/HomeSettings
        [HttpGet("ByLanguageId/{id}")]
        public async Task<ActionResult<IEnumerable<HomeSettingsODTO>>> GetByLanguageId(int id)
        {
            return await _mainDataServices.GetHomeSettingsByLangId(id);
        }

        //PUT: api/HomeSettings
        [HttpPut]
        public async Task<ActionResult<HomeSettingsODTO>> PutHomeSettings(HomeSettingsIDTO homeSettingsIDTO)
        {
            try
            {
                return await _mainDataServices.EditHomeSettings(homeSettingsIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/HomeSettings
        [HttpPost]
        public async Task<ActionResult<HomeSettingsODTO>> PostHomeSettings(HomeSettingsIDTO homeSettingsIDTO)
        {
            try
            {
                return await _mainDataServices.AddHomeSettings(homeSettingsIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/HomeSettings/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<HomeSettingsODTO>> DeleteHomeSettings(int id)
        {
            try
            {
                var homeSettings = await _mainDataServices.DeleteHomeSettings(id);
                if (homeSettings == null) return NotFound();
                return homeSettings;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}