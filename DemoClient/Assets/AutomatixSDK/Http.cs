using System;
using System.Net.Http;
using System.Text;
using UnityEngine;

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
        public class MyClass
        {
            public string mobile;
            public string password;
        }
        public async void Post(string suffix)
        {
            MyClass myObject = new MyClass();
            myObject.mobile = "1885740001";
            myObject.password = "123456";
            string json = JsonUtility.ToJson(myObject);

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

            Console.WriteLine(str);
        }
    }
}