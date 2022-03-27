using FCCodingChallenge.API.Data.Models;
using FCCodingChallenge.API.Data.ViewModels;
using FCCodingChallenge.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace FCCodingChallenge.API.Controllers
{
    [Route("api/fastcredit")]
    [ApiController]
    public class UserController : BaseController
    {

        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;
        public UserController(IUserService userService, IUserRoleService userRoleService, RemoteDetails remoteDetails, ILoggerManager loggerManager)
          : base(remoteDetails, loggerManager)
        {
            _userService = userService;
            _userRoleService = userRoleService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get User by Email")]
        [Route("user/{email}")]
        public async Task<IActionResult> GetUser(string email)
        {
            var resp = this.CustomResponse(await _userService.GetUser(email));
            return resp;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get User by Phone")]
        [Route("user/{phone}")]
        public async Task<IActionResult> GetUserByPhone(string phone)
        {
            var resp = this.CustomResponse(await _userService.GetUserByPhone(phone));
            return resp;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create New User and Assign Role")]
        [Route("user")]
        public async Task<IActionResult> AddUser(UserVM userRoleRequest)
        {
            var resp = this.CustomResponse(await _userRoleService.AddUserRole(_remoteDetails, userRoleRequest));
            return resp;
        }

        [HttpDelete]
        [SwaggerOperation(Summary = "Delete User Profile")]
        [Route("user/{email}")]
        public async Task<IActionResult> DeleteUser(string email)
        {
            var resp = this.CustomResponse(await _userRoleService.DeleteUserRole(_remoteDetails, email));
            return resp;
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Update User Profile")]
        [Route("user")]
        public async Task<IActionResult> UpdateUser(UserVM userVM)
        {
            var resp = this.CustomResponse(await _userService.UpdateUser(_remoteDetails, userVM));
            return resp;
        }
    }
}
