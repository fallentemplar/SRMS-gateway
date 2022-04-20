using Newtonsoft.Json;
using System.Collections.Generic;

namespace srms_orchestration_service.Dto.EventsService.Events
{
    public class ContactEventsDto
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("contactId")]
        public string ContactId { get; set; }

        [JsonProperty("events")]
        public Dictionary<string, EventDto> Events { get; set; }
    }
}
