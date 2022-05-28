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
        [HttpGet]
        public IActionResult VaardigheidToevoegen()
        {
            RatingVM rating = new();
            rating.Vaardigheid = new();
            return PartialView("_VaardigheidToevoegenParial", rating);
        }
        [HttpPost]
        public IActionResult VaardigheidToevoegen(RatingVM r)
        {
            int? id = HttpContext.Session.GetInt32("UserId");
            Medewerker med = MC.FindById(1);
            r.Vaardigheid = new VaardigheidVM(r.vaardigheidNaam);
            Rating rating = r.GetRating();
            VC.VoegVaardigheidToeAanMedewerker(med, rating);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult VaardigheidVerwijderen(int Id)
        {
            RatingVM rating = new();
            return PartialView("_VaardigheidVerwijderenParial", rating);
        }
        [HttpPost]
        public IActionResult VaardigheidVerwijderen(RatingVM r)
        {
            int? id = HttpContext.Session.GetInt32("UserId");
            Medewerker med = MC.FindById(1);
            Rating rating = r.GetRating();
            VC.VerwijderVaarigheidVanMedewerker(med, rating.Vaardigheid);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult VaardigheidEdit(int Id)
        {
            RatingVM rating = new();
            return PartialView("_VaardigheidEditParial", rating);
        }
        [HttpPost]
        public IActionResult VaardigheidEdit(RatingVM r)
        {
            Rating rating = r.GetRating();
            VC.UpdateRating( rating);
            return RedirectToAction("Index");
        }
    }
}
