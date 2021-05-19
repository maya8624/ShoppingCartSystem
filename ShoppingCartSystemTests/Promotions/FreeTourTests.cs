using NUnit.Framework;
using ShoppingCartSystem.Models;
using ShoppingCartSystem.Promotions;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartSystemTests.Promotions
{
    public class FreeTourTests
    {
        private FreeTour _freeTour;
        private MockBooking _mockBooking;        
        private List<Booking> _bookings;

        [SetUp]
        public void SetUp()
        {
            _mockBooking = new MockBooking();
            _bookings = _mockBooking.GetBookings();

            _freeTour = new FreeTour
            { 
                TourId = "OH",
                FreeTourId = "SK",
            };
        }

        [Test]
        [TestCase(0, 1, 300)]
        [TestCase(1, 1, 300)]
        [TestCase(3, 2, 630)]
        public void CalculateTotal_WhenCalled_ReturnTotalAmountWithFreeTour(int freeCount, int basicCount, decimal expected)
        {
            // Arrange
            var basicTour = _bookings.Single(b => b.TourId == "OH");           
            basicTour.Count = basicCount;
            basicTour.Amount = basicTour.Price * basicCount;
            
            var freeTour = _bookings.Single(b => b.TourId == "SK");
            freeTour.Count = freeCount;
            freeTour.Amount = freeTour.Price * freeCount;

            // Action 
            var result = _freeTour.CalculateTotal(_bookings);

            // Assert
            // case 1: (0 - 1) = -1 return $300 -> SK tours sold: 0, OH tours sold: 1
            // case 2: (1 - 1) = 0 return $300 -> SK tours sold: 1, OH tours sold: 1
            // case 3: (3 - 2) = 1 return $630 -> SK tours sold: 3, OH tours sold: 2
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
