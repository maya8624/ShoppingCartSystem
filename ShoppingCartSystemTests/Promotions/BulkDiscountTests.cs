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
        public void CalculateTotal_WhenCalled_ReturnTotalAmountWithDiscountOrWithoutDiscount(int tours, decimal expected)
        {
            // Arrange
            var tour = _tours.Single(t => t.Id == _rule.TourId);
            tour.SoldTours = tours;

            // Action 
            var result = _bulkDiscount.CalculateTotal(_tours, _rule);

            // Assert
            // case 1: 110 * 3 = 330 -> tour price: $110, tours sold: 3
            // case 2: (110 - 20) * 5 = 450 -> tour price: $110, discount: $20, tours sold: 5
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
