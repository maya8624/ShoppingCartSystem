using ShoppingCartSystem.Interfaces;
using ShoppingCartSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCartSystem.Promotions
{
    public class FreeTour : IPromotion
    {
        private string _tourId;
        public string TourId { set => _tourId = value; }

        private string _freeTourId;
        public string FreeTourId { set => _freeTourId = value; }

        public decimal CalculateTotal(List<Booking> bookings)
        {
            var basicTour = bookings.Single(t => t.TourId == _tourId);
            var freeTour = bookings.Single(t => t.TourId == _freeTourId);

            decimal total = 0m;
            foreach (var booking in bookings)
            {
                if (booking.TourId == _tourId)
                    UpdateFreeTourSoldTours(basicTour, freeTour);
                
                total += booking.Amount;
            }
            return total;
        }

        private void UpdateFreeTourSoldTours(Booking basicTour, Booking freeTour)
        {
           if (freeTour.Count > 0)
                freeTour.Amount -= freeTour.Price * basicTour.Count;
            
        }
    }
}
