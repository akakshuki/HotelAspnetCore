using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using AppAdmin.Models.Common;
using AppAdmin.Models.DTOs;
using AppAdmin.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AppAdmin.Models.DAO
{
    public class OrderDao
    {
        private ApiService _api = null;
        private string url = "CheckOut";
        public OrderDao() => _api = new ApiService();


        public async Task<OrderMv> GetDataToCheckOut(string orderNo)
        {

            try
            {
                var getTask = await _api.GetDataById(url + "/GetDataForCheckOut", orderNo);
                var bookingMv = new OrderMv();
                if (getTask.IsSuccessStatusCode)
                {
                    var result = getTask.Content.ReadAsStringAsync().Result;
                    bookingMv = JsonConvert.DeserializeObject<OrderMv>(result);
                }
                return bookingMv;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;

            }
        }

        public async Task<object> PaymentWithCash(string orderNo, decimal money)
        {
            var res = await _api.GetData(url + "/GetDataForCheckOut/" + orderNo + "/" + 1 + "/" + money);
            return res;
        }

        public async Task<string> PaymentWithMomo(string orderNo, decimal money)
        {
            var res = _api.GetData(url + "/GetDataForCheckOut/" + orderNo + "/" + 0 + "/" + money);

            return await res.Result.Content.ReadAsStringAsync();
        }

        public async Task<HttpResponseMessage> CancelBooking(string secretCode)
        {
            var res = await _api.GetDataById(url + "/CancelBooking", secretCode);
            return res;
        }
    }
}
