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
    public class ServiceDao
    {
        private ApiService _api = null;

        public ServiceDao() => _api = new ApiService();

        private string url = "Services";

        public async Task<List<ServiceMv>> GeList()
        {
            var list = new List<ServiceMv>();
            var res = await _api.GetData(url);
            try
            {
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<ServiceMv>>(result).OrderBy(x => x.CategoryServiceId).ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return list;
        }

        public async Task<object> CreateServices(ServiceMv Service)
        {
            var postTask = await _api.PostData<ServiceMv>(url, Service);

            return postTask;
        }

        public async Task<ServiceMv> GetById(int id)
        {
            var data = new ServiceMv();
            var res = await _api.GetDataById(url, id);
            try
            {
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<ServiceMv>(result);
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

        public async Task<HttpResponseMessage> Update(ServiceMv Service)
        {
            var update = await _api.Update<ServiceMv>(url, Service.Id, Service);

            return update;
        }

        public async Task<List<ServiceMv>> GetServicesByCategoryId(int id)
        {
            var data = new List<ServiceMv>();
            var res = await _api.GetDataById(url + "/getServiceByCategoryId", id);
            try
            {
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<List<ServiceMv>>(result);
                }
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
             
            }
        }
    }
}