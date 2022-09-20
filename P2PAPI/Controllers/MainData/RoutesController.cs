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

namespace P2P.WebApi.Controllers.MainData
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class RoutesController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public RoutesController(MainDataServices mainServices)
        {
            _mainDataServices = mainServices;
        }

        //GET: api/Routes
        [HttpGet("AllRoutes")]
        public async Task<ActionResult<IEnumerable<RoutesODTO>>> GetAllRoutes()
        {
            return await _mainDataServices.GetAllRoutes();
        }

        //GET: api/Routes
        [HttpGet("ByRouteId/{id}")]
        public async Task<ActionResult<RoutesODTO>> GetRoutesById(int id)
        {
            var routes = await _mainDataServices.GetRoutesById(id);
            if (routes == null)
            {
                return NotFound();
            }
            return routes;
        }

        //GET: api/Routes
        [HttpGet("ByLanguageId/{langId}")]
        public async Task<ActionResult<IEnumerable<RoutesODTO>>> GetAllRoutesByLanguageId(int langId)
        {
            var routes = await _mainDataServices.GetRoutesByLanguageId(langId);
            if (routes == null)
            {
                return NotFound();
            }
            return routes;
        }

        [HttpGet("DropdownValues/{key}")]
        public async Task<ActionResult<IEnumerable<GetDropdownValuesODTO>>> GetDropdownValues(string key)
        {
            var routes = await _mainDataServices.GetDropdownValues(key);
            if (routes == null)
            {
                return NotFound();
            }
            return routes;
        }

        //PUT: api/Routes
        [HttpPut]
        public async Task<ActionResult<RoutesODTO>> PutRoute(RoutesIDTO routesIDTO)
        {
            try
            {
                return await _mainDataServices.EditRoute(routesIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/Routes
        [HttpPost]
        public async Task<ActionResult<RoutesODTO>> PostRoute(RoutesIDTO routesIDTO)
        {
            try
            {
                return await _mainDataServices.AddRoute(routesIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/Routes/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoutesODTO>> DeleteRoute(int id)
        {
            try
            {
                var routes = await _mainDataServices.DeleteRoute(id);
                if (routes == null) return NotFound();
                return routes;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}