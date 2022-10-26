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
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class AuthorsController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public AuthorsController(MainDataServices mainServices)
        {
            _mainDataServices = mainServices;
        }

        //GET: api/Language
        [HttpGet("GetAuthorById")]
        public async Task<ActionResult<AuthorODTO>> GetAuthorById(int id)
        {
            var author = await _mainDataServices.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            return author;
        }

        [HttpGet("GetAuthorsByLanguageId")]
        public async Task<ActionResult<IEnumerable<AuthorODTO>>> GetAuthorsByLanguageId(int langid)
        {
            var author = await _mainDataServices.GetAllAuthorsByLangID(langid);
            if (author == null)
            {
                return NotFound();
            }
            return author;
        }

        [HttpGet("GetAllAuthors")]
        public async Task<ActionResult<IEnumerable<AuthorODTO>>> GetAllAuthors()
        {
            var author = await _mainDataServices.GetAllAuthors();
            if (author == null)
            {
                return NotFound();
            }
            return author;
        }

        //PUT: api/Language
        [HttpPut]
        public async Task<ActionResult<AuthorODTO>> PutAuthor(AuthorIDTO authorIDTO)
        {
            try
            {
                return await _mainDataServices.EditAuthor(authorIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/Language
        [HttpPost]
        public async Task<ActionResult<AuthorODTO>> PostAuthor(AuthorIDTO authorIDTO)
        {
            try
            {
                return await _mainDataServices.AddAuthor(authorIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/Language/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<AuthorODTO>> DeleteAuthor(int id)
        {
            try
            {
                var author = await _mainDataServices.DeleteAuthor(id);
                if (author == null) return NotFound();
                return author;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}