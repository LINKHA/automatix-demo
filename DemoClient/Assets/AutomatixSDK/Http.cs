using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Automatix
{
    public class Http
    {
        HttpClient client = new HttpClient();
        string url;
        public Http(string url)
        {
            this.url = url; 
        }

        public async void Get(string suffix)
        {
            var response = await client.GetAsync(url + suffix);
            response.EnsureSuccessStatusCode();
            var statusCode = response.StatusCode;
            var headers = response.Headers;

            var str = await response.Content.ReadAsStringAsync();

            Console.WriteLine(str);
        }

        public async void Post(string suffix)
        {
            var response = await client.PostAsync(
                url + suffix,
                new StringContent(
                JsonConvert.SerializeObject(new { Name = "ะกร๗", Id = 1 }),
                Encoding.UTF8,
                "application/json")
            );

            response.EnsureSuccessStatusCode();
            var statusCode = response.StatusCode;
            var headers = response.Headers;

            var str = await response.Content.ReadAsStringAsync();

            Console.WriteLine(str);
        }
    }
}