using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using P2P.DTO.Input;
using P2P.DTO.Output;
using P2P.Services;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using P2P.DTO.Output.EndPointODTO;

namespace P2P.WebApi.Controllers.MainData
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class NavigationSettingsController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public NavigationSettingsController(MainDataServices mainServices)
        {
            _mainDataServices = mainServices;
        }

        //GET: api/NavigationSettings
        [HttpGet("ByLanguageId/{id}")]
        public async Task<ActionResult<IEnumerable<NavigationSettingsByLanguageODTO>>> GetByLanguageId(int id)
        {
            return await _mainDataServices.GetNavigationSettingsByLangId(id);
        }

        //GET: api/NavigationSettings
        [HttpGet("ById/{id}")]
        public async Task<ActionResult<NavigationSettingsODTO>> GetById(int id)
        {
            return await _mainDataServices.GetNavigationSettingsById(id);
        }

        //PUT: api/NavigationSettings
        [HttpPut]
        public async Task<ActionResult<NavigationSettingsODTO>> PutNavigationSettings(NavigationSettingsIDTO navigationSettingsIDTO)
        {
            try
            {
                return await _mainDataServices.EditNavigationSettings(navigationSettingsIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/NavigationSettings
        [HttpPost]
        public async Task<ActionResult<NavigationSettingsODTO>> PostNavigationSettings(NavigationSettingsIDTO navigationSettingsIDTO)
        {
            try
            {
                return await _mainDataServices.AddNavigationSettings(navigationSettingsIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/NavigationSettings/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<NavigationSettingsODTO>> DeleteNavigationSettings(int id)
        {
            try
            {
                var navigationSettings = await _mainDataServices.DeleteNavigationSettings(id);
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