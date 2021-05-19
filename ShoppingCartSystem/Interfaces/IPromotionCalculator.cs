using ShoppingCartSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartSystem.Interfaces
{
    public interface IPromotionCalculator
    {
        decimal CalculateTotal(List<Tour> tours, PromotionalRule rule);
    }
}
