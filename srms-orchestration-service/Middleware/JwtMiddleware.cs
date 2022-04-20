using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using srms_orchestration_service.Services.Impl;
using System.Linq;
using System.Threading.Tasks;

namespace srms_orchestration_service.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtServiceImpl _jwtService;

        public JwtMiddleware(RequestDelegate next, JwtServiceImpl jwtService)
        {
            _next = next;
            _jwtService = jwtService;

        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var userId = _jwtService.ValidateJwtToken(token);
            if (userId != null)
            {
                context.Items["user-id"] = userId;
            }

            await _next(context);
        }

    }
}
