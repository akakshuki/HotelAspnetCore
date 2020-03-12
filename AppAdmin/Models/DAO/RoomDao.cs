using AppAdmin.Models.DTOs;
using AppAdmin.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppAdmin.Models.DAO
{
    public class RoomDao
    {
        private ApiService _api = null;

        public RoomDao() => _api = new ApiService();

        private string url = "Rooms";

        public async Task<List<RoomMv>> GeList()
        {
            var list = new List<RoomMv>();
            var res = await _api.GetData(url);
            try
            {
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<RoomMv>>(result).OrderBy(x => x.CategoryRoomId).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return list;
        }

        public async Task<object> CreateRooms(RoomMv room)
        {
            var postTask = await _api.PostData<RoomMv>(url, room);

            return postTask;
        }

        public async Task<RoomMv> GetById(int id)
        {
            var data = new RoomMv();
            var res = await _api.GetDataById(url, id);
            try
            {
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<RoomMv>(result);
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

        public async Task<HttpResponseMessage> Update(RoomMv room)
        {
            var update = await _api.Update<RoomMv>(url, room.Id, room);

            return update;
        }
    }
}