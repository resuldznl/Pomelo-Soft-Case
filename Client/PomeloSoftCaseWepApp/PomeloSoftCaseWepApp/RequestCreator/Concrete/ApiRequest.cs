using Microsoft.AspNetCore.Http;
using PomeloSoftCaseWepApp.RequestCreator.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace PomeloSoftCaseWepApp.RequestCreator.Concrete
{
    public class ApiRequest : IApiRequest
    {
        HttpClient httpClient = new HttpClient();

        public async Task<string> GetRequestAsync(string url , string token)
        {
            if (token != null)
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var msg = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
            };

            var response = await httpClient.SendAsync(msg);
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> PostRequestAsync(object postModel,string url, string token)
        {
            if(token != null)
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var msg = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
                Content = new StringContent(JsonSerializer.Serialize(postModel), System.Text.Encoding.UTF8, "application/json"),
            };
            var response = await httpClient.SendAsync(msg);
            return response.StatusCode == System.Net.HttpStatusCode.OK ? await response.Content.ReadAsStringAsync() : null;
        }
        public async Task<string> PostFileRequestAsync(object postModel, IFormFile file , string url , string token)
        {
            if(token != null)
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var formData = new MultipartFormDataContent();
            if(file != null)
                formData.Add(new StreamContent(file.OpenReadStream()), "file", file.FileName);

            formData.Add(new StringContent(JsonSerializer.Serialize(postModel), System.Text.Encoding.UTF8, "application/json"), "postModel");
            var response = await httpClient.PostAsync(url, formData);
            return await response.Content.ReadAsStringAsync();
        }
        public async Task<string> PutFileRequestAsync(object postModel, IFormFile file, string url, string token)
        {
            HttpClient httpClient = new HttpClient();
            if (token != null)
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var formData = new MultipartFormDataContent();
            if (file != null)
                formData.Add(new StreamContent(file.OpenReadStream()), "file", file.FileName);

            formData.Add(new StringContent(JsonSerializer.Serialize(postModel), System.Text.Encoding.UTF8, "application/json"), "postModel");
            var response = await httpClient.PutAsync(url,formData);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
