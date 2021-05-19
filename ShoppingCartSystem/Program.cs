using ShoppingCartSystem.Enums;
using ShoppingCartSystem.Interfaces;
using ShoppingCartSystem.Models;
using ShoppingCartSystem.Services;
using System;

namespace ShoppingCartSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 1. Bulk discount rules
            var promotionRule = new PromotionalRule
            {
                Id = Convert.ToInt32(PromotionType.BulkDiscount),
                DiscountPrice = 20.00m,
                TourId = "BC",
                MinToursForDiscount = 5
            };

            // 2. Three for two deal rules
            //var promotionRule = new PromotionalRule
            //{
            //    Id = Convert.ToInt32(PromotionType.Deal),
            //    TourId = "OH",
            //    MinToursForOneFree = 3
            //};

            // 3. Free tour rules
            //var promotionRule = new PromotionalRule
            //{
            //    Id = Convert.ToInt32(PromotionType.FreeTour),
            //    TourId = "OH",
            //    FreeTourId = "SK",                
            //};

            var cart = new ShoppingCart(promotionRule);

            // 1. Bulk discount -> return $750
            cart.Add("BC");
            cart.Add("BC");
            cart.Add("BC");
            cart.Add("BC");
            cart.Add("BC");
            cart.Add("OH");

            // 2. Three for two deal -> return $710
            //cart.Add("OH");
            //cart.Add("OH");
            //cart.Add("OH");
            //cart.Add("BC");

            // 3. Free tour -> return $300
            //cart.Add("OH");
            //cart.Add("SK");

            Console.WriteLine($"Total: ${cart.Total()}");
        }
    }
}
