using Microsoft.AspNetCore.Mvc;
using IronDome.Dto;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace IronDome.Controllers
{
	public class ThreatManagementController : Controller
	{
		private static readonly List<ThreatManagement> Threat = [];
		private static int _id = 0;

		public IActionResult Index()
		{
			return View(Threat);
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
			Threat.Add(newThrate);
            return RedirectToAction("Index");
        }
		public IActionResult Edit(int id)
		{
            ThreatManagement? toUpdate = Threat.Find(x => x.Id == id) ?? null;
            if (toUpdate == null)
                return RedirectToAction("Index");
            return View(toUpdate);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(ThreatManagement toUpdate)
		{
            //ThreatManagement? toUpdate = Threat.Find(x => x.Id == id) ?? null;
            Threat[Threat.FindIndex(x => x.Id == toUpdate.Id)] = toUpdate;
			return RedirectToAction("Index");
		}
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            ThreatManagement? toDelete = Threat.Find(x => x.Id == id) ?? null;
            if (toDelete == null)
                return RedirectToAction("Index");
            Threat.Remove(toDelete);
            return RedirectToAction("Index");
        }
    }
}

