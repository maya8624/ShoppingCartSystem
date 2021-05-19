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
        private MockTour _mockTour;
        private PromotionalRule _rule;
        private List<Tour> _tours;

        [SetUp]
        public void SetUp()
        {
            _deal = new Deal();
            _mockTour = new MockTour();
            _tours = _mockTour.GetTours();

            _rule = new PromotionalRule
            {
                Id = 0,
                TourId = "OH",
                MinToursForOneFree = 3
            };
        }

        [Test]
        [TestCase(3, 600)]
        [TestCase(7, 1500)]
        public void CalculateTotal_WhenCalled_CalculateFreeTickets_ReturnDiscountedTotalAmount(int tours, decimal expected)
        {
            // Arrange
            var tour = _tours.Single(t => t.Id == _rule.TourId);
            tour.SoldTours = tours;

            // Action 
            var result = _deal.CalculateTotal(_tours, _rule);

            // Assert
            // case 1: 3 / 3 = 1 -> 1 free ticket (3 - 1) * 300 -> return $600
            // -> TicketsSold: 3, TicketCountForOneFree: 3, Ticket price: $300
            // case 1: 7 / 3 = 2 -> 2 free ticket (7 - 2) * 300 -> return $1,500
            // -> TicketsSold: 7, TicketCountForOneFree: 3, Ticket price: $300            
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
