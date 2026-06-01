using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiApp.Models
{
    public class HaydovchiDaromadi
    {
        public int Id { get; set; }

        [Required]
        public int HaydovchiId { get; set; }

        [ForeignKey("HaydovchiId")]
        public Haydovchi? Haydovchi { get; set; }

        public decimal BugunDaromad { get; set; } = 0;
        public decimal JamiDaromad { get; set; } = 0;
        public decimal YechilganPul { get; set; } = 0;
        public decimal HisobdagiPul { get; set; } = 0;
        public int YolovchiSoni { get; set; } = 0;
        public double Reyting { get; set; } = 5.0;
        public DateTime OxirigiYangilandi { get; set; } = DateTime.Now;
    }
}
