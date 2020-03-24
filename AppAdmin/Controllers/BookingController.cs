using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppAdmin.Models.Common;
using AppAdmin.Models.DTOs;
using AppAdmin.Models.DAO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AppAdmin.Controllers
{
    public class BookingController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Home()
        {
            ViewBag.ListGuest = await new BookingDao().getGuestList();
            ViewBag.ListBookingOnline = await new BookingDao().getListBookingOnline();
            ViewBag.ListBooking = await new BookingDao().getListBooking();
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Booking()
        {
            ViewBag.CategoryRoom = await new CategoryRoomDao().GeList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Booking(BookMv book)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CategoryRoom = await new CategoryRoomDao().GeList();
                return RedirectToAction("Booking");
            }
            else
            {
                try
                {
                    var data = new BookingDao().Empbooking(book);
                    ViewBag.CategoryRoom = await new CategoryRoomDao().GeList();
                    ViewBag.ListGuest = await new BookingDao().getGuestList();
                    ViewBag.ListBookingOnline = await new BookingDao().getListBookingOnline();
                    ViewBag.ListBooking = await new BookingDao().getListBooking();
                    return View("Home");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    ViewBag.CategoryRoom = await new CategoryRoomDao().GeList();
                    return View("Booking");
                }
            }


        }

        [HttpGet]
        public async Task<JsonResult> checkEmail(string email)
        {
            if (await new BookingDao().checkEmail(email))
            {
                return Json(new
                {
                    data = true
                });
            }
            else
            {
                return Json(new
                {
                    data = false
                });
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetRoomsByCategoryId(int idCate)
        {
            var data = await new RoomDao().listCategoryRoomById(idCate);
            return Json(new
            {
                data = data
            });
        }


        [HttpGet]
        public async Task<IActionResult> CheckInRoom()
        {
            ViewBag.CategoryRoom = await new CategoryRoomDao().GeList();
            ViewBag.ListBookingOnline = await new BookingDao().getListBookingOnline();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckInRoom(BookMv book)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CategoryRoom = await new CategoryRoomDao().GeList();
                ViewBag.ListBookingOnline = await new BookingDao().getListBookingOnline();
                return View();
            }
            else
            {

                ViewBag.ListBookingOnline = await new BookingDao().EmpAcceptBookingOnline(book);
                ViewBag.ListGuest = await new BookingDao().getGuestList();
                ViewBag.ListBookingOnline = await new BookingDao().getListBookingOnline();
                ViewBag.ListBooking = await new BookingDao().getListBooking();
                return View("Home");
            }

        }

        [HttpGet]
        public async Task<JsonResult> GetBookingById(int bookingId)
        {

            var booking = await new BookingDao().getBookingOnlineById(bookingId);
            return Json(new
            {
                data = booking
            });
        }

        [HttpGet]
        public IActionResult CheckOutRoom()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetDetailOrder(string secretCode)
        {
            var dataDetailOrder = await new BookingDao().GetDetailOrderBySecretCode(secretCode);
            return View(dataDetailOrder);
        }

        public async Task<IActionResult> AddServices()
        {
            return View();
        }

        public async Task<IActionResult> AddServiceBySecretCode(string OrderNo)
        {
            ViewBag.dataOrder = await new BookingDao().getDataOrderByOrderNo(OrderNo);
            ViewBag.listCategorySerivce = await new CategoryServiceDao().GeList();

            return View();
        }


        [HttpGet]
        public async Task<JsonResult> GetServicesByCategoryId(int id)
        {
            var data = await new ServiceDao().GetServicesByCategoryId(id);

            return Json(new
            {
                data = data
            });
        }

        [HttpGet]
        public async Task<JsonResult> SetListOrderService(int idService)
        {
            try
            {
                var data = new SessionCommon(HttpContext).DataGet();

                if (data != null)
                {
                    List<OrderService> list = JsonConvert.DeserializeObject<List<OrderService>>(data);
                    if (list.Exists(x => x.Id == idService))
                    {
                        foreach (var orderService in list)
                        {
                            if (orderService.Id == idService)
                            {
                                orderService.Quantity++;
                            }
                        }
                    }
                    else
                    {
                        var dataService = await new ServiceDao().GetById(idService);
                        var orderService = new OrderService()
                        {
                            Id = dataService.Id,
                            Name = dataService.Name,
                            Price = dataService.Price,
                            CategoryName = dataService.CategoryServicesMv.Name,
                            Quantity = 1
                        };
                        list.Add(orderService);
                    }
                    var res = JsonConvert.SerializeObject(list);
                    new SessionCommon(HttpContext).DataSet(res);
                }
                else
                {
                    var list = new List<OrderService>();
                    var dataService = await new ServiceDao().GetById(idService);
                    var orderService = new OrderService()
                    {
                        Id = dataService.Id,
                        Name = dataService.Name,
                        Price = dataService.Price,
                        CategoryName = dataService.CategoryServicesMv.Name,
                        Quantity = 1
                    };

                    list.Add(orderService);
                    var res = JsonConvert.SerializeObject(list);
                    new SessionCommon(HttpContext).DataSet(res);
                }



                return Json(new
                {
                    data = JsonConvert.DeserializeObject<List<OrderService>>(new SessionCommon(HttpContext).DataGet())
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public JsonResult removeItemOrder(int idService)
        {
            var data = JsonConvert.DeserializeObject<List<OrderService>>(new SessionCommon(HttpContext).DataGet());

            data.Remove(data.SingleOrDefault(x => x.Id == idService));

            new SessionCommon(HttpContext).DataSet(JsonConvert.SerializeObject(data));

            return Json(new
            {
                data = JsonConvert.DeserializeObject<List<OrderService>>(new SessionCommon(HttpContext).DataGet())
            });
        }


        public async Task<IActionResult> SaveOrderDetailService(int orderId)
        {

            try
            {
                var dataList = JsonConvert.DeserializeObject<List<OrderService>>(new SessionCommon(HttpContext).DataGet());

                await new BookingDao().CreateOrderDetail(orderId, dataList);

                new SessionCommon(HttpContext).dataRemove();

                ViewBag.ListGuest = await new BookingDao().getGuestList();
                ViewBag.ListBookingOnline = await new BookingDao().getListBookingOnline();
                ViewBag.ListBooking = await new BookingDao().getListBooking();
                return RedirectToAction("Home");
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                throw;
            }

        }

        public IActionResult CancelBooking(string secretCode)
        {
            var res = new OrderDao().CancelBooking(secretCode);
            if (res.IsCompletedSuccessfully)
            {
                ViewBag.ListGuest = new BookingDao().getGuestList();
                ViewBag.ListBookingOnline = new BookingDao().getListBookingOnline();
                ViewBag.ListBooking = new BookingDao().getListBooking();
                return RedirectToAction("Home");

            }
            else
            {
                ViewBag.ListGuest = new BookingDao().getGuestList();
                ViewBag.ListBookingOnline = new BookingDao().getListBookingOnline();
                ViewBag.ListBooking = new BookingDao().getListBooking();
                return RedirectToAction("Home");
            }
        }
    }
}


