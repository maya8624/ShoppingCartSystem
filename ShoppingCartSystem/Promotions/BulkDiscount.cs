using ShoppingCartSystem.Interfaces;
using ShoppingCartSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartSystem.Promotions
{
    public class BulkDiscount : IPromotion
    {
        private decimal _discountPrice;
        public decimal DiscountPrice { set => _discountPrice = value; }

        private string _tourId;        
        public string TourId { set => _tourId = value; }

        private int _minToursForDiscount;        
        public int MinToursForDiscount { set => _minToursForDiscount = value; }

        public BulkDiscount() {}

        public BulkDiscount(string tourId, decimal discountPrice, int minToursForDiscount)
        {            
            TourId = tourId;
            DiscountPrice = discountPrice;
            MinToursForDiscount = minToursForDiscount;
        }

        public decimal CalculateTotal(List<Booking> bookings)
        {
            decimal total = 0m;
            foreach (var booking in bookings)
            {
                if (booking.TourId == _tourId && booking.Count >= _minToursForDiscount)
                    booking.Amount -= booking.Count * _discountPrice;                
                
                total += booking.Amount;
            }
            return total;
        }
    }
}
