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
        private VaardigheidContainer VC = new(new VaardigheidDAL());
        public IActionResult Index()
        {
            int? id = HttpContext.Session.GetInt32("UserId");
            if (id == null) return RedirectToAction("Login", "User");
            LeidinggevendenVM vm = new(LC.GetLeidingGevendeById(id.Value));
            vm.Medewerkers = MC.HaalAlleMedewerkersOp().Select(x => new MedewerkerVM(x)).ToList();
            foreach (MedewerkerVM m in vm.Medewerkers)
            {
                m.Ratings = VC.FindByMedewerker(m.UserID).Select(x => new RatingVM(x)).ToList();
                m.MijnTeam = MC.GetTeamById(m.UserID);

            }
            return View(vm);
        }

        
        public IActionResult MedewerkerOverzicht()
        {
            return View();
        }
    }
}
