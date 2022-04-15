using srms_orchestration_service.Dto.EventsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace srms_orchestration_service.Services
{
    public interface IFactsService
    {
        Task CreateFactForContact(string userId, string contactId, FactDto newFact);
        Task DeleteContactFact(string userId, string contactId, string factId);
        Task<ContactFactsDto> GetContactFacts(string userId, string contactId);
        Task UpdateContactFact(string userId, string contactId, string factId, FactDto newFact);
    }
}
