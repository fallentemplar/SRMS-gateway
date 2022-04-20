using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using srms_orchestration_service.Client.AttachmentsService;
using srms_orchestration_service.Config;
using srms_orchestration_service.Dto.AttachmentService;
using System.Threading.Tasks;

namespace srms_orchestration_service.Client
{
    public class AttachmentServiceClient : BaseClient
    {
        private static readonly string AttachmentsUrl = "api/attachments";
        public AttachmentServiceClient(IOptions<AttachmentsServiceClientConfig> clientConfig, RestClient restClient)
            : base(restClient, clientConfig)
        {

        }

        public async Task<UploadedAttachmentDto> UploadAttachment(IFormFile file)
        {
            string url = CreateUrl(AttachmentsUrl);
            return await _restClient.PostMultipart<UploadedAttachmentDto>(url, file);
        }
    }
}
