using Microsoft.AspNetCore.Http;
using srms_orchestration_service.Client;
using srms_orchestration_service.Dto.AttachmentService;
using srms_orchestration_service.Services.Interfaces;
using System.Threading.Tasks;

namespace srms_orchestration_service.Services.Impl
{
    public class AttachmentServiceImpl : IAttachmentService
    {
        private readonly AttachmentServiceClient _attachmentServiceClient;

        public AttachmentServiceImpl(AttachmentServiceClient attachmentServiceClient)
        {
            _attachmentServiceClient = attachmentServiceClient;
        }

        public async Task<UploadedAttachmentDto> UploadAttachment(IFormFile file)
        {
            return await _attachmentServiceClient.UploadAttachment(file);
        }
    }
}
