using Microsoft.Extensions.Options;
using srms_orchestration_service.Client.ContactsService;
using srms_orchestration_service.Config;
using srms_orchestration_service.Dto;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace srms_orchestration_service.Client
{
    public class ContactsServiceClient : BaseClient
    {
        private static readonly string ContactUrl = "api/contacts";


        public ContactsServiceClient(IOptions<ContactsServiceClientConfig> clientConfig, RestClient restClient)
            : base(restClient, clientConfig)
        {

        }

        public async Task CreateContact(ContactDto contactDto)
        {
            string url = CreateUrl(ContactUrl);
            await _restClient.Post(url, contactDto);
        }

        public async Task GetContact(string contactId)
        {
            string url = CreateUrl(ContactUrl, contactId);
            await _restClient.Get(url);
        }
    }
}
