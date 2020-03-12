using Microsoft.AspNetCore.Mvc;

namespace AppAdmin.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFound()
        {
            return View();
        }

        public IActionResult Null()
        {
            return View();
        }
    }
}