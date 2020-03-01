using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AppAdmin.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult _LayoutHeader()
        {
            return PartialView();
        }

        public IActionResult _LayoutNavigate()
        {
            return PartialView();
        }
    }



}