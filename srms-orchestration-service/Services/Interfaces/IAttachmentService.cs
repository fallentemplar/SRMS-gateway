using Microsoft.AspNetCore.Http;
using srms_orchestration_service.Dto.AttachmentService;
using System.Threading.Tasks;

namespace srms_orchestration_service.Services.Interfaces
{
    public interface IAttachmentService
    {
        Task<UploadedAttachmentDto> UploadAttachment(IFormFile file);
    }
}