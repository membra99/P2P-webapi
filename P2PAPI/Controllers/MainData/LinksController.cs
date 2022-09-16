using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2P.DTO.Input;
using P2P.DTO.Output;
using P2P.Services;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;

namespace P2P.WebApi.Controllers.MainData
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class LinksController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public LinksController(MainDataServices mainServices)
        {
            _mainDataServices = mainServices;
        }

        //GET: api/Link
        [HttpGet("{id}")]
        public async Task<ActionResult<LinkODTO>> GetById(int id)
        {
            var link = await _mainDataServices.GetLinkById(id);
            if(link == null) return NotFound();
            return link;
        }

        //GET: api/Link
        [HttpGet("ByKeyAndLanguageId")]
        public async Task<ActionResult<IEnumerable<LinkODTO>>> GetByKeyAndLanguageId(string key, int langId)
        {
            var link = await _mainDataServices.GetLinkByKeyAndLang(key,langId);
            if (link == null) return NotFound();
            return link;
        }

        //PUT: api/Link
        [HttpPut]
        public async Task<ActionResult<LinkODTO>> PutLinks(LinkIDTO LinkIDTO)
        {
            try
            {
                return await _mainDataServices.EditLink(LinkIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/Link
        [HttpPost]
        public async Task<ActionResult<LinkODTO>> PostLink(LinkIDTO LinkIDTO)
        {
            try
            {
                return await _mainDataServices.AddLink(LinkIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/Link/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<LinkODTO>> DeleteLink(int id)
        {
            try
            {
                var links = await _mainDataServices.DeleteLink(id);
                if (links == null) return NotFound();
                return links;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}