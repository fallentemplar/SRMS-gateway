using Microsoft.Extensions.Options;
using srms_orchestration_service.Config;
using System;

namespace srms_orchestration_service.Client
{
    public abstract class BaseClient
    {
        protected readonly string BaseUrl;
        protected readonly string Token;

        protected readonly RestClient _restClient;
        protected BaseClient(RestClient restClient, IOptions<IServiceClientConfig> clientConfig)
        {
            _restClient = restClient;
            BaseUrl = clientConfig.Value.Url;
            Token = clientConfig.Value.Token;
        }

        protected string CreateUrl(string endpoint)
        {
            return String.Format("{0}{1}", BaseUrl, endpoint);
        }

        protected string CreateUrl(string endpoint, string parameter)
        {
            return String.Format("{0}{1}/{2}", BaseUrl, endpoint, parameter);
        }

        protected string CreateUrl(string endpoint, string firstParameter, string secondParameter)
        {
            return String.Format("{0}{1}/{2}/{3}", BaseUrl, endpoint, firstParameter, secondParameter);
        }
    }
}
