using System.Collections.Generic;
using System.Linq;

namespace appmvcWithDB.Models
{
    public class Dal : IDal
    {
        private BddContext _bddContext;
        public Dal()
        {
            _bddContext = new BddContext();
        }

        public void DeleteCreateDatabase()
        {
            _bddContext.Database.EnsureDeleted();
            _bddContext.Database.EnsureCreated();
        }

        public List<Sejour> ObtientTousLesSejours()
        {
            return _bddContext.Sejours.ToList();
        }

        public void Dispose()
        {
            _bddContext.Dispose();
        }

        public int CreerSejour(string lieu, string telephone)
        {
            Sejour sejour = new Sejour() { Lieu = lieu, Telephone = telephone };
            _bddContext.Sejours.Add(sejour);
            _bddContext.SaveChanges();
            return sejour.Id;
        }
    }
}
