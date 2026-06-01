using System;
using System.Collections.Generic;
using System.Linq;
using TaxiApp.Models;

namespace TaxiApp.Services
{
    public class HaydovchiService
    {
        private readonly TaxiDbContext _context;

        public HaydovchiService(TaxiDbContext context)
        {
            _context = context;
        }

        public List<Haydovchi> GetAllDrivers()
        {
            return _context.Haydovchilar.ToList();
        }

        public Haydovchi? GetDriverById(int id)
        {
            return _context.Haydovchilar.FirstOrDefault(h => h.Id == id);
        }

        public HaydovchiDaromadi? GetDriverEarnings(int driverId)
        {
            return _context.HaydovchiDaromadilar
                .FirstOrDefault(hd => hd.HaydovchiId == driverId);
        }

        public void UpdateDriverStatus(int driverId, string status)
        {
            var driver = GetDriverById(driverId);
            if (driver != null)
            {
                driver.Holati = status;
                _context.SaveChanges();
            }
        }

        public void AddDriver(Haydovchi haydovchi)
        {
            _context.Haydovchilar.Add(haydovchi);
            _context.SaveChanges();
        }

        public void DeleteDriver(int id)
        {
            var driver = GetDriverById(id);
            if (driver != null)
            {
                _context.Haydovchilar.Remove(driver);
                _context.SaveChanges();
            }
        }
    }
}
