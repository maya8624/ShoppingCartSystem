using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartSystem.Models
{
    public class MockBooking
    {
        private readonly List<Booking> _bookings;

        public MockBooking()
        {
            _bookings = new List<Booking>()
            {
               new Booking { TourId = "OH", Price = 300.00m, Count = 0, Amount = 0},
               new Booking { TourId = "BC", Price = 110.00m, Count = 0, Amount = 0},
               new Booking { TourId = "SK", Price = 30.00m, Count = 0, Amount = 0}
            };
        }

        public List<Booking> GetBookings()
        {
            return _bookings;
        }
    }
}
