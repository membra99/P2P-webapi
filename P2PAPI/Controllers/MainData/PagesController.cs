using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2P.DTO.Input;
using P2P.DTO.Output;
using P2P.Services;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using P2P.DTO.Output.EndPointODTO;
using P2P.DTO.Input.EndpointIDTO;

namespace P2P.WebApi.Controllers.MainData
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class PagesController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public PagesController(MainDataServices mainDataServices)
        {
            _mainDataServices = mainDataServices;
        }

        //GET: api/Page
        [HttpGet("{id}")]
        public async Task<ActionResult<PageODTO>> GetById(int id)
        {
            var page = await _mainDataServices.GetPageById(id);
            if (page == null) return NotFound();
            return page;
        }

        [HttpGet("ByLanguageId/{langId}")]
        public async Task<ActionResult<IEnumerable<PageODTO>>> GetPagesByLanguageId(int langId)
        {
            var page = await _mainDataServices.GetPageByLanguageId(langId);
            if (page == null) return NotFound();
            return page;
        }

        [HttpGet("ByDataTypeId/{dataTypeId}")]
        public async Task<ActionResult<IEnumerable<PageODTO>>> GetPagesByDataTypeId(int dataTypeId)
        {
            var page = await _mainDataServices.GetPageByDataTypeId(dataTypeId);
            if (page == null) return NotFound();
            return page;
        }

        [HttpGet("CryptoBySymbol/{symbol}")]
        public async Task<ActionResult<CryptoODTO>> GetCryptoSymbol(string symbol)
        {
            var Crypto = await _mainDataServices.GetCryptoBySymbol(symbol);
            if (Crypto == null) return NotFound();
            return Crypto;
        }

        [HttpGet("GetList/{langId}")]
        public async Task<ActionResult<IEnumerable<GetPageListODTO>>> GetList(int langId)
        {
            var page = await _mainDataServices.GetList(langId);
            if (page == null) return NotFound();
            return page;
        }

        [HttpGet("GetPage/{Id}")]
        public async Task<ActionResult<GetPageODTO>> GetItem(int Id)
        {
            var page = await _mainDataServices.GetItem(Id);
            if (page == null) return NotFound();
            return page;
        }
        [HttpGet("GetCrypto")]
        public async Task<ActionResult<IEnumerable<CryptoODTO>>> GetCripto()
        {
            var crypto = await _mainDataServices.GetCryptos();
            return crypto;
        }

        [HttpGet("GetCryptoSymbol&Name")]
        public async Task<ActionResult<IEnumerable<SymbolODTO>>> GetCryptoSymbol()
        {
            var crypto = await _mainDataServices.GetSymoblAndName();
            return crypto;
        }

        [HttpGet("GetItemContent")]
        public async Task<ActionResult<GetItemContentODTO>> GetItemContent(int? id, int urlId, int langId)
        {
            var page = await _mainDataServices.GetItemContent(id, urlId, langId);
            //if (page == null) return NotFound();
            return page;
        }

        [HttpGet("GetPageContent")]
        public async Task<ActionResult<PageContentODTO>> GetPageContent(int langId, int url, int dataType)
        {
            var page = await _mainDataServices.GetPageContent(langId, url, dataType);
            if (page == null) return NotFound();
            return page;
        }

        //PUT: api/Page
        [HttpPut]
        public async Task<ActionResult<PageODTO>> PutPage(PageIDTO pageIDTO)
        {
            try
            {
                return await _mainDataServices.EditPage(pageIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/Page
        [HttpPost]
        public async Task<ActionResult<PageODTO>> PostPage(PageIDTO pageIDTO)
        {
            try
            {
                return await _mainDataServices.AddPage(pageIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //PUT: api/Page
        [HttpPut("Content")]
        public async Task<ActionResult<PageODTO>> PostPageContent(PutContentIDTO contentIDTO)
        {
            try
            {
                return await _mainDataServices.EditPageContent(contentIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/Page/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<PageODTO>> DeletePage(int id)
        {
            try
            {
                var page = await _mainDataServices.DeletePage(id);
                if (page == null) return NotFound();
                return page;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}