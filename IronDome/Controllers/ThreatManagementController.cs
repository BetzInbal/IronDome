using Microsoft.AspNetCore.Mvc;
using IronDome.Dto;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using IronDome.Service;

namespace IronDome.Controllers
{
	public class ThreatManagementController(IThreatManagementService threatManagementService, LaunchDto launchDto) : Controller
	{
		private static readonly List<ThreatManagement> Threat = [];
		private static int _id = 1;

		public IActionResult Index()
		{
			return View(launchDto.Threats);
		}
        public IActionResult Create()
        {
            return View(new ThreatManagement() );
        }
		[HttpPost]
		[ValidateAntiForgeryToken]
        public IActionResult Create(ThreatManagement newThrate)
        {

			newThrate.Id = _id++  ;
            launchDto.Threats.Add(newThrate);
            return RedirectToAction("Index");
        }
		public IActionResult Edit(int id)
		{
            ThreatManagement? toUpdate = launchDto.Threats.Find(x => x.Id == id) ?? null;
            if (toUpdate == null)
                return RedirectToAction("Index");
            return View(toUpdate);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(ThreatManagement toUpdate)
		{
            //ThreatManagement? toUpdate = Threat.Find(x => x.Id == id) ?? null;
            launchDto.Threats[launchDto.Threats.FindIndex(x => x.Id == toUpdate.Id)] = toUpdate;
			return RedirectToAction("Index");
		}
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            ThreatManagement? toDelete = launchDto.Threats.Find(x => x.Id == id) ?? null;
            if (toDelete == null)
                return RedirectToAction("Index");
            launchDto.Threats.Remove(toDelete);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Launch(int id)
        {
            ThreatManagement? toLaunch = launchDto.Threats.Find(x => x.Id == id) ?? null;
            if (toLaunch == null)
                return RedirectToAction("Index");
            if (toLaunch.IsActive == false)
                return RedirectToAction("Index");
            CancellationTokenSource cts = new CancellationTokenSource();
            var seconds = Utils.ResponseTime.CalculateResponseTime(toLaunch);
            threatManagementService.Launching(cts.Token, seconds, toLaunch);
            launchDto.activeLaunch[id] = cts;
            return RedirectToAction("Index");
        }
    }
}

