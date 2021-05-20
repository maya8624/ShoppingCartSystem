using NUnit.Framework;
using ShoppingCartSystem.Models;
using ShoppingCartSystem.Promotions;
using System.Collections.Generic;
using System.Linq;
using System;

namespace ShoppingCartSystemTests.Promotions
{
    public class BulkDiscountTests
    {
        private BulkDiscount _bulkDiscount;
        private MockBooking _mockBooking;        
        private List<Booking> _bookings;

        [SetUp]
        public void SetUp()
        {
            _mockBooking = new MockBooking();
            _bookings = _mockBooking.GetBookings();
            _bulkDiscount = new BulkDiscount
            {
                DiscountPrice = 20.00m,
                TourId = "BC",
                MinToursForDiscount = 5
            };
        }

        [Test]
        [TestCase(3, 330)]
        [TestCase(5, 450)]
        public void CalculateTotal_WhenCalled_ReturnTotalAmountWithDiscountOrWithoutDiscount(int count, decimal expected)
        {
            // Arrange
            var booking = _bookings.Single(b => b.TourId == "BC");
            booking.Amount = booking.Price * count;
            booking.Count = count;

            // Action 
            var result = _bulkDiscount.CalculateTotal(_bookings);

            // Assert
            // case 1: 110 * 3 = 330 -> tour price: $110, tours sold: 3
            // case 2: (5 * 20) - 550 = 450 -> tour price: $110, discount: $20, tours sold: 5
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
