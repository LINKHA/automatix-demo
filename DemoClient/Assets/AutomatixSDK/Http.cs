using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Amx
{
    public class HttpCli
    {
        HttpClient client = new HttpClient();
        string url;
        public HttpCli(string ip, string port)
        {
            url = "http://" + ip + ":" + port; 
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

        public async Task<string> Post(string suffix, string json)
        {
            var response = await client.PostAsync(
                url + suffix,
                new StringContent(
                json,
                Encoding.UTF8,
                "application/json")
            );

            response.EnsureSuccessStatusCode();
            var statusCode = response.StatusCode;
            var headers = response.Headers;

            var str = await response.Content.ReadAsStringAsync();
            return str;
        }
    }
}