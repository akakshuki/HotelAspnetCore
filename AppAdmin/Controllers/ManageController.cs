using AppAdmin.Models.DAO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<IActionResult> CategoriesRoom()
        {
            var data = await new CategoryRoomDao().GeList();
            return View(data);
        }

        #endregion CategoryRoom
    }
}