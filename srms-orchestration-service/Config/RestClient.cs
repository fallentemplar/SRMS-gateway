using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
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
        public void AddRequestHeader(string name, string value)
        {
            if (_client.DefaultRequestHeaders.Contains(name))
            {
                _client.DefaultRequestHeaders.Remove(name);
            }
            _client.DefaultRequestHeaders.Add(name, value);

        }

        public async Task<T> Get<T>(string url)
        {
            HttpResponseMessage httpResponseMessage = await _client.GetAsync(url);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string response = httpResponseMessage.Content.ReadAsStringAsync().Result;
                T parsedResponse = JsonConvert.DeserializeObject<T>(response);
                return parsedResponse;
            }
            throw new Exception("Cannot retrieve contact");
        }

        public async Task<T> Post<T>(string url, Object body)
        {
            string jsonContent = JsonConvert.SerializeObject(body);
            HttpResponseMessage httpResponseMessage = await _client.PostAsync(url, new StringContent(jsonContent, Encoding.UTF8, "application/json"));
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string response = httpResponseMessage.Content.ReadAsStringAsync().Result;
                T parsedResponse = JsonConvert.DeserializeObject<T>(response);
                return parsedResponse;
            }
            throw new Exception("Cannot create contact");
        }

        public async Task Post(string url, Object body)
        {
            string jsonContent = JsonConvert.SerializeObject(body);
            HttpResponseMessage httpResponseMessage = await _client.PostAsync(url, new StringContent(jsonContent, Encoding.UTF8, "application/json"));
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("Cannot create contact");
            }

        }

        public async Task<T> PostMultipart<T>(string url, IFormFile body)
        {
            var fileName = ContentDispositionHeaderValue.Parse(body.ContentDisposition).FileName.Trim('"');

            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StreamContent(body.OpenReadStream())
                {
                    Headers =
                    {
                        ContentLength = body.Length,
                        ContentType = new MediaTypeHeaderValue(body.ContentType)
                    }
                }, "File", fileName);
                HttpResponseMessage httpResponseMessage = await _client.PostAsync(url, content);
                if (!httpResponseMessage.IsSuccessStatusCode)
                {
                    throw new Exception("Cannot create contact");
                }

                string response = httpResponseMessage.Content.ReadAsStringAsync().Result;
                T parsedResponse = JsonConvert.DeserializeObject<T>(response);
                return parsedResponse;
            }


        }

        public async Task<T> Put<T>(string url, Object body)
        {
            string jsonContent = JsonConvert.SerializeObject(body);
            HttpResponseMessage httpResponseMessage = await _client.PutAsync(url, new StringContent(jsonContent, Encoding.UTF8, "application/json"));
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                string response = httpResponseMessage.Content.ReadAsStringAsync().Result;
                T parsedResponse = JsonConvert.DeserializeObject<T>(response);
                return parsedResponse;
            }
            throw new Exception("Cannot update contact");
        }

        public async Task Put(string url, Object body)
        {
            string jsonContent = JsonConvert.SerializeObject(body);
            HttpResponseMessage httpResponseMessage = await _client.PutAsync(url, new StringContent(jsonContent, Encoding.UTF8, "application/json"));
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("Cannot update contact");
            }
        }

        public async Task<bool> Delete(string url)
        {
            HttpResponseMessage httpResponseMessage = await _client.DeleteAsync(url);

            return httpResponseMessage.IsSuccessStatusCode;
        }
    }
}
