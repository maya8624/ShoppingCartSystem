using NUnit.Framework;
using ShoppingCartSystem.Models;
using ShoppingCartSystem.Promotions;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartSystemTests.Promotions
{
    public class DealTests
    {
        private Deal _deal;
        private MockBooking _mockBooking;
        private List<Booking> _bookings;

        [SetUp]
        public void SetUp()
        {
            _mockBooking = new MockBooking();
            _bookings = _mockBooking.GetBookings();
            _deal = new Deal
            {
                TourId = "OH",
                MinToursForOneFree = 3
            };
        }

        [Test]
        [TestCase(3, 600)]
        [TestCase(7, 1500)]
        public void CalculateTotal_WhenCalled_CalculateFreeTours_ReturnDiscountedTotalAmount(int count, decimal expected)
        {
            // Arrange
            var booking = _bookings.Single(b => b.TourId == "OH");
            booking.Amount = booking.Price * count;
            booking.Count = count;

            // Action 
            var result = _deal.CalculateTotal(_bookings);

            // Assert
            // case 1: 3 / 3 = 1 -> 1 free tour -> (3 - 1) * 300 -> return $600
            // -> tours sold: 3, minium tours for one free: 3, tour price: $300
            // case 1: 7 / 3 = 2 -> 2 free tours (7 - 2) * 300 -> return $1,500
            // -> tours sold: 7, minium tours for one free: 3, tour price: $300            
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
