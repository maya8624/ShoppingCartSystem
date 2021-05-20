using ShoppingCartSystem.Interfaces;
using ShoppingCartSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartSystem.Promotions
{
    public class Deal : IPromotion
    {
        private string _tourId;        
        public string TourId { set => _tourId = value; }

        private int _minToursForOneFree;        
        public int MinToursForOneFree { set => _minToursForOneFree = value; }

        public Deal(string tourId, int minToursForOneFree)
        {
            TourId = tourId;
            MinToursForOneFree = minToursForOneFree;
        }

        public decimal CalculateTotal(List<Booking> bookings)
        {
            decimal total = 0m;
            foreach (var booking in bookings)
            {
                if (booking.TourId == _tourId)                
                    booking.Amount -= (booking.Count / _minToursForOneFree) * booking.Price;
                
                total += booking.Amount;
            }
            return total;
        }
    }
}
