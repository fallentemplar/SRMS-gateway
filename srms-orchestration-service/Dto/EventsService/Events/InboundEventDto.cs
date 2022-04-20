using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using srms_orchestration_service.Dto.AttachmentService;
using System;
using System.Collections.Generic;

namespace srms_orchestration_service.Dto.EventsService.Events
{
    public class InboundEventDto
    {
        [JsonProperty("eventName")]
        public string EventName { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        public InboundAttachmentDto Attachment { get; set; }
    }
}
