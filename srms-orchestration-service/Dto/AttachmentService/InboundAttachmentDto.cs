using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace srms_orchestration_service.Dto.AttachmentService
{
    public class InboundAttachmentDto
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        public IFormFile File { get; set; }
    }
}
