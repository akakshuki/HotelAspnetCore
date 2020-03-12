using AppAdmin.Models.DTOs;
using AppAdmin.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppAdmin.Models.DAO
{
    public class CategoryRoomDao
    {
        private ApiService _api = null;

        public CategoryRoomDao() => _api = new ApiService();

        private string url = "CategoryRooms";

        public async Task<List<CategoryRoomMv>> GeList()
        {
            var list = new List<CategoryRoomMv>();
            var res = await _api.GetData(url);
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
                throw;
            }

            return list;
        }

        public async Task<HttpResponseMessage> CreateCategory(CategoryRoomMv category)
        {
            var postTask = await _api.PostData<CategoryRoomMv>(url, category);

            return postTask;
        }

        public async Task<CategoryRoomMv> GetById(int id)
        {
            var data = new CategoryRoomMv();
            var res = await _api.GetDataById(url, id);
            try
            {
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<CategoryRoomMv>(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return data;
        }

        public async Task Delete(int id)
        {
            try
            {
                var result = await _api.DeleteDataById(url, id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<HttpResponseMessage> UpdateCategory(CategoryRoomMv category)
        {
            var update = await _api.Update<CategoryRoomMv>(url, category.Id, category);

            return update;
        }
    }
}