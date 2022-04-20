using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using srms_orchestration_service.Dto.AttachmentService;
using System;
using System.Collections.Generic;

namespace srms_orchestration_service.Dto.EventsService.Events
{
    public class EventDto
    {
        [JsonProperty("eventName")]
        public string EventName { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("attachments")]
        public List<AttachmentDto> Attachments { get; set; }

        public void AddAttachment(InboundAttachmentDto attachmentDto, string url)
        {
            if (Attachments == null)
            {
                Attachments = new List<AttachmentDto>();
            }
            Attachments.Add(new AttachmentDto()
            {
                Title = attachmentDto.Title,
                Description = attachmentDto.Description,
                ContentType = attachmentDto.File.ContentType,
                Url = url
            });
        }
    }
}
