using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartSystem.Models
{
    public class PromotionalRule
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public decimal DiscountPrice { get; set; }
        public string TourId { get; set; }
        public int NumberOfToursForOneFree { get; set; }
        public int NumberOfToursForDiscount { get; set; }
    }
}
