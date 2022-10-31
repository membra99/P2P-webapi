using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using P2P.Services;
using System.Threading.Tasks;
using Entities;

namespace P2P.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AWSS3FileController : ControllerBase
    {
        private readonly IAWSS3FileService _AWSS3FileService;
        public AWSS3FileController(IAWSS3FileService AWSS3FileService)
        {
            this._AWSS3FileService = AWSS3FileService;
        }
        [Route("uploadFile")]
        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadFileAsync([FromForm] AWSFileUpload files)
        {
            var result = await _AWSS3FileService.UploadFile(files);
            return Ok(new { isSucess = result });
        }
        [Route("filesList")]
        [HttpGet]
        public async Task<IActionResult> FilesListAsync()
        {
            var result = await _AWSS3FileService.FilesList();
            return Ok(result);
        }

        [Route("filesListSearch/{fileName}")]
        [HttpGet]
        public async Task<IActionResult> FilesListSearchAsync(string fileName)
        {
            var result = await _AWSS3FileService.FilesListSearch(fileName);
            return Ok(result);
        }
        [Route("getFile/{fileName}")]
        [HttpGet]
        public async Task<IActionResult> GetFile(string fileName)
        {
            try
            {
                var result = await _AWSS3FileService.GetFile(fileName);
                return File(result, "image/png");
            }
            catch
            {
                return Ok("NoFile");
            }

        }
        //[Route("updateFile")]
        //[HttpPut]
        //public async Task<IActionResult> UpdateFile(UploadFileName uploadFileName, string fileName)
        //{
        //    var result = await _AWSS3FileService.UpdateFile(uploadFileName, fileName);
        //    return Ok(new { isSucess = result });
        //}
        [Route("deleteFile/{fileName}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteFile(string fileName)
        {
            var result = await _AWSS3FileService.DeleteFile(fileName);
            return Ok(new { isSucess = result });
        }

        [Route("deleteMultipleFiles")]
        [HttpPost]
        public async Task<IActionResult> DeleteMultipleFiles(string[] fileNames)
        {
            var result = await _AWSS3FileService.DeleteMultipleFiles(fileNames);
            return Ok(new { isSucess = result });
        }
    }
}
