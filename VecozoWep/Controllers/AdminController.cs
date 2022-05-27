using BusnLogicVecozo;
using DALMSSQL;
using Microsoft.AspNetCore.Mvc;
using VecozoWeb.Models;
using VecozoWep.Models;

namespace VecozoWep.Controllers
{
    public class AdminController : Controller
    {
        private LeidingGevendeContainer LC = new(new LeidinggevendenDAL());
        private MedewerkerContainer MC = new(new MedewerkerDAL());
        private LeidingGevendeContainer LC = new(new LeidinggevendenDAL());
        private VaardigheidContainer VC = new(new VaardigheidDAL());
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                int id = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                LeidinggevendenVM vm = new(LC.FindById(id));
                vm.Medewerkers = MC.HaalAlleMedewerkersOp().Select(x => new MedewerkerVM(x)).ToList();
                foreach (MedewerkerVM m in vm.Medewerkers)
                {
                    m.vaardigheden = VC.FindByMedewerker(m.UserID).Select(x => new VaardigheidVM(x)).ToList();
                }
                return View(vm);
            }
            return RedirectToAction("Index", "Login");   
        }

        
        public IActionResult MedewerkerOverzicht()
        {
            return View();
        }
    }
}
