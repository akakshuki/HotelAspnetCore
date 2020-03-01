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