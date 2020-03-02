using System.ComponentModel.DataAnnotations;
using AppAdmin.Models.DAO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AppAdmin.Models.DTOs;

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

        [HttpGet]
        public IActionResult CreateCategoryRoom()
        {
           
            return View();
        }

        [HttpPost]
        public async Task<ViewResult> CreateCategoryRoom(CategoryRoomMv category)
        {
            if (ModelState.IsValid)
            {
                var res = await new CategoryRoomDao().CreateCategory(category);
                if (res.IsSuccessStatusCode)
                {
                    var data = await new CategoryRoomDao().GeList();
                    return View("CategoriesRoom",data);
                }
                else
                {
                    return View();
                }
               
            }
            else
            {
                return View();
            }
            
        }

        #endregion CategoryRoom
    }
}