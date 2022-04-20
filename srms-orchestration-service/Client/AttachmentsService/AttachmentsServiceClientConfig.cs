namespace srms_orchestration_service.Client.AttachmentsService
{
    public class AttachmentsServiceClientConfig : IServiceClientConfig
    {
        public string Url { get; set; }
        public string Token { get; set; }

        public AttachmentsServiceClientConfig()
        {

        }
    }
}
