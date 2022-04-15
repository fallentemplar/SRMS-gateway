using srms_orchestration_service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace srms_orchestration_service.Services
{
    public interface IContactsService
    {
        Task<ContactDto> CreateContact(ContactDto newContact);
        Task<bool> DeleteContact(string contactId);
        Task<ContactDto> GetContact(string contactId);
        Task<ContactDto> UpdateContact(ContactDto contactDto);
    }
}
