using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

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
