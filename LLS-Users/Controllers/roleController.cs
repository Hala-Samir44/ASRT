using LLS.BLL.Services;
using LLS.CommonDefinitions.Dto;
using LLS.CommonDefinitions.Model;
using LLS.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LLS_Users.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class roleController : ControllerBase
    {
        public roleService roleService { get; set; }
        public roleController(roleService roleService)
        {
            this.roleService = roleService;
        }
        [HttpGet]
        public async Task<GenericResult<List<Role>>> GetAllRoles(Role role = null)
        {
            var result = await roleService.GetAllRoles(role);
            return result;
        }
        [HttpGet]
        public GenericResult<RoleDto> GetRoleWithPermissions(string id)
        {
            var result =  roleService.GetRoleWithPermissions(id);
            return result;
        }



        [HttpPost]
        public async Task<GenericResult<string>> Create(RoleDto role)
        {
            var result = await roleService.Create(role);
            return result;
        }

        [HttpPost]
        public async Task<GenericResult<Role>> Edit(RoleDto role)
        {
            var result = await roleService.Edit(role);
            return result;
        }
        [HttpPost]
        public async Task<GenericResult<bool>> Delete(string roleId)
        {
            var result = await roleService.Delete(roleId);
            return result;
        }


    }
}