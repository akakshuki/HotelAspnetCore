using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppAdmin.Models.DTOs;
using AppAdmin.Services;
using Newtonsoft.Json;

namespace AppAdmin.Models.DAO
{
    public class CategoryRoomDao
    {
        private ApiService _api = null;

        public CategoryRoomDao()
        {
           _api = new ApiService();
        }

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
    }


}




