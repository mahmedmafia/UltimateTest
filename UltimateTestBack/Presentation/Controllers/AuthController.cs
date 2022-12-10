using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DTO;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IServiceManager _service;
        public AuthController(IServiceManager serviceManager)
        {
            _service = serviceManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> LoginAsync([FromBody] UserLoginDto userLogin)
        {
            var token=await this._service.AuthService.Login(userLogin);
            if (token != null)
            {
                return Ok(token);
            }
            return NotFound("user not found");
        }

    }
}
