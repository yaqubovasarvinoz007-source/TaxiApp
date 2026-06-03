using System;

namespace TaxiApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public string Role { get; set; } = "User"; // "Admin" yoki "Driver"
        public int? HaydovchiId { get; set; } // Haydovchi uchun
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation Property
        public Haydovchi? Haydovchi { get; set; }
    }
}
