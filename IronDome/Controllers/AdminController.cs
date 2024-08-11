using IronDome.Dto;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace IronDome.Controllers
{
    public class AdminController(AdminDto admin) : Controller
    {
        public IActionResult Index()
        {
            return View(admin);
        }
		public IActionResult Update()
		{
			return View(admin);
		}
        [HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult Update(AdminDto adminDto)
		{
			admin.MissileAmount = adminDto.MissileAmount;
			return RedirectToAction("Index");
		}
	}
}

