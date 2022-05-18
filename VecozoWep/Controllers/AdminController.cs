﻿using BusnLogicVecozo;
using DALMSSQL;
using Microsoft.AspNetCore.Mvc;
using VecozoWep.Models;

namespace VecozoWep.Controllers
{
    public class AdminController : Controller
    {
        private MedewerkerContainer MC = new(new MedewerkerDAL());
        private VaardigheidContainer VC = new(new VaardigheidDAL());
        public IActionResult Index()
        {
            int? id = HttpContext.Session.GetInt32("UserId");
            if (id == null) return RedirectToAction("Login", "User");
            LeidinggevendenVM vm = new(MC.FindById(id.Value));
            vm.Medewerkers = MC.HaalAlleMedewerkersOp().Select(x => new MedewerkerVM(x)).ToList();
            foreach (MedewerkerVM m in vm.Medewerkers)
            {
                m.vaardigheden = VC.FindByMedewerker(m.UserID).Select(x => new VaardigheidVM(x)).ToList();
                    
            }
            return View(vm);
        }

        
        public IActionResult MedewerkerOverzicht()
        {
            return View();
        }
    }
}