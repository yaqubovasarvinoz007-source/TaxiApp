using System;
using System.Collections.Generic;
using System.Linq;
using TaxiApp.Models;

namespace TaxiApp.Services
{
    public class ReviewService
    {
        private readonly TaxiDbContext _context;

        public ReviewService(TaxiDbContext context)
        {
            _context = context;
        }

        public List<MijozSharhı> GetDriverReviews(int driverId)
        {
            return _context.MijozSharhlari
                .Where(ms => ms.HaydovchiId == driverId)
                .ToList();
        }

        public double GetAverageRating(int driverId)
        {
            var reviews = GetDriverReviews(driverId);
            return reviews.Count > 0 ? reviews.Average(r => r.Reyting) : 5.0;
        }

        public void AddReview(MijozSharhı review)
        {
            _context.MijozSharhlari.Add(review);
            _context.SaveChanges();
        }

        public int GetTotalReviews(int driverId)
        {
            return _context.MijozSharhlari
                .Count(ms => ms.HaydovchiId == driverId);
        }
    }
}
