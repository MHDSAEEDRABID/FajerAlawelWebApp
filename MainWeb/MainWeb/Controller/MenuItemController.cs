using DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
namespace MainWeb.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public MenuItemController(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.MenuItem.GetAll(null, null, "Category,FoodType") });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var objFromDB = _unitOfWork.MenuItem.GetFirstOrDefault(x => x.Id == id);
                if (objFromDB == null)
                {
                    return Json(new { success = false, message = "Error While Deleting" });
                }
                string imagePath = Path.Combine(_hostingEnvironment.WebRootPath, objFromDB.Image.TrimStart('\\'));
                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
                _unitOfWork.MenuItem.Remove(objFromDB);
                _unitOfWork.Save();
            }
            catch(Exception ex)
            {
                return Json(new { success = false, message = $"{ex.Message}" });
            }
            return Json(new { success = true, message = "Deleting successful" });
        }
    }
}