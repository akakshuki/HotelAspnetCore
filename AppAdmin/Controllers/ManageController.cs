using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AppAdmin.Models.DAO;
using AppAdmin.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AppAdmin.Controllers
{
   
    public class ManageController : Controller
    {
        
        public IActionResult Home()
        {
            return View();
        }


        #region CategoryRoom
        [HttpGet]
        public IActionResult CategoriesRoom()
        {
            var data = new CategoryRoomDao().GeList();
            return View(data);
        }

        #endregion

    }
}