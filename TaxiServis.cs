using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TaxiApp.Models;

namespace TaxiApp
{
    /// <summary>
    /// Ma'lumotlar bazasi bilan ishlash uchun barcha business logic shu yerda.
    /// Har bir metod o'z DbContext instansini yaratadi va to'g'ri yopadi.
    /// </summary>
    public class TaxiServis
    {
        // ─────────────────────────────────────────────
        // HAYDOVCHILAR
        // ─────────────────────────────────────────────

        public List<Haydovchi> BarchaHaydovchilarniOlish()
        {
            using var db = new TaxiDbContext();
            return db.Haydovchilar.AsNoTracking().ToList();
        }

        public List<Haydovchi> BoshHaydovchilarniOlish()
        {
            using var db = new TaxiDbContext();
            return db.Haydovchilar
                .AsNoTracking()
                .Where(h => h.Holati == "Bo'sh")
                .ToList();
        }

        public void HaydovchiQoshish(string ism, string mashinaRaqami)
        {
            if (string.IsNullOrWhiteSpace(ism) || string.IsNullOrWhiteSpace(mashinaRaqami))
                throw new ArgumentException("Ism va mashina raqami bo'sh bo'lishi mumkin emas.");

            using var db = new TaxiDbContext();
            db.Haydovchilar.Add(new Haydovchi
            {
                Ismi = ism.Trim(),
                MashinaRaqami = mashinaRaqami.Trim().ToUpper(),
                Holati = "Bo'sh"
            });
            db.SaveChanges();
        }

        public void HaydovchiYangilash(int id, string ism, string mashinaRaqami)
        {
            if (string.IsNullOrWhiteSpace(ism) || string.IsNullOrWhiteSpace(mashinaRaqami))
                throw new ArgumentException("Maydonlar bo'sh bo'lishi mumkin emas.");

            using var db = new TaxiDbContext();
            var h = db.Haydovchilar.Find(id)
                ?? throw new InvalidOperationException($"ID={id} haydovchi topilmadi.");

            h.Ismi = ism.Trim();
            h.MashinaRaqami = mashinaRaqami.Trim().ToUpper();
            db.SaveChanges();
        }

        public void HaydovchiOchirish(int id)
        {
            using var db = new TaxiDbContext();
            var h = db.Haydovchilar.Find(id);
            if (h == null) return;

            // Bog'liq buyurtmalar borligini tekshirish
            bool buyurtmasiBor = db.Buyurtmalar.Any(b => b.HaydovchiId == id);
            if (buyurtmasiBor)
                throw new InvalidOperationException("Bu haydovchining buyurtmalari mavjud. Avval buyurtmalarni o'chiring.");

            db.Haydovchilar.Remove(h);
            db.SaveChanges();
        }

        public void HaydovchiHolatiYangilash(int id, string holat)
        {
            using var db = new TaxiDbContext();
            var h = db.Haydovchilar.Find(id);
            if (h == null) return;
            h.Holati = holat;
            db.SaveChanges();
        }

        // ─────────────────────────────────────────────
        // MIJOZLAR
        // ─────────────────────────────────────────────

        public List<Mijoz> BarchaMijozlarniOlish()
        {
            using var db = new TaxiDbContext();
            return db.Mijozlar.AsNoTracking().ToList();
        }

        public void MijozQoshish(string ism, string telefon)
        {
            if (string.IsNullOrWhiteSpace(ism) || string.IsNullOrWhiteSpace(telefon))
                throw new ArgumentException("Ism va telefon bo'sh bo'lishi mumkin emas.");

            using var db = new TaxiDbContext();
            db.Mijozlar.Add(new Mijoz
            {
                Ismi = ism.Trim(),
                Telefon = telefon.Trim()
            });
            db.SaveChanges();
        }

        public void MijozYangilash(int id, string ism, string telefon)
        {
            if (string.IsNullOrWhiteSpace(ism) || string.IsNullOrWhiteSpace(telefon))
                throw new ArgumentException("Maydonlar bo'sh bo'lishi mumkin emas.");

            using var db = new TaxiDbContext();
            var m = db.Mijozlar.Find(id)
                ?? throw new InvalidOperationException($"ID={id} mijoz topilmadi.");

            m.Ismi = ism.Trim();
            m.Telefon = telefon.Trim();
            db.SaveChanges();
        }

