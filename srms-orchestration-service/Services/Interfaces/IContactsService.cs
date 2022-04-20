using srms_orchestration_service.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace srms_orchestration_service.Services
{
    public interface IContactsService
    {
        Task<List<ContactDto>> GetUserContacts(string userId);

        Task<ContactDto> GetContact(string contactId);

        Task<ContactDto> CreateContact(ContactDto newContact);

        Task<bool> DeleteContact(string contactId);

        Task<ContactDto> UpdateContact(string userId, ContactDto contactDto);
    }
}
