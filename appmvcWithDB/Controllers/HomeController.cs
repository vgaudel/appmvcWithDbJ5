using appmvcWithDB.Models;
using appmvcWithDB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace appmvcWithDB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(int id)
        {
            Dal myDal = new Dal();

            Sejour sejour = myDal.ObtientTousLesSejours().FirstOrDefault(sejour => sejour.Id==id);
            HomeViewModel myHVM = new HomeViewModel() { Message = "Let's go !", Date = DateTime.Now, Sejour = sejour};

            if (sejour != null)
            {
                return View(myHVM);
            }
            else
            {
                return View("Error");
            }
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
        public IActionResult ModifierSejour(Sejour sejour)
        {
            if (!ModelState.IsValid)
            {
                return View(sejour);
            }  

            if (sejour.Id > 0)
            {
                Dal dal = new Dal();
                
                dal.ModifierSejour(sejour.Id, sejour.Lieu, sejour.Telephone);
                return RedirectToAction("Index", new { @id = sejour.Id });
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult ListeTuto()
        {
            return View();
        }

    }
}
