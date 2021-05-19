using ShoppingCartSystem.Models;
using System.Linq;
using System.Collections.Generic;
using ShoppingCartSystem.Interfaces;
using ShoppingCartSystem.Promotions;

namespace ShoppingCartSystem.Services
{
    public class ShoppingCart
    {
        private readonly List<Tour> _tours = new List<Tour>();
        private readonly MockTour _mockTour = new MockTour();
        private readonly PromotionalRule _rule;
        //private readonly IPromotionCalculator _calculator;

        public ShoppingCart(PromotionalRule rule)
        {
            _tours = _mockTour.GetTours();
            _rule = rule;
        }

        public void Add(string tourId)
        {
            Tour tour = _tours.First(t => t.Id == tourId);
            tour.SoldTours++;
        }

        public decimal Total()
        {               
            var result = new BulkDiscount();
            //var result = new Deal();
            //var result = new FreeTour();
            
            // call a method directly, need to write extra code to use dependency injection in console application            
            return result.CalculateTotal(_tours, _rule);

            // return _calculator.CalculateTotal(_tours, _rule);
        }
    }
}
