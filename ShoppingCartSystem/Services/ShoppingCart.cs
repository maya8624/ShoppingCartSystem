using ShoppingCartSystem.Models;
using System.Linq;
using System.Collections.Generic;
using ShoppingCartSystem.Interfaces;
using ShoppingCartSystem.Promotions;

namespace ShoppingCartSystem.Services
{
    public class ShoppingCart
    {
        private readonly List<Booking> _bookings = new List<Booking>();
        private readonly MockBooking _mockBooking = new MockBooking();        
        private readonly IPromotion _promotion;

        public ShoppingCart(IPromotion promotion)
        {
            _bookings = _mockBooking.GetBookings();
            _promotion = promotion;   
        }

        public void Add(string tourId)
        {
            Booking booking = _bookings.First(b => b.TourId == tourId);
            booking.Amount += booking.Price;
            booking.Count++;
        }

        public decimal Total()
        {
            return _promotion.CalculateTotal(_bookings);                 
        }
    }
}
