using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2P.DTO.Input;
using P2P.DTO.Output;
using P2P.Services;
using System.Threading.Tasks;
using System;

namespace P2P.WebApi.Controllers.MainData
{
    [Route("[controller]")]
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