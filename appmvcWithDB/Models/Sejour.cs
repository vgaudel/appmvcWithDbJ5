using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace appmvcWithDB.Models
{
    public class Sejour
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le lieu doit être rempli.")]
        public string Lieu { get; set; }
        [DisplayName("Téléphone")]
        [MaxLength(10,ErrorMessage = "Le numéro de Téléphone doit contenir exactement 10 chiffres")]
        [MinLength(10, ErrorMessage = "Le numéro de Téléphone doit contenir exactement 10 chiffres")]
        public string Telephone { get; set; }
    }
}
