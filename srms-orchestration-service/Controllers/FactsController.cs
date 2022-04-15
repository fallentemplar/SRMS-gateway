using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using srms_orchestration_service.Constants;
using srms_orchestration_service.Dto.EventsService;
using srms_orchestration_service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace srms_orchestration_service.Controllers
{
    [Route("api/facts")]
    [ApiController]
    public class FactsController : ControllerBase
    {
        private readonly IFactsService _factsService;

        public FactsController(IFactsService factsService)
        {
            _factsService = factsService;
        }

        [HttpGet("{contactId}")]
        public async Task<ContactFactsDto> GetUserFacts(string contactId)
        {
            string userId = GetHeaderFromRequest(HeaderNames.USER_ID);
            return await _factsService.GetContactFacts(userId, contactId);
        }

        private string GetHeaderFromRequest(string headerName)
        {
            bool retrieved = Request.Headers.TryGetValue(headerName, out StringValues retrievedHeader);
            if (!retrieved)
            {
                Console.WriteLine("Error :c");
            }
            return retrievedHeader;
        }
    }
}
