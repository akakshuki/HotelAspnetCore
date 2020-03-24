using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AppAdmin.Models.DAO
{
    public class HistoryController : Controller
    {
        public async Task<IActionResult> HistoryBooking()
        {
            var listHistoryBooking = await new BookingDao().GetAllListBooking();

            return View(listHistoryBooking);
        }
    }
}