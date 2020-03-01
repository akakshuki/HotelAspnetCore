using System;
using System.Net.Http;

namespace AppAdmin.Services
{
    public class ApiService
    {
        public HttpClient ApiClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:5001/");
            return client;
        }
    }
}