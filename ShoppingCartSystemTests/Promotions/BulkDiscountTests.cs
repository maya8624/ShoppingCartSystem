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
        private MockTour _mockTour;
        private PromotionalRule _rule;
        private List<Tour> _tours;

        [SetUp]
        public void SetUp()
        {
            _bulkDiscount = new BulkDiscount();
            _mockTour = new MockTour();
            _tours = _mockTour.GetTours();
                             
            _rule = new PromotionalRule
            {
                Id = 0,
                DiscountPrice = 20.00m,
                TourId = "BC",
                MinToursForDiscount = 5
            };
        }

        [Test]
        [TestCase(3, 330)]
        [TestCase(5, 450)]
        public void CalculateTotal_WhenCalled_ReturnTotalAmountWithDiscountOrWithoutDiscount(int tickets, decimal expected)
        {
            // Arrange
            var tour = _tours.Single(t => t.Id == _rule.TourId);
            tour.SoldTours = tickets;

            // Action 
            var result = _bulkDiscount.CalculateTotal(_tours, _rule);

            // Assert
            // case 1: 110 * 3 = 330 -> Ticket price: $110, TicketsSold: 3
            // case 2: (110 - 20) * 5 = 450 -> Ticket price: $110, Discount: $20, TicketsSold: 5
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
