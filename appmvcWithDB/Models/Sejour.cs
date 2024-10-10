using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace appmvcWithDB.Models
{
    public class Sejour
    {
        public int Id { get; set; }
        [Required]
        public string Lieu { get; set; }
        [DisplayName("Téléphone")]
        [MaxLength(10)]
        [MinLength(10)]
        public string Telephone { get; set; }
    }
}
