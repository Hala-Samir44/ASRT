using LLS.BLL;
using LLS.BLL.Services;
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
    public class userController : ControllerBase
    {
        public userService userService { get; set; }
        public userController(userService userService)
        {
            this.userService = userService;
        }
        [HttpGet]
        public async Task<GenericResult<List<User>>> GetUsers(User user=null)
        {
            var result = await userService.GetUsers(user);
            return result;
        }



        [HttpPost]
        public async Task<GenericResult<string>> Create(User user)
        {
            var result = await userService.Create(user);
            return result;
        }

        [HttpPost]
        public async Task<GenericResult<User>> Edit(User user)
        {
            var result = await userService.Edit(user);
            return result;
        }
        [HttpPost]
        public async Task<GenericResult<bool>> Delete(string userId)
        {
            var result = await userService.Delete(userId);
            return result;
        }


    }
}
