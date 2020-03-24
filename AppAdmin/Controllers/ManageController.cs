using AppAdmin.Models.DAO;
using AppAdmin.Models.DTOs;
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
                    return View("CategoriesRoom", data);
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
            var data = new CategoryRoomDao().Delete(id);
            var value = await new CategoryRoomDao().GeList();
            return RedirectToAction("CategoriesRoom", value);
        }

        #endregion CategoryRoom

        #region Rooms  [HttpGet]

        public async Task<IActionResult> Rooms()
        {
            var data = await new RoomDao().GeList();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> CreateRooms()
        {
                var data = await new CategoryRoomDao().GeList();
            ViewBag.listCategoryRoom = data;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRooms(RoomMv room)
        {
            if (ModelState.IsValid)
            {
                var data = await new RoomDao().CreateRooms(room);
                ViewBag.listCategoryRoom = data;
                var list = await new RoomDao().GeList();
                return View("Rooms", list);
            }
            else
            {
                var data = await new CategoryRoomDao().GeList();
                ViewBag.listCategoryRoom = data;
                return View();
            }
        }

        [HttpGet]
        public async Task<ViewResult> UpdateRoom(int id)
        {
            var data = await new RoomDao().GetById(id);
            var list = await new CategoryRoomDao().GeList();
            ViewBag.listCategoryRoom = list;
            return View(data);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateRoom(RoomMv room)
        {
            if (ModelState.IsValid)
            {
                await new RoomDao().Update(room);
                var value = await new RoomDao().GeList();
                return RedirectToAction("Rooms", value);
            }
            else
            {
                var data = await new RoomDao().GetById(room.Id);
                var list = await new CategoryRoomDao().GeList();
                ViewBag.listCategoryRoom = list;
                return View(data);
            }
        }

        [HttpGet]
        public async Task<ViewResult> DetailRoom(int id)
        {
            var data = await new RoomDao().GetById(id);

            return View(data);
        }

        public async Task<IActionResult> DeleteRoom(int id)
        {
            var data = new RoomDao().Delete(id);
            var value = await new RoomDao().GeList();
            return RedirectToAction("Rooms", value);
        }

        #endregion Rooms  [HttpGet]

        #region CategoryService

        [HttpGet]
        public async Task<IActionResult> CategoriesService()
        {
            var data = await new CategoryServiceDao().GeList();
            return View(data);
        }

        [HttpGet]
        public IActionResult CreateCategoryService()
        {
            return View();
        }

        [HttpPost]
        public async Task<ViewResult> CreateCategoryService(CategoryServicesMv category)
        {
            if (ModelState.IsValid)
            {
                var res = await new CategoryServiceDao().CreateCategory(category);
                if (res.IsSuccessStatusCode)
                {
                    var data = await new CategoryServiceDao().GeList();
                    return View("CategoriesService", data);
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
        public async Task<ViewResult> UpdateCategoryService(int id)
        {
            var data = await new CategoryServiceDao().GetById(id);

            return View(data);
        }

        [HttpPost]
        public async Task<RedirectToActionResult> UpdateCategoryService(CategoryServicesMv category)
        {
            await new CategoryServiceDao().UpdateCategory(category);
            var value = await new CategoryServiceDao().GeList();
            return RedirectToAction("CategoriesService", value);
        }

        [HttpGet]
        public async Task<ViewResult> DetailCategoryService(int id)
        {
            var data = await new CategoryServiceDao().GetById(id);

            return View(data);
        }

        public async Task<IActionResult> DeleteCategoryService(int id)
        {
            var data = new CategoryServiceDao().Delete(id);
            var value = await new CategoryServiceDao().GeList();
            return View("CategoriesService", value);
        }

        #endregion CategoryService

        #region Service

        public async Task<IActionResult> Services()
        {
            var data = await new ServiceDao().GeList();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> CreateServices()
        {
            var data = await new CategoryServiceDao().GeList();
            ViewBag.listCategoryService = data;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateServices(ServiceMv Service)
        {
            if (ModelState.IsValid)
            {
                var data = await new ServiceDao().CreateServices(Service);
                ViewBag.listCategoryService = data;
                var list = await new ServiceDao().GeList();
                return View("Services", list);
            }
            else
            {
                var data = await new CategoryServiceDao().GeList();
                ViewBag.listCategoryService = data;
                return View();
            }
        }

        [HttpGet]
        public async Task<ViewResult> UpdateService(int id)
        {
            var data = await new ServiceDao().GetById(id);
            var list = await new CategoryServiceDao().GeList();
            ViewBag.listCategoryService = list;
            return View(data);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateService(ServiceMv Service)
        {
            if (ModelState.IsValid)
            {
                await new ServiceDao().Update(Service);
                var value = await new ServiceDao().GeList();
                return RedirectToAction("Services", value);
            }
            else
            {
                var data = await new ServiceDao().GetById(Service.Id);
                var list = await new CategoryServiceDao().GeList();
                ViewBag.listCategoryService = list;
                return View(data);
            }
        }

        [HttpGet]
        public async Task<ViewResult> DetailService(int id)
        {
            var data = await new ServiceDao().GetById(id);

            return View(data);
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            var data = new ServiceDao().Delete(id);
            var value = await new ServiceDao().GeList();
            return RedirectToAction("Services", value);
        }

        #endregion Service


    }
}