using BusnLogicVecozo;
using DALMSSQL;
using DALMSSQL.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VecozoWeb.Models;
using VecozoWep.Models;

namespace VecozoWep.Controllers
{
    public class LoginController : Controller
    {
        private MedewerkerContainer MC = new(new MedewerkerDAL());
        private LeidingGevendeContainer LC = new(new LeidinggevendenDAL());
        private TeamContainer TC = new(new TeamDAL());
        
        public IActionResult Index()
        {
            try
            {
            }
            catch (TemporaryException ex)
            {
                return View("SqlErrorMessage");
            }
            catch (Exception ex)
            {
                return View("PermanentError");
            }
            HttpContext.Session.Clear();
            HttpContext.Session.SetInt32("IsAdmin", -1);
            InlogVM vm = new();
            return View(vm);
        }
        
        public IActionResult LogIn(InlogVM vm)
        {
            try
            {
                LeidingGevende admin = LC.Inloggen(vm.Email, vm.Password);
                Medewerker user = MC.Inloggen(vm.Email, vm.Password);
                if (user != null)
                {
                    MedewerkerVM mvm = new(user);
                    HttpContext.Session.SetInt32("UserId", mvm.UserID);
                    return RedirectToAction("Index", "Medewerker");
                }
                else if (admin != null)
                {
                    LeidingGevende lg = LC.Inloggen(vm.Email, vm.Password);
                    HttpContext.Session.SetInt32("UserId", lg.UserID);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    InlogVM newvm = new();
                    newvm.Retry = true;
                    return View("Index", newvm);
                }
            }
            catch (TemporaryException ex)
            {
                return View("SqlErrorMessage");
            }
            catch (PermanentException ex)
            {
                return View("PermanentError");
            }
        }
        
        public IActionResult Register()
        {
            try
            {
                GebruikersVM vm = new();
                vm.Leidinggevenden = LC.HaalAlleLeidinggevendeOp().Select(x => new LeidinggevendenVM(x)).ToList();
                vm.Teams = TC.GetAll().Select(x => new TeamVM(x)).ToList();
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

        [HttpPost]
        public IActionResult Register(GebruikersVM vm)
        {
            try
            {
                Medewerker med = new(vm.Medewerker.Email, vm.Medewerker.Voornaam, vm.Medewerker.Achternaam, vm.Medewerker.Tussenvoegsel);
                if (vm.Medewerker.IsAdmin)
                {
                    LeidingGevende l = new(med.Email, med.Voornaam, med.Achternaam, 0, med.Tussenvoegsel);
                    LC.Create(l, vm.Medewerker.Wachtwoord);
                    LeidingGevende leid = LC.Inloggen(l.Email, vm.Medewerker.Wachtwoord);
                    HttpContext.Session.SetInt32("UserId", leid.UserID);
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    med.MijnTeam = TC.FindById(vm.Team.Id);
                    MC.Create(med, vm.Medewerker.Wachtwoord);
                    LeidingGevende leid = LC.FindById(vm.Leidinggevende.UserID);
                    Medewerker medewerker = MC.Inloggen(med.Email, vm.Medewerker.Wachtwoord);
                    MC.KoppelMedewerkerAanLeidinggevenden(medewerker, leid);
                    HttpContext.Session.SetInt32("UserId", medewerker.UserID);
                    return RedirectToAction("Index", "Medewerker");
                }
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
    }
}
