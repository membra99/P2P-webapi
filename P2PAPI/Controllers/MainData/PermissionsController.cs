using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P2P.DTO.Input;
using P2P.DTO.Output;
using P2P.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace P2P.WebApi.Controllers.MainData
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class PermissionsController : ControllerBase
    {
        private readonly MainDataServices _mainDataServices;

        public PermissionsController(MainDataServices mainServices)
        {
            _mainDataServices = mainServices;
        }

        //GET: api/Permissions
        [HttpGet]
        public async Task<ActionResult<PermissionODTO>> GetById(int id)
        {
            var permissions = await _mainDataServices.GetPermissionsById(id);
            if (permissions == null) return NotFound();
            return permissions;
        }

        //GET: api/Permissions
        [HttpGet("ByLanguageId/{langId}")]
        public async Task<ActionResult<IEnumerable<PermissionODTO>>> GetByLanguageId(int langId)
        {
            return await _mainDataServices.GetPermissionsByLangId(langId);
        }

        //GET: api/Permissions
        [HttpGet("ByUserId/{userId}")]
        public async Task<ActionResult<IEnumerable<PermissionODTO>>> GetByUserId(int userId)
        {
            return await _mainDataServices.GetPermissionsByUserId(userId);
        }

        //GET: api/Permissions
        [HttpGet("ByRoleId/{roleId}")]
        public async Task<ActionResult<IEnumerable<PermissionODTO>>> GetByRoleId(int roleId)
        {
            return await _mainDataServices.GetPermissionsByRoleId(roleId);
        }

        //GET: api/Permissions
        [HttpGet("ByDataTypeId/{dataTypeId}")]
        public async Task<ActionResult<IEnumerable<PermissionODTO>>> GetByDataTypeId(int dataTypeId)
        {
            return await _mainDataServices.GetPermissionsByDataTypeId(dataTypeId);
        }


        //PUT: api/Permissions
        [HttpPut]
        public async Task<ActionResult<PermissionODTO>> PutPermissions(PermissionIDTO permissionsIDTO)
        {
            try
            {
                return await _mainDataServices.EditPermissions(permissionsIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //POST: api/Permissions
        [HttpPost]
        public async Task<ActionResult<PermissionODTO>> PostPermissions(PermissionIDTO permissionsIDTO)
        {
            try
            {
                return await _mainDataServices.AddPermissions(permissionsIDTO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //DELETE: api/Permissions/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<PermissionODTO>> DeletePermissions(int id)
        {
            try
            {
                var permission = await _mainDataServices.DeletePermissions(id);
                if (permission == null) return NotFound();
                return permission;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
