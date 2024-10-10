using appmvcWithDB.Models;
using appmvcWithDB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace appmvcWithDB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Sejour sejour = new Sejour { Lieu = "Chambord", Telephone = "11111111" };

            HomeViewModel hvm = new HomeViewModel
            {
                Message = "Bonjour tout le monde",
                Date = DateTime.Now,
                Sejour = sejour
            };

            return View(hvm);
        }
    }
}
