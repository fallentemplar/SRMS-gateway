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

        public async Task CreateFactForContact(string userId, string contactId, FactDto newFact)
        {
            await _eventsServiceClient.CreateFactForContact(userId, contactId, newFact);
        }

        public async Task UpdateContactFact(string userId, string contactId, string factId, FactDto newFact)
        {
            await _eventsServiceClient.UpdateContactFact(userId, contactId, factId, newFact);
        }

        public async Task DeleteContactFact(string userId, string contactId, string factId)
        {
            await _eventsServiceClient.DeleteContactFact(userId, contactId, factId);
        }
    }
}
