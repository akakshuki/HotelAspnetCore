using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppAdmin.Models.DAO;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace AppAdmin.Controllers
{
    public class CheckOutController : Controller
    {
        public async Task<IActionResult> TotalOrder(string orderNo)
        {
            var data = await new OrderDao().GetDataToCheckOut(orderNo);

            return View(data);
        }

        public IActionResult PaymentWithCash(string orderNo, decimal money)
        {
            var res  =  new OrderDao().PaymentWithCash(orderNo, money);
            if (res.IsCompletedSuccessfully)
            {
                return RedirectToAction("Home", "Manage");
            }
            else
            {
                return RedirectToAction("Home", "Manage");
            }
           
        }

        public async Task<IActionResult> PaymentWithMomo(string orderNo, decimal money)
        {
            var res = await new OrderDao().PaymentWithMomo(orderNo, money);
           return Redirect(res);
            
        }
    }
}