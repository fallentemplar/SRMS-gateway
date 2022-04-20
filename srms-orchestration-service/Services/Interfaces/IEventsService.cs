using Microsoft.AspNetCore.Http;
using srms_orchestration_service.Dto.EventsService.Events;
using System.Threading.Tasks;

namespace srms_orchestration_service.Services
{
    public interface IEventsService
    {
        Task AddEvent(string userId, string contactId, InboundEventDto newEvent);
    }
}
