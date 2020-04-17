// Code written by Popescu Cristina
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Desktop.Services
{
	public class ApiConnector
	{
		private readonly HttpClient _client;

		public ApiConnector()
		{
			_client = new HttpClient
			{
				BaseAddress = new Uri("https://localhost:44372/api/")
			};
		}

		public async Task<T> GetAsync<T>(string url)
		{
			var response = await _client.GetAsync(url);
			var json = await response.Content.ReadAsStringAsync();

			return JsonConvert.DeserializeObject<T>(json);
		}

        public async Task PostAsync<TContent>(string url, TContent content)
        {
            var jsonContent = JsonConvert.SerializeObject(content);
            var httpContent = new StringContent(jsonContent);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            await _client.PostAsync(url, httpContent);
        }

		public async Task<TRet> PostAsync<TRet, TContent>(string url, TContent content)
		{
			var jsonContent = JsonConvert.SerializeObject(content);
			var httpContent = new StringContent(jsonContent);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			var response = await _client.PostAsync(url, httpContent);
			var jsonResponse = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<TRet>(jsonResponse);
		}
	}
}
