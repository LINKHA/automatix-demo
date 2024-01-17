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
            public int level;
            public float timeElapsed;
            public string playerName;
        }
        public async void Post(string suffix)
        {
            MyClass myObject = new MyClass();
            myObject.level = 1;
            myObject.timeElapsed = 47.5f;
            myObject.playerName = "Dr Charles Francis";
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