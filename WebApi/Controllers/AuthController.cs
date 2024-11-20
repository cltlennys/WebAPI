using Core.Entities;
using Core.Interfaces.Services;
using Infrastructure.Repositories.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class AuthController : BaseApiController
    {

        private readonly ITokenService _tokenservice;
        public AuthController(ITokenService tokenService)
        {
            _tokenservice = tokenService;
        }
        [HttpPost("GenerateToken")]
        [AllowAnonymous]
        public IActionResult GenerateToken([FromBody] UsserCredential usserCredential)
        {
            string token = _tokenservice.GenerateToken(usserCredential);
            return Ok(token);
        }

        [HttpGet("Protected")]
        [Authorize]
        public IActionResult ProtectedEndpoint()
        {
            return Ok("Esta es una protegida");
        }

        [HttpGet("ProtectedAdmin")]
        [Authorize(Roles = "Admin")]
        public IActionResult ProtectedAdminRol()
        {
            return Ok("Esta es una api solo para admin");
        }

        [HttpGet("ProtectedSecurity")]
        [Authorize(Roles = "Seguridad")]
        public IActionResult ProtectedSecurityRol()
        {
            return Ok("Esta es una api solo para seguridad");
        }

        [HttpGet("ProtectedBoth")]
        [Authorize(Roles = "Admin,Seguridad")]
        public IActionResult ProtectedBothRol()
        {
            return Ok("Esta es una api solo para admin y seguridad");
        }
    }

   
}
