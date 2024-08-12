using IronDome.Dto;
using IronDome.ModelVM;
using IronDome.Service;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace IronDome.Controllers
{
    public class AdminController(IAdminService adminService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var admin = await adminService.GetAdmin();
            if (admin == null)
                return RedirectToAction("Index","Home");
            AdminVM adminvm = new() { MissileAmount = admin.MissileAmount };
            return View(adminvm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdminVM adminVM)
        {
            await adminService.UpDateMissleAmount(adminVM.MissileAmount);
            return RedirectToAction("Index");
        }

    }
}
