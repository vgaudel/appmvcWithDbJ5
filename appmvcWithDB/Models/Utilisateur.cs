using System.ComponentModel.DataAnnotations;

namespace appmvcWithDB.Models
{
    public class Utilisateur
    {
        public int Id { get; set; }
        [MaxLength(25)]
        public string Prenom { get; set; }
    }
}
