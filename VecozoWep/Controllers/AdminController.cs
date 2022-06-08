using BusnLogicVecozo;
using DALMSSQL;
using DALMSSQL.Exceptions;
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
        private TeamContainer TC = new(new TeamDAL());
        public IActionResult Index()
        {
            try
            {
                int id = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                LeidinggevendenVM vm = new(LC.FindById(id));
                vm.Medewerkers = MC.HaalAlleMedewerkersOp().Select(x => new MedewerkerVM(x)).ToList();
                foreach (MedewerkerVM m in vm.Medewerkers)
                {
                    int id = Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
                    LeidinggevendenVM vm = new(LC.FindById(id));
                    vm.Medewerkers = MC.HaalAlleMedewerkersOp().Select(x => new MedewerkerVM(x)).ToList();
                    foreach (MedewerkerVM m in vm.Medewerkers)
                    {
                        m.Ratings = VC.FindByMedewerker(m.UserID).Select(x => new RatingVM(x)).ToList();
                    }
                    return View(vm);
                }
                return RedirectToAction("Index", "Login");
            }
            catch (TemporaryException ex)
            {
                return View("SqlErrorMessage");
            }
            catch (Exception ex)
            {
                return View("PermanentError");
            }
        }

        
        public IActionResult MedewerkerOverzicht(int mwid)
        {
            try
            {
                MedewerkerVM vm = new(MC.FindById(mwid));
                vm.Ratings = VC.FindByMedewerker(vm.UserID).Select(x => new RatingVM(x)).ToList();
                vm.MijnTeam = new(TC.FindById(vm.UserID));
                return View(vm);
            }
            catch (TemporaryException ex)
            {
                return View("SqlErrorMessage");
            }
            catch (Exception ex)
            {
                return View("PermanentError");
            }
        }

        public IActionResult TeamsOverzicht()
        {
            List<TeamVM> vms = new();
            List<Team> teams = TC.GetAll();
            foreach(Team team in teams)
            {
                vms.Add(new TeamVM(team));
            }
            return View(vms);
        }

        public IActionResult BewerkTeam(int id)
        {
            Team team = TC.FindById(id);
            TeamVM vm = new(team);
            return View(vm);
        }


        [HttpPost]
        public IActionResult BewerkTeam(TeamVM vm)
        {
            Team t = new(vm.Id, vm.Kleur, vm.Taak, vm.GemRating);
            TC.Update(t);
            return RedirectToAction("TeamsOverzicht");
        }

        public IActionResult PasLedenAan(int id)
        {
            MedewerkerTeamVM vms = new();
            List<Medewerker> medewerkers = MC.HaalAlleMedewerkersOp();
            foreach(Medewerker m in medewerkers)
            {
                vms.MedewerkersVM.Add(new MedewerkerVM(m));
            }
            Team t = TC.FindById(id);
            vms.TeamVM = new TeamVM(t);
            return View(vms);
        }

        [HttpPost]
        public IActionResult PasLedenAan(MedewerkerTeamVM vm)
        {
            List<Medewerker> medewerkers = new List<Medewerker>();
            foreach (MedewerkerVM medewerker in vm.MedewerkersVM)
            {
                medewerkers.Add(new Medewerker(medewerker.UserID));
            }
            foreach (Medewerker mw in medewerkers)
            {
                TC.UpdateTeamMedewerker(mw);
            }
            return RedirectToAction("TeamsOverzicht");
        }

        [HttpGet]
        public IActionResult VaardigheidToevoegen()
        {
            RatingVM rating = new();
            rating.Vaardigheid = new();
            return PartialView("_VaardigheidTvgPartial", rating);
        }
        [HttpPost]
        public IActionResult VaardigheidToevoegen(RatingVM r)
        {
            int? id = HttpContext.Session.GetInt32("MwId");
            Medewerker med = MC.FindById(id.Value);
            r.Vaardigheid = new VaardigheidVM(r.vaardigheidNaam);
            Rating rating = r.GetRating();
            VC.VoegVaardigheidToeAanMedewerker(med, rating);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult VaardigheidVerwijderen(int VaardigheidId)
        {
            int? Userid = HttpContext.Session.GetInt32("MwId");
            Rating r = VC.FindRating(Userid.Value, VaardigheidId);
            RatingVM rating = new(r);
            return PartialView("_VaardigheidVwdPartial", rating);
        }
        [HttpPost]
        public IActionResult VaardigheidVerwijderen(RatingVM r, int VaardigheidId)
        {
            int? id = HttpContext.Session.GetInt32("MwId");
            Medewerker med = MC.FindById(id.Value);
            VC.VerwijderVaarigheidVanMedewerker(med, VaardigheidId);
            RatingVM rating = new();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult VaardigheidEdit(int VaardigheidId)
        {
            int? Userid = HttpContext.Session.GetInt32("MwId");
            Rating r = VC.FindRating(Userid.Value, VaardigheidId);
            RatingVM rating = new(r);
            return PartialView("_VaardigheidEditPartial", rating);
        }
        [HttpPost]
        public IActionResult VaardigheidEdit(RatingVM r)
        {
            int? id = HttpContext.Session.GetInt32("MwId");
            Medewerker med = MC.FindById(id.Value);
            r.Vaardigheid = new VaardigheidVM(r.vaardigheidNaam, r.vaardigheidId);
            Rating rating = r.GetRating();
            VC.UpdateRating(med, rating);
            return RedirectToAction("Index");
        }
        //[HttpGet]
        //public IActionResult VaardigheidToevoegen(int mwid)
        //{
        //    RatingVM rating = new();
        //    rating.Vaardigheid = new();
        //    return PartialView("_VaardigheidToevoegenParial", rating);
        //}
        //[HttpPost]
        //public IActionResult VaardigheidTvgBijMW(RatingVM r, int mwid)
        //{
        //    Medewerker med = MC.FindById(mwid);
        //    r.Vaardigheid = new VaardigheidVM(r.vaardigheidNaam);
        //    Rating rating = r.GetRating();
        //    VC.VoegVaardigheidToeAanMedewerker(med, rating);
        //    return RedirectToAction("MedewerkerOverzicht", mwid);
        //}

        //[HttpGet]
        //public IActionResult VaardigheidVerwijderen(int mwid, int VaardigheidId)
        //{
        //    Rating r = VC.FindRating(mwid, VaardigheidId);
        //    RatingVM rating = new(r);
        //    return PartialView("_VaardigheidVerwijderenPartial", rating);
        //}

        //[HttpPost]
        //public IActionResult VaardigheidVerwijderen(int mwid, RatingVM r, int VaardigheidId)
        //{
        //    Medewerker med = MC.FindById(mwid);
        //    VC.VerwijderVaarigheidVanMedewerker(med, VaardigheidId);
        //    RatingVM rating = new();
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public IActionResult VaardigheidEdit(int mwid, int VaardigheidId)
        //{
        //    Rating r = VC.FindRating(mwid, VaardigheidId);
        //    RatingVM rating = new(r);
        //    return PartialView("_VaardigheidEditParial", rating);
        //}

        //public IActionResult VaardigheidEdit(int mwid, RatingVM r)
        //{
        //    Medewerker med = MC.FindById(mwid);
        //    r.Vaardigheid = new VaardigheidVM(r.vaardigheidNaam, r.vaardigheidId);
        //    Rating rating = r.GetRating();
        //    VC.UpdateRating(med, rating);
        //    return RedirectToAction("Index");
        //}
    }
}
