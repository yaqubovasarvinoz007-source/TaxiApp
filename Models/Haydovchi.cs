using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaxiApp.Models
{
    public class Haydovchi
    {
        public int Id { get; set; }

        [Required]
        public string Ismi { get; set; } = string.Empty;

        [Required]
        public string MashinaRaqami { get; set; } = string.Empty;

        // "Bo'sh" yoki "Band"
        public string Holati { get; set; } = "Bo'sh";

        public ICollection<Buyurtma> Buyurtmalar { get; set; } = new List<Buyurtma>();
    }
}