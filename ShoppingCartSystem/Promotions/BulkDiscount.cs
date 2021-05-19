using ShoppingCartSystem.Interfaces;
using ShoppingCartSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartSystem.Promotions
{
    public class BulkDiscount : IPromotionCalculator
    {
        public decimal CalculateTotal(List<Tour> tours, PromotionalRule rule)
        {
            decimal total = 0m;
            foreach (var tour in tours)
            {
                if (tour.Id == rule.TourId)
                    total += CalculateBulkDiscount(tour, rule);
                else
                    total += tour.SoldTours * tour.Price;
            }
            return total;
        }

        private decimal CalculateBulkDiscount(Tour tour, PromotionalRule rule)
        {
            if (tour.SoldTours >= rule.MinToursForDiscount)
                return ((tour.Price - rule.DiscountPrice) * tour.SoldTours);

            return tour.SoldTours * tour.Price;
        }
    }
}
