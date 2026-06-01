using System;
using System.Collections.Generic;
using System.Linq;
using TaxiApp.Models;

namespace TaxiApp.Services
{
    public class DaromadService
    {
        private readonly TaxiDbContext _context;

        public DaromadService(TaxiDbContext context)
        {
            _context = context;
        }

        public HaydovchiDaromadi? GetEarnings(int driverId)
        {
            return _context.HaydovchiDaromadilar
                .FirstOrDefault(hd => hd.HaydovchiId == driverId);
        }

        public void AddEarning(int driverId, decimal amount)
        {
            var earnings = GetEarnings(driverId) ?? new HaydovchiDaromadi { HaydovchiId = driverId };
            
            earnings.BugunDaromad += amount;
            earnings.JamiDaromad += amount;
            earnings.HisobdagiPul += amount;
            earnings.OxirigiYangilandi = DateTime.Now;

            if (earnings.Id == 0)
                _context.HaydovchiDaromadilar.Add(earnings);
            
            _context.SaveChanges();
        }

        public void WithdrawMoney(int driverId, decimal amount)
        {
            var earnings = GetEarnings(driverId);
            if (earnings != null && earnings.HisobdagiPul >= amount)
            {
                earnings.HisobdagiPul -= amount;
                earnings.OxirigiYangilandi = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public void ResetDailyEarnings(int driverId)
        {
            var earnings = GetEarnings(driverId);
            if (earnings != null)
            {
                earnings.BugunDaromad = 0;
                earnings.YolovchiSoni = 0;
                earnings.OxirigiYangilandi = DateTime.Now;
                _context.SaveChanges();
            }
        }
    }
}
