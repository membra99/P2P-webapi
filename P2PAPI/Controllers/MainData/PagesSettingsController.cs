using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2P.DTO.Input;
using P2P.DTO.Output;
using P2P.Services;
using System.Threading.Tasks;
using System;
using Entities.P2P.MainData;

namespace P2P.WebApi.Controllers.MainData
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class PagesSettingsController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public PagesSettingsController(MainDataServices mainServices)
        {
            _mainDataServices = mainServices;
        }

        //GET: api/PagesSettings
        [HttpGet("GetPagesSettingsById/{id}")]
        public async Task<ActionResult<PagesSettingsODTO>> GetById(int id)
        {
            var PagesSettings = await _mainDataServices.GetPagesSettingsById(id);
            if (PagesSettings == null)
            {
                return NotFound();
            }
            return PagesSettings;
        }

        //GET: api/PagesSettings
        [HttpGet("GetBonusSettingsByLangId/{langId}")]
        public async Task<ActionResult<PagesSettingsODTO>> GetBonusSettings(int langId)
        {
            var PagesSettings = await _mainDataServices.GetBonusSettingsByLangId(langId);
            if (PagesSettings == null)
            {
                return NotFound();
            }
            return PagesSettings;
        }

        //GET: api/PagesSettings
        [HttpGet("GetNewsSettingsByLangId/{langId}")]
        public async Task<ActionResult<PagesSettingsODTO>> GetNewsSettings(int langId)
        {
            var PagesSettings = await _mainDataServices.GetNewsSettingsByLangId(langId);
            if (PagesSettings == null)
            {
                return NotFound();
            }
            return PagesSettings;
        }

        //GET: api/PagesSettings
        [HttpGet("GetBlogsSettingsByLangId/{langId}")]
        public async Task<ActionResult<PagesSettingsODTO>> GetBlogsSettings(int langId)
        {
            var PagesSettings = await _mainDataServices.GetBlogSettingsByLangId(langId);
            if (PagesSettings == null)
            {
                return NotFound();
            }
            return PagesSettings;
        }

        //GET: api/PagesSettings
        [HttpGet("GetAcademySettingsByLangId/{langId}")]
        public async Task<ActionResult<PagesSettingsODTO>> GetAcademySettings(int langId)
        {
            var PagesSettings = await _mainDataServices.GetAcademySettingsByLangId(langId);
            if (PagesSettings == null)
            {
                return NotFound();
            }
            return PagesSettings;
        }

        //GET: api/PagesSettings
        [HttpGet("GetReviewSettingsByLangId/{langId}")]
        public async Task<ActionResult<PagesSettingsODTO>> GetReviewSettings(int langId)
        {
            var PagesSettings = await _mainDataServices.GetReviewSettingsByLangId(langId);
            if (PagesSettings == null)
            {
                return NotFound();
            }
            return PagesSettings;
        }

        //PUT: api/PagesSettings
        [HttpPut]
        public async Task<ActionResult<PagesSettingsODTO>> PutPagesSettings(PagesSettingsIDTO pagesSettingsIDTO)
        {
            try
            {
                return await _mainDataServices.EditPagesSettings(pagesSettingsIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/PagesSettings
        [HttpPost]
        public async Task<ActionResult<PagesSettingsODTO>> PostPagesSettings(PagesSettingsIDTO pagesSettingsIDTO)
        {
            try
            {
                return await _mainDataServices.AddPagesSettings(pagesSettingsIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/PagesSettings/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<PagesSettingsODTO>> DeletePagesSettings(int id)
        {
            try
            {
                var PagesSettings = await _mainDataServices.DeletePagesSettings(id);
                if (PagesSettings == null) return NotFound();
                return PagesSettings;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}