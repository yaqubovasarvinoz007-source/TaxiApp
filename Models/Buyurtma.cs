using System;
using System.ComponentModel.DataAnnotations;

namespace TaxiApp.Models
{
    public class Buyurtma
    {
        public int Id { get; set; }

        [Required]
        public int MijozId { get; set; }
        public Mijoz? Mijoz { get; set; }

        [Required]
        public int HaydovchiId { get; set; }
        public Haydovchi? Haydovchi { get; set; }

        [Required]
        public string Qayerdan { get; set; } = string.Empty;

        [Required]
        public string Qayerga { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public decimal Narx { get; set; }

        public DateTime Sana { get; set; } = DateTime.Now;
    }
}