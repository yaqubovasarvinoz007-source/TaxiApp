using System;
using System.Collections.Generic;
using System.Linq;
using TaxiApp.Models;

namespace TaxiApp.Services
{
    public class BuyurtmaService
    {
        private readonly TaxiDbContext _context;

        public BuyurtmaService(TaxiDbContext context)
        {
            _context = context;
        }

        public List<Buyurtma> GetAllOrders()
        {
            return _context.Buyurtmalar.ToList();
        }

        public List<Buyurtma> GetDriverOrders(int driverId)
        {
            return _context.Buyurtmalar
                .Where(b => b.HaydovchiId == driverId)
                .ToList();
        }

        public List<Buyurtma> GetCustomerOrders(int customerId)
        {
            return _context.Buyurtmalar
                .Where(b => b.MijozId == customerId)
                .ToList();
        }

        public void CreateOrder(Buyurtma order)
        {
            _context.Buyurtmalar.Add(order);
            _context.SaveChanges();
        }

        public void CompleteOrder(int orderId)
        {
            var order = _context.Buyurtmalar.FirstOrDefault(b => b.Id == orderId);
            if (order != null)
            {
                _context.Buyurtmalar.Remove(order);
                _context.SaveChanges();
            }
        }
    }
}
