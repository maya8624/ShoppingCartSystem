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
            var promotionRule = new PromotionalRule
            {
                Id = Convert.ToInt32(PromotionType.BulkDiscount),
                DiscountPrice = 20.00m,
                TourId = "BC",
                MinToursForDiscount = 5
            };

            var cart = new ShoppingCart(promotionRule);
            cart.Add("BC");
            cart.Add("BC");
            cart.Add("BC");
            cart.Add("BC");
            cart.Add("BC");

            decimal total = cart.Total();
        }
    }
}
