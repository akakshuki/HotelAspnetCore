using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppAdmin.Services
{
    public class ApiService
    {
        private HttpClient _client = null;

        public ApiService()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://localhost:5001/api/");
        }

        public HttpClient ApiClient()
        {
            return _client;
        }

        public async Task<HttpResponseMessage> GetData(string url)
        {
            var res = await _client.GetAsync(url);
            return res;
        }

        public async Task<HttpResponseMessage> PostData<T>(string url, T data)
        {
            var res = await _client.PostAsJsonAsync(url, data);
            return res;
        }

        public async Task<HttpResponseMessage> GetDataById(string url, object id)
        {
            var res = await _client.GetAsync(url + "/" + id.ToString());
            return res;
        }

        public async Task<HttpResponseMessage> DeleteDataById(string url, object id)
        {
            var res = await _client.DeleteAsync(url + "/" + id.ToString());
            return res;
        }

        public async Task<HttpResponseMessage> Update<T>(string url, object id, T data)
        {
            var res = await _client.PutAsJsonAsync(url + "/" + id, data);
            return res;
        }
    }
}