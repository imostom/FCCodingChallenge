using FCCodingChallenge.API.Data.Models;
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
        public UserController(IUserService userService, RemoteDetails remoteDetails, IHttpContextAccessor httpContext, LoggerManager loggerManager)
          : base(remoteDetails, httpContext, loggerManager)
        {
            _userService = userService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get Single User by Email")]
        [Route("user/{email}")]
        public async Task<IActionResult> GetUser(string email)
        {
            var resp = this.CustomResponse(await _userService.GetUser(email));
            return resp;
        }
    }
}
