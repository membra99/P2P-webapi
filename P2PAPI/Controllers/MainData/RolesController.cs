using Microsoft.AspNetCore.Cors;
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
        public class RolesController : ControllerBase
        {
            private readonly MainDataServices _mainDataServices;

            public RolesController(MainDataServices mainServices)
            {
                _mainDataServices = mainServices;
            }

            //GET: api/Roles
            [HttpGet("{id}")]
            public async Task<ActionResult<RoleODTO>> GetById(int id)
            {
                var role = await _mainDataServices.GetRoleById(id);
                if (role == null)
                {
                    return NotFound();
                }
                return role;
            }

        //GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<List<RoleODTO>>> GetRoles()
        {
            var role = await _mainDataServices.GetAllRoles();
            if (role == null)
            {
                return NotFound();
            }
            return role;
        }

        //PUT: api/Roles
        [HttpPut]
            public async Task<ActionResult<RoleODTO>> PutRole(RoleIDTO roleIDTO)
            {
                try
                {
                    return await _mainDataServices.EditRole(roleIDTO);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

            //POST: api/Roles
            [HttpPost]
            public async Task<ActionResult<RoleODTO>> PostRole(RoleIDTO roleIDTO)
            {
                try
                {
                    return await _mainDataServices.AddRole(roleIDTO);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

            //DELETE: api/Roles/1
            [HttpDelete("{id}")]
            public async Task<ActionResult<RoleODTO>> DeleteRole(int id)
            {
                try
                {
                    var role = await _mainDataServices.DeleteRole(id);
                    if (role == null) return NotFound();
                    return role;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

    }
