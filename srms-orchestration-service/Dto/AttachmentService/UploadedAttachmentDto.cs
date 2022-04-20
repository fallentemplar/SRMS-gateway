using Newtonsoft.Json;

namespace srms_orchestration_service.Dto.AttachmentService
{
    public class UploadedAttachmentDto
    {
        [JsonProperty("fileName")]
        public string FileId { get; set; }
    }
}
