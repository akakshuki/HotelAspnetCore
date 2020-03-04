using System.Collections.Generic;
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
        [HttpGet]
        public async Task<ViewResult> UpdateCategoryRoom(int id)
        {
            var data = await new CategoryRoomDao().GetById(id);

            return View(data);
        }
        [HttpPost]
        public async Task<RedirectToActionResult> UpdateCategoryRoom(CategoryRoomMv category)
        { 
            await new CategoryRoomDao().UpdateCategory(category);
            var value = await new CategoryRoomDao().GeList();
            return RedirectToAction("CategoriesRoom", value);
        }

        [HttpGet]
        public async Task<ViewResult> DetailCategoryRoom(int id)
        {
            var data = await new CategoryRoomDao().GetById(id);

            return View(data);
        }


        public async Task<IActionResult> DeleteCategoryRoom(int id)
        {
            var data =  new CategoryRoomDao().Delete(id);
            var value = await new CategoryRoomDao().GeList();
            return RedirectToAction("CategoriesRoom", value);
        }


        #endregion CategoryRoom


        #region Rooms


        #endregion
    }
}