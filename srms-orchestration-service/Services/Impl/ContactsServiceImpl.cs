using srms_orchestration_service.Client;
using srms_orchestration_service.Dto;
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

        public async Task<ContactDto> GetContact(string contactId)
        {
            return await _contactsServiceClient.GetContact(contactId);
        }

        public async Task<ContactDto> CreateContact(ContactDto newContact)
        {
            return await _contactsServiceClient.CreateContact(newContact);
        }

        public async Task<ContactDto> UpdateContact(ContactDto contactDto)
        {
            return await _contactsServiceClient.CreateContact(contactDto);
        }

        public async Task<bool> DeleteContact(string contactId)
        {
            return await _contactsServiceClient.DeleteContact(contactId);
        }
    }
}
