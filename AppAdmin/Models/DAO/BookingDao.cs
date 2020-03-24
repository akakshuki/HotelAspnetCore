using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppAdmin.Models.DTOs;
using AppAdmin.Services;
using Newtonsoft.Json;

namespace AppAdmin.Models.DAO
{
    public class BookingDao
    {
        private ApiService _api = null;

        public BookingDao() => _api = new ApiService();

        private string url = "Booking";


        public async Task<bool> checkEmail(string email)
        {
            var postTask = await _api.GetDataById(url + "/CheckGuest", "?email=" + email);


            if (postTask.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<HttpResponseMessage> Empbooking(BookMv book)
        {
            book.ListRoomIds = book.RoomIds.Split(',').Select(int.Parse).ToArray();
            var postTask = await _api.PostData(url + "/employeepost", book);


            return postTask;
        }

        public async Task<List<GuestMv>> getGuestList()
        {
            try
            {
                var getTask = await _api.GetData(url + "/GetGuest");
                var list = new List<GuestMv>();
                if (getTask.IsSuccessStatusCode)
                {
                    var result = getTask.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<GuestMv>>(result).ToList();

                }

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        public async Task<List<BookingMv>> getListBookingOnline()
        {
            try
            {
                var getTask = await _api.GetData(url + "/GetBookingOnline");
                var list = new List<BookingMv>();
                if (getTask.IsSuccessStatusCode)
                {
                    var result = getTask.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<BookingMv>>(result).ToList();

                }

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<BookingMv>> getListBooking()
        {
            try
            {
                var getTask = await _api.GetData(url + "/GetBooking");
                var list = new List<BookingMv>();
                if (getTask.IsSuccessStatusCode)
                {
                    var result = getTask.Content.ReadAsStringAsync().Result;
                    list = JsonConvert.DeserializeObject<List<BookingMv>>(result).ToList();

                }

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<BookMv> getBookingOnlineById(int bookingId)
        {
            try
            {
                var getTask = await _api.GetDataById(url + "/GetBookingById", bookingId);
                var bookingMv = new BookingMv();
                if (getTask.IsSuccessStatusCode)
                {
                    var result = getTask.Content.ReadAsStringAsync().Result;
                    bookingMv = JsonConvert.DeserializeObject<BookingMv>(result);
                }
                var book = new BookMv()
                {
                    Id = bookingMv.Id,
                    FirstName = bookingMv.GuestMv.FirstName,
                    LastName = bookingMv.GuestMv.LastName,
                    Email = bookingMv.GuestMv.Email,
                    Phone = bookingMv.GuestMv.Phone,
                    CheckOut = bookingMv.CheckOut,
                    CheckIn = bookingMv.CheckIn,
                    IdentityNo = bookingMv.GuestMv.IdentityNo
                };

                return book;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
                throw;
            }
        }

        public async Task<object> EmpAcceptBookingOnline(BookMv book)
        {
            book.ListRoomIds = book.RoomIds.Split(',').Select(int.Parse).ToArray();
            var postTask = await _api.Update(url + "/EmpAcceptBooking", book.Id, book);
            return postTask;
        }
        public async Task<OrderMv> GetDetailOrderBySecretCode(string secretCode)
        {
            try
            {
                var getTask = await _api.GetDataById(url + "/GetBookingBySecretCode", secretCode);
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

        public async Task<object> getDataOrderByOrderNo(string orderNo)
        {
            try
            {
                var getTask = await _api.GetDataById(url + "/GetDetailOrderByOrderNo", orderNo);
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

        public async Task CreateOrderDetail(int orderId, List<OrderService> dataList)
        {

            foreach (var orderService in dataList)
            {
                orderService.OrderId = orderId;
                var postTask = await _api.PostData<OrderService>(url + "/SetOrderDetailService", orderService);
            }

            

        }

        public async Task<List<BookingMv>> GetAllListBooking()
        {
            var getTask = await _api.GetData(url + "/GetAllBooking");
            var bookingMv = new List<BookingMv>();
            if (getTask.IsSuccessStatusCode)
            {
                var result = getTask.Content.ReadAsStringAsync().Result;
                bookingMv = JsonConvert.DeserializeObject<List<BookingMv>>(result);
            }
            return bookingMv;

        }
    }
}
