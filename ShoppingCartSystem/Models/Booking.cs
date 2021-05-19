using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartSystem.Models
{
    public class Booking
    {
        public string TourId { get; set; }        
        public decimal Price { get; set; }
        public int Count { get; set; }
        public decimal Amount { get; set; }
    }
}
