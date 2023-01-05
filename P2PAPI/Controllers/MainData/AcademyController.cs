using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2P.DTO.Input;
using P2P.DTO.Output;
using P2P.Services;
using System.Threading.Tasks;
using System;
using System.Collections;
using P2P.DTO.Output.EndPointODTO;
using System.Collections.Generic;

namespace P2P.WebApi.Controllers.MainData
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class AcademyController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public AcademyController(MainDataServices mainServices)
        {
            _mainDataServices = mainServices;
        }

        //GET: api/Academy
        [HttpGet("{id}")]
        public async Task<ActionResult<AcademyODTO>> GetById(int id)
        {
            var academy = await _mainDataServices.GetAcademyById(id);
            if (academy == null)
            {
                return NotFound();
            }
            return academy;
        }

        //GET: api/Academy
        [HttpGet("GetAcademyValueByLangId")]
        public async Task<ActionResult<IEnumerable<PopularArticlesODTO>>> GetAcademyValueByLangId(int langId)
        {
            var academy = await _mainDataServices.GetAcademyValueByLangId(langId);
            if (academy == null)
            {
                return NotFound();
            }
            return academy;
        }

        //GET: api/Academy
        [HttpGet("GetAcademy/{langId}")]
        public async Task<ActionResult<IEnumerable<AcademyODTO>>> GetAcademyByLangId(int langId)
        {
            var academy = await _mainDataServices.GetAcademyByLangId(langId);
            if (academy == null)
            {
                return NotFound();
            }
            return academy;
        }

        //GET: api/Academy
        [HttpGet("GetList/")]
        public async Task<ActionResult<IEnumerable<AcademyODTO>>> GetList(int langId, string tag)
        {
            var academy = await _mainDataServices.GetListByLangOrTag(langId, tag);
            if (academy == null)
            {
                return NotFound();
            }
            return academy;
        }

        [HttpGet("Full{id}")]
        public async Task<ActionResult<AcademyODTO>> GetByIdFull(int id)
        {
            var academy = await _mainDataServices.GetAcademyFull(id);
            if (academy == null)
            {
                return NotFound();
            }
            return academy;
        }

        [HttpGet("GetAcademyFull/{langId}")]
        public async Task<ActionResult<IEnumerable<AcademyODTO>>> GetFullAcademyByLanguageID(int langId)
        {
            var academy = await _mainDataServices.GetAcademyByLangIdFull(langId);
            if (academy == null)
            {
                return NotFound();
            }
            return academy;
        }

        //PUT: api/Academy
        [HttpPut]
        public async Task<ActionResult<AcademyODTO>> PutAcademy(AcademyIDTO academyIDTO)
        {
            try
            {
                return await _mainDataServices.EditAcademy(academyIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/Academy
        [HttpPost]
        public async Task<ActionResult<AcademyODTO>> PostAcademy(AcademyIDTO academyIDTO)
        {
            try
            {
                return await _mainDataServices.AddAcademy(academyIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/Academy/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<AcademyODTO>> DeleteAcademy(int id)
        {
            try
            {
                var academy = await _mainDataServices.DeleteAcademy(id);
                if (academy == null) return NotFound();
                return academy;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}