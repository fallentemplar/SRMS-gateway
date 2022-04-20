using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using srms_orchestration_service.Constants;
using srms_orchestration_service.Dto.EventsService;
using srms_orchestration_service.Dto.EventsService.Events;
using srms_orchestration_service.Middleware;
using srms_orchestration_service.Services;
using System;
using System.Threading.Tasks;

namespace srms_orchestration_service.Controllers
{
    [AuthMiddleware]
    [Route("api/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventsService _eventsService;

        public EventsController(IEventsService factsService)
        {
            _eventsService = factsService;
        }

        /*[HttpGet("{contactId}")]
        public async Task<ContactFactsDto> GetUserFacts(string contactId)
        {
            string userId = GetHeaderFromRequest(HeaderNames.USER_ID);
            return await _eventsService.GetContactFacts(userId, contactId);
        }*/

        [HttpPost("{contactId}")]
        public async Task CreateEventForContact(string contactId, [FromForm] InboundEventDto newEvent)
        {
            string userId = GetHeaderFromRequest(HeaderNames.USER_ID);
            await _eventsService.AddEvent(userId, contactId, newEvent);
        }

        [HttpGet("{contactId}")]
        public async Task<ContactEventsDto> GetContactEvents(string contactId)
        {
            string userId = GetHeaderFromRequest(HeaderNames.USER_ID);
            return await _eventsService.GetContactEvents(userId, contactId);
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
