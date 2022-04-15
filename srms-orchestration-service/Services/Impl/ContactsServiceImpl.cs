using srms_orchestration_service.Client;
using srms_orchestration_service.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace srms_orchestration_service.Services.Impl
{
    public class ContactsServiceImpl : IContactsService
    {
        private readonly ContactsServiceClient _contactsServiceClient;

        public ContactsServiceImpl(ContactsServiceClient contactsServiceClient)
        {
            _contactsServiceClient = contactsServiceClient;
        }
        
        public async Task<List<ContactDto>> GetUserContacts(string userId)
        {
            return await _contactsServiceClient.GetUserContacts(userId);
        }

        public async Task<ContactDto> GetContact(string contactId)
        {
            return await _contactsServiceClient.GetContact(contactId);
        }

        public async Task<ContactDto> CreateContact(ContactDto newContact)
        {
            return await _contactsServiceClient.CreateContact(newContact);
        }

        public async Task<ContactDto> UpdateContact(string userId, ContactDto contactDto)
        {
            return await _contactsServiceClient.UpdateContact(userId, contactDto);
        }

        public async Task<bool> DeleteContact(string contactId)
        {
            return await _contactsServiceClient.DeleteContact(contactId);
        }
    }
}
