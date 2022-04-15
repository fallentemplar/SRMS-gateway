using srms_orchestration_service.Client.EventsService;
using srms_orchestration_service.Dto.EventsService;
using System.Threading.Tasks;

namespace srms_orchestration_service.Services.Impl
{
    public class FactsServiceImpl : IFactsService
    {
        private readonly EventsServiceClient _eventsServiceClient;

        public FactsServiceImpl(EventsServiceClient eventsServiceClient)
        {
            _eventsServiceClient = eventsServiceClient;
        }

        public async Task<ContactFactsDto> GetContactFacts(string userId, string contactId)
        {
            return await _eventsServiceClient.GetContactFacts(userId, contactId);
        }
    }
}
