using Microsoft.AspNetCore.Mvc;

namespace VecozoWep.Controllers
{
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
