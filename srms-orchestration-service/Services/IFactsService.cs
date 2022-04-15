using srms_orchestration_service.Dto.EventsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace srms_orchestration_service.Services
{
    public interface IFactsService
    {
        Task<ContactFactsDto> GetContactFacts(string userId, string contactId);
    }
}
