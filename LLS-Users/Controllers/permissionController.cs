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
    public class permissionController : ControllerBase
    {
        public permissionService permissionService { get; set; }
        public permissionController(permissionService permissionService)
        {
            this.permissionService = permissionService;
        }
        [HttpGet]
        public async Task<GenericResult<List<Permission>>> GetAllPermissions(Permission permission = null)
        {
            var result = await permissionService.GetAllPermissions(permission);
            return result;
        }


        [HttpGet]
        public GenericResult<PermissionDto> GetPermissionWithRoles(string id)
        {
            var result = permissionService.GetPermissionWithRoles(id);
            return result;
        }


        //[HttpPost]
        //public async Task<GenericResult<string>> Create(PermissionDto permission)
        //{
        //    var result = await permissionService.Create(permission);
        //    return result;
        //}

        [HttpPost]
        public async Task<GenericResult<Permission>> Edit(PermissionDto permission)
        {
            var result = await permissionService.Edit(permission);
            return result;
        }
        [HttpPost]
        public async Task<GenericResult<bool>> Delete(string permissionId)
        {
            var result = await permissionService.Delete(permissionId);
            return result;
        }


    }
}