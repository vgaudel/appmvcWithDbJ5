using appmvcWithDB.Models;
using appmvcWithDB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace appmvcWithDB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Dal myDal = new Dal();

            Sejour sejour = myDal.ObtientTousLesSejours().FirstOrDefault(sejour => sejour.Lieu=="Quimper");
            HomeViewModel myHVM = new HomeViewModel() { Message = "Let's go !", Date = DateTime.Now, Sejour = sejour};

            return View(myHVM);
        }

        public IActionResult ModifierSejour(int id)
        {
            if (id > 0)
            {
                Dal dal = new Dal();
                Sejour sejour = dal.ObtientTousLesSejours().FirstOrDefault(sejour => sejour.Id == id);
                if (sejour != null)
                {
                    return View(sejour);
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                return View("Error");
            }
        }
        [HttpPost]
        public IActionResult ModifierSejour(int id,string Lieu, string Telephone)
        {
            if (id > 0)
            {
                Dal dal = new Dal();
                
                dal.ModifierSejour(id, Lieu, Telephone);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }
    }
}
