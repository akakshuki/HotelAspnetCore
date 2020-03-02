using System;
using System.Net.Http;

namespace AppAdmin.Services
{
    public class ApiService
    {
        public HttpClient ApiClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.BaseAddress = new Uri("https://localhost:44333/");
            return client;
        }
    }
}