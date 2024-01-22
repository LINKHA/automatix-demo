using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.PackageManager;
using UnityEngine;

namespace Amx
{
    public class HttpCli
    {
        HttpClient client = new HttpClient();
        string url;
        public HttpCli() { }
        public void SetOpt(string ip, string port) {
            url = "http://" + ip + ":" + port;
        }

        public async void Get(string suffix, Dictionary<string, string> _headers = null)
        {
            client.DefaultRequestHeaders.Clear();
            if (_headers != null)
            {
                foreach (var header in _headers)
                {

                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

            var response = await client.GetAsync(url + suffix);
            response.EnsureSuccessStatusCode();
            var statusCode = response.StatusCode;
            var headers = response.Headers;

            var str = await response.Content.ReadAsStringAsync();

            Console.WriteLine(str);
        }

        public async Task<string> Post(string suffix, string json, Dictionary<string, string> _headers = null)
        {
            client.DefaultRequestHeaders.Clear();
            if (_headers != null) {
                foreach (var header in _headers) {
                    
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }

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