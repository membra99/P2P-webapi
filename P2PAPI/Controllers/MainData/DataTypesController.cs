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
    public class DataTypesController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public DataTypesController(MainDataServices mainServices)
        {
            _mainDataServices = mainServices;
        }

        //GET: api/DataTypes
        [HttpGet("{id}")]
        public async Task<ActionResult<DataTypeODTO>> GetDataTypeById(int id)
        {
            var dataType = await _mainDataServices.GetDataTypeById(id);
            if (dataType == null)
            {
                return NotFound();
            }
            return dataType;
        }

        [HttpGet("GetAllDataTypes")]
        public async Task<ActionResult<IEnumerable<DataTypeODTO>>> GetAllDataTypes()
        {
            var dataType = await _mainDataServices.GetAllDataTypes();
            if (dataType == null)
            {
                return NotFound();
            }
            return dataType;
        }

        //PUT: api/DataTypes
        [HttpPut]
        public async Task<ActionResult<DataTypeODTO>> PutDataType(DataTypeIDTO dataTypeIDTO)
        {
            try
            {
                return await _mainDataServices.EditDataType(dataTypeIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/DataTypes
        [HttpPost]
        public async Task<ActionResult<DataTypeODTO>> PostDataType(DataTypeIDTO dataTypeIDTO)
        {
            try
            {
                return await _mainDataServices.AddDataType(dataTypeIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/DataTypes/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataTypeODTO>> DeleteDataType(int id)
        {
            try
            {
                var dataType = await _mainDataServices.DeleteDataType(id);
                if (dataType == null) return NotFound();
                return dataType;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}