using ShoppingCartSystem.Interfaces;
using ShoppingCartSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartSystem.Promotions
{
    public class Deal : IPromotionCalculator
    {
        public decimal CalculateTotal(List<Tour> tours, PromotionalRule rule)
        {
            decimal total = 0m;
            foreach (var tour in tours)
            {
                if (tour.Id == rule.TourId)
                    total += CalculateDealDiscount(tour, rule);
                else
                    total += tour.SoldTours * tour.Price;
            }
            return total;
        }

        private decimal CalculateDealDiscount(Tour tour, PromotionalRule rule)
        {
            int freeTours = tour.SoldTours / rule.MinToursForOneFree;
            return (tour.SoldTours - freeTours) * tour.Price;
        }
    }
}
