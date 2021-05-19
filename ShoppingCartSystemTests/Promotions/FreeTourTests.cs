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
        private MockTour _mockTour;
        private PromotionalRule _rule;
        private List<Tour> _tours;

        [SetUp]
        public void SetUp()
        {
            _freeTour = new FreeTour();
            _mockTour = new MockTour();
            _tours = _mockTour.GetTours();

            _rule = new PromotionalRule
            {
                Id = 0,
                TourId = "OH",
                FreeTourId = "SK",
            };
        }

        [Test]
        [TestCase(0, 1, 300)]
        [TestCase(1, 1, 300)]
        [TestCase(3, 2, 630)]
        public void CalculateTotal_WhenCalled_ReturnTotalAmountWithFreeTour(int freeTours, int soldTours, decimal expected)
        {
            // Arrange
            var basicTour = _tours.Single(t => t.Id == _rule.TourId);           
            basicTour.SoldTours = soldTours;

            var freeTour = _tours.Single(t => t.Id == _rule.FreeTourId);
            freeTour.SoldTours = freeTours;

            // Action 
            var result = _freeTour.CalculateTotal(_tours, _rule);

            // Assert
            // case 1: (0 - 1) = -1 return $300 -> SK tours sold: 0, OH tours sold: 1
            // case 2: (1 - 1) = 0 return $300 -> SK tours sold: 1, OH tours sold: 1
            // case 3: (3 - 2) = 1 return $630 -> SK tours sold: 3, OH tours sold: 2
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
