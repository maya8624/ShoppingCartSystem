using ShoppingCartSystem.Interfaces;
using ShoppingCartSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCartSystem.Promotions
{
    public class FreeTour : IPromotionCalculator
    {
        public decimal CalculateTotal(List<Tour> tours, PromotionalRule rule)
        {
            var basicTour = tours.Single(t => t.Id == rule.TourId);
            var freeTour = tours.Single(t => t.Id == rule.FreeTourId);

            decimal total = 0m;
            foreach (var tour in tours)
            {
                if (tour.Id == rule.TourId)
                    total += CalculateFreeTourDiscount(basicTour, freeTour);
                else
                    total += tour.SoldTours * tour.Price;
            }
            return total;
        }

        private decimal CalculateFreeTourDiscount(Tour basicTour, Tour freeTour)
        {
            int freeTours = freeTour.SoldTours - basicTour.SoldTours;
            return freeTours >= 0 ? freeTours * freeTour.Price : 0;
        }
    }
}
