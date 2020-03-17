using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppAdmin.Models.DTOs;
using AppAdmin.Models.DAO;
using Microsoft.AspNetCore.Mvc;

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



        [HttpGet]
        public IActionResult CheckOutRoom()
        {
            return View();
        }
    }
}