        public void MijozOchirish(int id)
        {
            using var db = new TaxiDbContext();
            var m = db.Mijozlar.Find(id);
            if (m == null) return;

            bool buyurtmasiBor = db.Buyurtmalar.Any(b => b.MijozId == id);
            if (buyurtmasiBor)
                throw new InvalidOperationException("Bu mijozning buyurtmalari mavjud. Avval buyurtmalarni o'chiring.");

            db.Mijozlar.Remove(m);
            db.SaveChanges();
        }

        // ─────────────────────────────────────────────
        // BUYURTMALAR
        // ─────────────────────────────────────────────

        public List<Buyurtma> BarchaBuyurtmalarniOlish()
        {
            using var db = new TaxiDbContext();
            return db.Buyurtmalar
                .Include(b => b.Mijoz)
                .Include(b => b.Haydovchi)
                .AsNoTracking()
                .OrderByDescending(b => b.Sana)
                .ToList();
        }

        public void BuyurtmaYaratish(int mijozId, int haydovchiId,
            string qayerdan, string qayerga, decimal narx)
        {
            if (string.IsNullOrWhiteSpace(qayerdan) || string.IsNullOrWhiteSpace(qayerga))
                throw new ArgumentException("Manzillar bo'sh bo'lishi mumkin emas.");
            if (narx <= 0)
                throw new ArgumentException("Narx musbat son bo'lishi kerak.");

            using var db = new TaxiDbContext();

            // Haydovchi haqiqatan bo'sh ekanligini tekshirish
            var haydovchi = db.Haydovchilar.Find(haydovchiId)
                ?? throw new InvalidOperationException("Haydovchi topilmadi.");

            if (haydovchi.Holati != "Bo'sh")
                throw new InvalidOperationException($"{haydovchi.Ismi} hozir band.");

            db.Buyurtmalar.Add(new Buyurtma
            {
                MijozId = mijozId,
                HaydovchiId = haydovchiId,
                Qayerdan = qayerdan.Trim(),
                Qayerga = qayerga.Trim(),
                Narx = narx,
                Sana = DateTime.Now
            });

            haydovchi.Holati = "Band";
            db.SaveChanges();
        }

        public void BuyurtmaOchirish(int id)
        {
            using var db = new TaxiDbContext();
            var b = db.Buyurtmalar.Find(id);
            if (b == null) return;
            db.Buyurtmalar.Remove(b);
            db.SaveChanges();
        }

        // ─────────────────────────────────────────────
        // STATISTIKA
        // ─────────────────────────────────────────────

        public decimal KunlikTushum()
        {
            using var db = new TaxiDbContext();
            return db.Buyurtmalar
                .Where(b => b.Sana.Date == DateTime.Today)
                .Sum(b => (decimal?)b.Narx) ?? 0m;
        }

        public decimal JamiTushum()
        {
            using var db = new TaxiDbContext();
            return db.Buyurtmalar.Sum(b => (decimal?)b.Narx) ?? 0m;
        }

        public string EngFaolHaydovchi()
        {
            using var db = new TaxiDbContext();
            return db.Buyurtmalar
                .GroupBy(b => b.Haydovchi!.Ismi)
                .OrderByDescending(g => g.Count())
                .Select(g => $"{g.Key} ({g.Count()} ta)")
                .FirstOrDefault() ?? "Ma'lumot yo'q";
        }

        public string EngFaolMijoz()
        {
            using var db = new TaxiDbContext();
            return db.Buyurtmalar
                .GroupBy(b => b.Mijoz!.Ismi)
                .OrderByDescending(g => g.Count())
                .Select(g => $"{g.Key} ({g.Count()} marta)")
                .FirstOrDefault() ?? "Ma'lumot yo'q";
        }

        public int JamiHaydovchilar()
        {
            using var db = new TaxiDbContext();
            return db.Haydovchilar.Count();
        }

        public int BoshHaydovchilarSoni()
        {
            using var db = new TaxiDbContext();
            return db.Haydovchilar.Count(h => h.Holati == "Bo'sh");
        }

        public int JamiMijozlar()
        {
            using var db = new TaxiDbContext();
            return db.Mijozlar.Count();
        }

        public int JamiBuyurtmalar()
        {
            using var db = new TaxiDbContext();
            return db.Buyurtmalar.Count();
        }
    }
}