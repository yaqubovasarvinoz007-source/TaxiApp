using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiApp.Models
{
    public class MijozSharhı
    {
        public int Id { get; set; }

        [Required]
        public int HaydovchiId { get; set; }

        [ForeignKey("HaydovchiId")]
        public Haydovchi? Haydovchi { get; set; }

        [Required]
        public int MijozId { get; set; }

        [ForeignKey("MijozId")]
        public Mijoz? Mijoz { get; set; }

        [Range(1, 5)]
        public int Reyting { get; set; } = 5;

        [MaxLength(500)]
        public string Sharh { get; set; } = string.Empty;

        public DateTime Sana { get; set; } = DateTime.Now;
    }
}
