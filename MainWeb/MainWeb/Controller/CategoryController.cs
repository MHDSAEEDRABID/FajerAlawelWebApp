using DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace MainWeb.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.Category.GetAll() });
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDB = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);
            if (objFromDB == null)
            {
                return Json(new { success = false, message = "Error While Deleting" });
            }
            _unitOfWork.Category.Remove(objFromDB);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Deleting successful" });
        }
    }
}