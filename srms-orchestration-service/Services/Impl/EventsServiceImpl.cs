using Microsoft.AspNetCore.Http;
using srms_orchestration_service.Client.EventsService;
using srms_orchestration_service.Dto.AttachmentService;
using srms_orchestration_service.Dto.EventsService.Events;
using srms_orchestration_service.Services.Interfaces;
using System.Threading.Tasks;

namespace srms_orchestration_service.Services.Impl
{
    public class EventsServiceImpl : IEventsService
    {
        private readonly IAttachmentService _attachmentService;
        private readonly EventsServiceClient _eventsServiceClient;


        public EventsServiceImpl(IAttachmentService attachmentService,
            EventsServiceClient eventsServiceClient)
        {
            _attachmentService = attachmentService;
            _eventsServiceClient = eventsServiceClient;
        }

        public async Task AddEvent(string userId, string contactId, InboundEventDto newEvent)
        {

            EventDto eventDto = new EventDto()
            {
                EventName = newEvent.EventName,
                Content = newEvent.Content,
                Date = newEvent.Date,
            };
            if (newEvent.Attachment != null && newEvent.Attachment.File != null)
            {
                UploadedAttachmentDto uploadedAttachment = await _attachmentService.UploadAttachment(newEvent.Attachment.File);
                eventDto.AddAttachment(newEvent.Attachment, uploadedAttachment.FileId);
            }

            await _eventsServiceClient.AddEvent(userId, contactId, eventDto);
        }
    }
}
