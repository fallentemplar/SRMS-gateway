using srms_orchestration_service.Client;
using srms_orchestration_service.Client.EventsService;
using srms_orchestration_service.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace srms_orchestration_service.Services.Impl
{
    public class ContactsServiceImpl : IContactsService
    {
        private readonly ContactsServiceClient _contactsServiceClient;
        private readonly EventsServiceClient _eventsServiceClient;

        public ContactsServiceImpl(ContactsServiceClient contactsServiceClient, EventsServiceClient eventsServiceClient)
        {
            _contactsServiceClient = contactsServiceClient;
            _eventsServiceClient = eventsServiceClient;
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
            ContactDto createdContact = await _contactsServiceClient.CreateContact(newContact);
            await _eventsServiceClient.CreateContactFactsRecord(createdContact.UserId, createdContact.ContactId);
            return createdContact;
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
