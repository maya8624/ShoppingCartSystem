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
                    UpdateFreeTourSoldTours(basicTour, freeTour);
                
                total += tour.SoldTours * tour.Price;
            }
            return total;
        }

        private void UpdateFreeTourSoldTours(Tour basicTour, Tour freeTour)
        {
            int freeTours = freeTour.SoldTours - basicTour.SoldTours;
            if (freeTours > 0)
                freeTour.SoldTours = freeTours;
            else
                freeTour.SoldTours = 0;
        }
    }
}
