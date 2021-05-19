using ShoppingCartSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartSystem.Interfaces
{
    public interface IPromotion
    {
        decimal CalculateTotal(List<Booking> bookings);
    }
}
