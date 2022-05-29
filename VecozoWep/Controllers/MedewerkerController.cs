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
                med.Ratings = VC.FindByMedewerker(med.UserID);
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
            Medewerker med = MC.FindById(id.Value);
            r.Vaardigheid = new VaardigheidVM(r.vaardigheidNaam);
            Rating rating = r.GetRating();
            VC.VoegVaardigheidToeAanMedewerker(med, rating);
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult VaardigheidVerwijderen(int VaardigheidId)
        {
            int? Userid = HttpContext.Session.GetInt32("UserId");
            Rating r = VC.FindRating(Userid.Value, VaardigheidId);
            RatingVM rating = new(r);
            return PartialView("_VaardigheidVerwijderenPartial", rating);
        }
        [HttpPost]
        public IActionResult VaardigheidVerwijderen(RatingVM r, int VaardigheidId)
        {
            int? id = HttpContext.Session.GetInt32("UserId");
            Medewerker med = MC.FindById(id.Value);
            VC.VerwijderVaarigheidVanMedewerker(med, VaardigheidId);
            RatingVM rating = new();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult VaardigheidEdit(int VaardigheidId)
        {
            int? Userid = HttpContext.Session.GetInt32("UserId");
            Rating r = VC.FindRating(Userid.Value, VaardigheidId);
            RatingVM rating = new(r);
            return PartialView("_VaardigheidEditParial", rating);
        }
        [HttpPost]
        public IActionResult VaardigheidEdit(RatingVM r)
        {
            int? id = HttpContext.Session.GetInt32("UserId");
            Medewerker med = MC.FindById(id.Value);            
            r.Vaardigheid = new VaardigheidVM(r.vaardigheidNaam, r.vaardigheidId);
            Rating rating = r.GetRating();
            VC.UpdateRating(med, rating);
            return RedirectToAction("Index");
        }
    }
}
