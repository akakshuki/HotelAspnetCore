using Microsoft.AspNetCore.Mvc;

namespace AppAdmin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string userName, string password)
        {
            return View();
        }
    }
}