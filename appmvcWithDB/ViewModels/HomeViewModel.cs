using appmvcWithDB.Models;
using System;

namespace appmvcWithDB.ViewModels
{
    public class HomeViewModel
    {
        public string Message { get; set; }
        public DateTime Date { get; set; }
        public Sejour Sejour { get; set; }
    }
}
