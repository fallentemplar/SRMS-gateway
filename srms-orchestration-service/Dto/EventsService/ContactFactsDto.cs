using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace srms_orchestration_service.Dto.EventsService
{
    public class ContactFactsDto
    {
        public ContactFactsDto()
        {
            Facts = new Dictionary<string, FactDto>();
        }

        public ContactFactsDto(ContactDto contactDto) : this()
        {
            UserId = contactDto.UserId;
            ContactId = contactDto.ContactId;
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public string ContactId { get; set; }

        public Dictionary<string, FactDto> Facts { get; set; }
    }
}
