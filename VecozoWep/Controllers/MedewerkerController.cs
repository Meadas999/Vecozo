using BusnLogicVecozo;
using DALMSSQL;
using Microsoft.AspNetCore.Mvc;
using VecozoWep.Models;

namespace VecozoWep.Controllers
{
    public class MedewerkerController : Controller
    {
        private MedewerkerContainer MC = new(new MedewerkerDAL());
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("UserId") != null)
            {
                int? id = HttpContext.Session.GetInt32("UserId");
                Medewerker med = MC.FindById((int)id);
                MedewerkerVM vm = new(med);
                return View(vm);
            }
            return RedirectToAction("LogIn","Login");
        }

        public IActionResult VaardigheidToevoegen()
        {
            return View();
        }
    }
}
