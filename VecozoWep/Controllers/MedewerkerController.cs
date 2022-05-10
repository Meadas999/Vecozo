using Microsoft.AspNetCore.Mvc;

namespace VecozoWep.Controllers
{
    public class MedewerkerController : Controller
    {
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
