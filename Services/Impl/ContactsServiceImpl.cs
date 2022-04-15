using srms_orchestration_service.Client;
using srms_orchestration_service.Dto;
using System.Threading.Tasks;

namespace srms_orchestration_service.Services.Impl
{
    public class ContactsServiceImpl
    {
        private readonly ContactsServiceClient _contactsServiceClient;

        public ContactsServiceImpl(ContactsServiceClient contactsServiceClient)
        {
            _contactsServiceClient = contactsServiceClient;
        }

        public async Task CreateContact()
        {
            ContactDto contactDto = new ContactDto();
            contactDto.BirthDate = new System.DateTime(1997, 01, 15);
            contactDto.FirstName = "Rodrigo";
            contactDto.LastName = "Aguirre";
            contactDto.UserId = "961e7e8d-0022-40f7-9844-074acbb18a81";
            await _contactsServiceClient.CreateContact(contactDto);
        }
    }
}
