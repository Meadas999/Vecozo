using BusnLogicVecozo;
using DALMSSQL;
using Microsoft.AspNetCore.Mvc;
using VecozoWep.Models;

namespace VecozoWep.Controllers
{
    public class LoginController : Controller
    {
        private MedewerkerContainer MC = new(new MedewerkerDAL());
        private LeidingGevendeContainer LC = new(new LeidinggevendenDAL());
        public IActionResult Index()
        {
            InlogVM vm = new();
            return View(vm);
        }
        public IActionResult LogIn(InlogVM vm)
        {
            LeidingGevende admin = LC.Inloggen(vm.Email, vm.Password);
            Medewerker user = MC.Inloggen(vm.Email, vm.Password);
            if (admin != null)
            {
                
                LeidinggevendenVM lvm = new(admin);
                HttpContext.Session.SetInt32("UserId", lvm.UserID);
                return RedirectToAction("Index","Admin");
            }
            else if (user != null)
            {
                
                MedewerkerVM mvm = new(user);
                HttpContext.Session.SetInt32("UserId", mvm.UserID);
                return RedirectToAction("Index", "Medewerker");
            }
            else
            {
                InlogVM newvm = new();
                newvm.Retry = true;
                return View("Index",newvm);
            }
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
