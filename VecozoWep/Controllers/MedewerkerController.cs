using BusnLogicVecozo;
using DALMSSQL;
using Microsoft.AspNetCore.Mvc;
using VecozoWeb.Models;
using VecozoWep.Models;

namespace VecozoWep.Controllers
{
    public class MedewerkerController : Controller
    {
        private MedewerkerContainer MC = new(new MedewerkerDAL());
        private VaardigheidContainer VC = new(new VaardigheidDAL());
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("UserId") != null)
            {
                int id = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                Medewerker med = MC.FindById(id);
                MedewerkerVM vm = new(med);
                return View(vm);
            }
            return RedirectToAction("Index","Login");
        }
            public IActionResult VaardigheidToevoegen()
        {
            RatingVM rating = new();
            return PartialView("_VaardigheidToevoegenParial", rating);
        }
        public IActionResult VaardigheidToevoegen(RatingVM r)
        {
            int? id = HttpContext.Session.GetInt32("UserId");
            if (ModelState.IsValid && id != null)
            {
                Medewerker med = MC.FindById((int)id);
                Rating rating = r.GetRating();
                VC.VoegVaardigheidToeAanMedewerker(med, rating);
                return RedirectToAction("Index");
            }
            return View("Index");
        }
    }
}
