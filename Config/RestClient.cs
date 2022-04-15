using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace srms_orchestration_service.Config
{
    public class RestClient
    {
        private readonly HttpClient _client;
        public RestClient()
        {
            _client = new HttpClient();
            SetParameters();
        }

        private void SetParameters()
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task Get(string url)
        {
            await _client.GetAsync(url);
        }

        public async Task Post(string url, Object body)
        {
            string jsonContent = JsonConvert.SerializeObject(body);
            HttpResponseMessage httpResponseMessage = await _client.PostAsync(url, new StringContent(jsonContent, Encoding.UTF8, "application/json"));
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string response = httpResponseMessage.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
