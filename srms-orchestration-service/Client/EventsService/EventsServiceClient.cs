using Microsoft.Extensions.Options;
using srms_orchestration_service.Config;
using srms_orchestration_service.Constants;
using srms_orchestration_service.Dto.EventsService;
using System;
using System.Threading.Tasks;

namespace srms_orchestration_service.Client.EventsService
{
    public class EventsServiceClient : BaseClient
    {
        private static readonly string ContactUrl = "api/contacts";
        private static readonly string FactsUrl = "api/facts";
        public EventsServiceClient(IOptions<EventsServiceClientConfig> clientConfig, RestClient restClient)
            : base(restClient, clientConfig)
        {

        }

        public async Task CreateContactFactsRecord(string userId, ContactDto contactDto)
        {
            _restClient.AddRequestHeader(HeaderNames.USER_ID, userId);
            await _restClient.Post(CreateUrl(ContactUrl), contactDto);
        }

        public async Task CreateContactFactsRecord(string userId, string contactId)
        {
            ContactDto contactDto = new ContactDto()
            {
                UserId = userId,
                ContactId = contactId
            };
            await CreateContactFactsRecord(userId, contactDto);
        }

        public async Task<ContactFactsDto> GetContactFacts(string userId, string contactId)
        {
            _restClient.AddRequestHeader(HeaderNames.USER_ID, userId);
            return await _restClient.Get<ContactFactsDto>(CreateUrl(FactsUrl, contactId));
        }

        public async Task CreateFactForContact(string userId, string contactId, FactDto newFact)
        {
            _restClient.AddRequestHeader(HeaderNames.USER_ID, userId);
            await _restClient.Post(CreateUrl(FactsUrl, contactId), newFact);
        }

        public async Task UpdateContactFact(string userId, string contactId, string factId, FactDto newFact)
        {
            _restClient.AddRequestHeader(HeaderNames.USER_ID, userId);
            string url = CreateUrl(FactsUrl, contactId, factId);
            await _restClient.Put(url, newFact);
        }

        public async Task DeleteContactFact(string userId, string contactId, string factId)
        {
            _restClient.AddRequestHeader(HeaderNames.USER_ID, userId);
            string url = CreateUrl(FactsUrl, contactId, factId);
            await _restClient.Delete(url);
        }

    }
}
