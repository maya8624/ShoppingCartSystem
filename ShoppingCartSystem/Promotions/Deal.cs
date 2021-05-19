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

        public decimal CalculateTotal(List<Booking> bookings)
        {
            decimal total = 0m;
            foreach (var booking in bookings)
            {
                if (booking.TourId == _tourId)
                    CalculateDealDiscount(booking);
                
                total += booking.Amount;
            }
            return total;
        }

        private void CalculateDealDiscount(Booking booking)
        {
            int freeTours = booking.Count / _minToursForOneFree;
            booking.Amount -= freeTours * booking.Price;
        }
    }
}
