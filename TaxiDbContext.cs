using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using TaxiApp.Models;

namespace TaxiApp
{
    public class TaxiDbContext : DbContext
    {
        public DbSet<Haydovchi> Haydovchilar { get; set; } = null!;
        public DbSet<Mijoz> Mijozlar { get; set; } = null!;
        public DbSet<Buyurtma> Buyurtmalar { get; set; } = null!;
        public DbSet<HaydovchiDaromadi> HaydovchiDaromadilar { get; set; } = null!;
        public DbSet<MijozSharhı> MijozSharhlari { get; set; } = null!;
        public DbSet<PulYechish> PulYechishlari { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string appDataPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "TaxiApp");

            Directory.CreateDirectory(appDataPath);

            string dbPath = Path.Combine(appDataPath, "taxi.db");
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Buyurtma <-> Mijoz
            modelBuilder.Entity<Buyurtma>()
                .HasOne(b => b.Mijoz)
                .WithMany(m => m.Buyurtmalar)
                .HasForeignKey(b => b.MijozId)
                .OnDelete(DeleteBehavior.Restrict);

            // Buyurtma <-> Haydovchi
            modelBuilder.Entity<Buyurtma>()
                .HasOne(b => b.Haydovchi)
                .WithMany(h => h.Buyurtmalar)
                .HasForeignKey(b => b.HaydovchiId)
                .OnDelete(DeleteBehavior.Restrict);

            // HaydovchiDaromadi <-> Haydovchi
            modelBuilder.Entity<HaydovchiDaromadi>()
                .HasOne(hd => hd.Haydovchi)
                .WithMany()
                .HasForeignKey(hd => hd.HaydovchiId)
                .OnDelete(DeleteBehavior.Cascade);

            // MijozSharhı <-> Haydovchi
            modelBuilder.Entity<MijozSharhı>()
                .HasOne(ms => ms.Haydovchi)
                .WithMany()
                .HasForeignKey(ms => ms.HaydovchiId)
                .OnDelete(DeleteBehavior.Cascade);

            // MijozSharhı <-> Mijoz
            modelBuilder.Entity<MijozSharhı>()
                .HasOne(ms => ms.Mijoz)
                .WithMany()
                .HasForeignKey(ms => ms.MijozId)
                .OnDelete(DeleteBehavior.Cascade);

            // PulYechish <-> Haydovchi
            modelBuilder.Entity<PulYechish>()
                .HasOne(py => py.Haydovchi)
                .WithMany()
                .HasForeignKey(py => py.HaydovchiId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
