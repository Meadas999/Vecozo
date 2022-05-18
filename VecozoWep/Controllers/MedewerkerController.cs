using BusnLogicVecozo;
using DALMSSQL;
using Microsoft.AspNetCore.Mvc;

namespace VecozoWep.Controllers
{
    public class MedewerkerController : Controller
    {
        private MedewerkerContainer MC = new(new MedewerkerDAL());
        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult VaardigheidToevoegen()
        {
            return View();
        }
    }
}
