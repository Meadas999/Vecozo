using BusnLogicVecozo;
using DALMSSQL;
using Microsoft.AspNetCore.Mvc;
using VecozoWep.Models;

namespace VecozoWep.Controllers
{
    public class LoginController : Controller
    {
        private MedewerkerContainer MC = new(new MedewerkerDAL());
        public IActionResult Index()
        {
            InlogVM vm = new();
            return View(vm);
        }
        public IActionResult LogIn(InlogVM vm)
        {   
            Medewerker user = MC.Inloggen(vm.Email, vm.Password);
            if (user != null)
            {
                LeidinggevendenVM lvm = new(user);
                HttpContext.Session.SetInt32("UserId", lvm.UserID);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                InlogVM newvm = new();
                newvm.Retry = true;
                return View(newvm);
            }

        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
