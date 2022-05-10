using Microsoft.AspNetCore.Mvc;

namespace VecozoWep.Controllers
{
    public class Admin : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult MedewerkerOverzicht()
        {
            return View();
        }
    }
}
