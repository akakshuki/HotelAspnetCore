using AppAdmin.Models.DTOs;
using AppAdmin.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AppAdmin.Models.DAO
{
    public class CategoryRoomDao
    {
        private ApiService _api = null;

        public CategoryRoomDao() => _api = new ApiService();

        public async Task<List<CategoryRoomMv>> GeList()
        {
            List<CategoryRoomMv> list = new List<CategoryRoomMv>();
            HttpClient client = _api.ApiClient();
            HttpResponseMessage res = await client.GetAsync("api/CategoryRooms");
            try
            {
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<CategoryRoomMv>>(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return list;
        }

        public async Task<HttpResponseMessage> CreateCategory(CategoryRoomMv category)
        {
            HttpClient client = _api.ApiClient();

            string data = JsonConvert.SerializeObject(
                new
                {
                    data = category
                });
            var content = new StringContent(data.ToString(), Encoding.UTF8, "application/json");

            var postTask = await client.PostAsync("api/CategoryRooms", content);

            return  postTask;


        }
    }
}