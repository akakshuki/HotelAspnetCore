using AppAdmin.Models.DTOs;
using AppAdmin.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AppAdmin.Models.DAO
{
    public class CategoryServiceDao
    {
        private ApiService _api = null;

        public CategoryServiceDao() => _api = new ApiService();

        private string url = "CategoryServices";

        public async Task<List<CategoryServicesMv>> GeList()
        {
            var list = new List<CategoryServicesMv>();
            var res = await _api.GetData(url);
            try
            {
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<CategoryServicesMv>>(result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return list;
        }

        public async Task<HttpResponseMessage> CreateCategory(CategoryServicesMv category)
        {
            var postTask = await _api.PostData<CategoryServicesMv>(url, category);

            return postTask;
        }

        public async Task<CategoryServicesMv> GetById(int id)
        {
            var data = new CategoryServicesMv();
            var res = await _api.GetDataById(url, id);
            try
            {
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    data = JsonConvert.DeserializeObject<CategoryServicesMv>(result);
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

        public async Task<HttpResponseMessage> UpdateCategory(CategoryServicesMv category)
        {
            var update = await _api.Update<CategoryServicesMv>(url, category.Id, category);

            return update;
        }


       
    }
}