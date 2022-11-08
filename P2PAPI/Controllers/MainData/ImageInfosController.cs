using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2P.DTO.Input;
using P2P.DTO.Output;
using P2P.Services;
using System.Threading.Tasks;
using System;
using RTools_NTS.Util;
using System.Collections;
using System.Collections.Generic;

namespace P2P.WebApi.Controllers.MainData
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ImageInfosController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public ImageInfosController(MainDataServices mainServices)
        {
            _mainDataServices = mainServices;
        }

        //GET: api/Language
        [HttpGet("GetImageInfoByAWSUrl")]
        public async Task<ActionResult<ImagesInfoODTO>> GetImageInfoByAWSUrl(string aws)
        {
            var image = await _mainDataServices.GetImageInfoByAWS(aws);
            if (image == null)
            {
                return NotFound();
            }
            return image;
        }

        //PUT: api/Language
        [HttpPut]
        public async Task<ActionResult<ImagesInfoODTO>> PutImageInfo(ImagesInfoIDTO imageIDTO)
        {
            try
            {
                return await _mainDataServices.EditImageInfo(imageIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/Language
        [HttpPost]
        public async Task<ActionResult<ImagesInfoODTO>> PostImageInfo(ImagesInfoIDTO imageIDTO)
        {
            try
            {
                return await _mainDataServices.AddImageInfo(imageIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/Language/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<ImagesInfoODTO>> DeleteImageInfo(int id)
        {
            try
            {
                var image = await _mainDataServices.DeleteImageInfo(id);
                if (image == null) return NotFound();
                return image;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("DeleteImages")]
        public async Task<ActionResult<IEnumerable<ImagesInfoODTO>>> DeleteImageInfo(List<ImagesInfoIDTO> imagesInfoIDTO)
        {
            try
            {
                var image = await _mainDataServices.DeleteImagesInfo(imagesInfoIDTO);
                if (image == null) return NotFound();
                return image;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}