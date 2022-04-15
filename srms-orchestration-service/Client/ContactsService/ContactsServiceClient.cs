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

        public async Task<ContactDto> CreateContact(ContactDto contactDto)
        {
            string url = CreateUrl(ContactUrl);
            ContactDto createdContact = await _restClient.Post<ContactDto>(url, contactDto);
            return createdContact;
        }

        public async Task<ContactDto> GetContact(string contactId)
        {
            string url = CreateUrl(ContactUrl, contactId);
            return await _restClient.Get<ContactDto>(url);
        }

        public async Task<ContactDto> UpdateContact(string contactId, ContactDto contactDto)
        {
            string url = CreateUrl(ContactUrl, contactId);
            ContactDto createdContact = await _restClient.Put<ContactDto>(url, contactDto);
            return createdContact;
        }

        public async Task<bool> DeleteContact(string contactId)
        {
            string url = CreateUrl(ContactUrl, contactId);
            return await _restClient.Delete(url);
        }
    }
}
