using System;
namespace srms_orchestration_service.Client.ContactsService
{
    public class ContactsServiceClientConfig : IServiceClientConfig
    {
        public string Url { get; set; }
        public string Token { get; set; }

        public ContactsServiceClientConfig()
        {
        }
    }
}
