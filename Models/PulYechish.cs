using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiApp.Models
{
    public class PulYechish
    {
        public int Id { get; set; }

        [Required]
        public int HaydovchiId { get; set; }

        [ForeignKey("HaydovchiId")]
        public Haydovchi? Haydovchi { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Summa { get; set; }

        public string Holati { get; set; } = "Kutilmoqda";
        public DateTime YechishSana { get; set; } = DateTime.Now;
        public DateTime? TasdiqlanganSana { get; set; }
        public string Izoh { get; set; } = string.Empty;
    }
}
