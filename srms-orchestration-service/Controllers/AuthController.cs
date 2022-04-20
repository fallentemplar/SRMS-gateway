using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using srms_orchestration_service.Constants;
using srms_orchestration_service.Services.Impl;

namespace srms_orchestration_service.Controllers
{
    [AllowAnonymous]
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtServiceImpl _jwtService;

        public AuthController(JwtServiceImpl jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpGet]
        public string GenerateJwt()
        {
            Request.Headers.TryGetValue(HeaderNames.USER_ID, out StringValues userId);
            return _jwtService.GenerateJwtToken(userId);
        }
    }
}
