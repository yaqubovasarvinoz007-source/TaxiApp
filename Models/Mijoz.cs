using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaxiApp.Models
{
    public class Mijoz
    {
        public int Id { get; set; }

        [Required]
        public string Ismi { get; set; } = string.Empty;

        [Required]
        public string Telefon { get; set; } = string.Empty;

        public ICollection<Buyurtma> Buyurtmalar { get; set; } = new List<Buyurtma>();
    }
}