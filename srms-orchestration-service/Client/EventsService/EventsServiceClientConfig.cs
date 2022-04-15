namespace srms_orchestration_service.Client.EventsService
{
    public class EventsServiceClientConfig : IServiceClientConfig
    {
        public string Url { get; set; }
        public string Token { get; set; }

        public EventsServiceClientConfig()
        {

        }
    }
}
