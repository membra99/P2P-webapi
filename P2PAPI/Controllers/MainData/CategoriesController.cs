using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2P.DTO.Input;
using P2P.DTO.Output;
using P2P.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using P2P.DTO.Output.EndPointODTO;

namespace P2P.WebApi.Controllers.MainData
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class CategoriesController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public CategoriesController(MainDataServices mainDataServices)
        {
            _mainDataServices = mainDataServices;
        }

        //GET: api/Categories
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryODTO>> GetById(int id)
        {
            var category = await _mainDataServices.GetCategoryById(id);
            if (category == null) return NotFound();
            return category;
        }

        //GET: api/Categories/ByLanguageId
        [HttpGet("ByLanguageId")]
        public async Task<ActionResult<List<CategoryODTO>>> GetByLanguageId(int languageId)
        {
            var category = await _mainDataServices.GetCategoriesByLanguageId(languageId);
            if (category == null) return NotFound();
            return category;
        }

        //PUT: api/Categories
        [HttpPut]
        public async Task<ActionResult<CategoryODTO>> PutCategory(CategoryIDTO categoryIDTO)
        {
            try
            {
                return await _mainDataServices.EditCategory(categoryIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/Categories
        [HttpPost]
        public async Task<ActionResult<CategoryODTO>> PostCategory(CategoryIDTO categoryIDTO)
        {
            try
            {
                return await _mainDataServices.AddCategory(categoryIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/Categories/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<CategoryODTO>> DeleteCategory(int id)
        {
            try
            {
                var category = await _mainDataServices.DeleteCategory(id);
                if (category == null) return NotFound();
                return category;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
