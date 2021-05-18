using ShoppingCartSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartSystem.Interfaces
{
    public interface IPromotionCalculator
    {
        decimal CalculateTotalAmount(List<Tour> tours);
    }
}
