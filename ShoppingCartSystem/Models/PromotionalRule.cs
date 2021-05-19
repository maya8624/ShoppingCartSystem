using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartSystem.Models
{
    public class PromotionalRule
    {
        public int Id { get; set; }        
        public decimal DiscountPrice { get; set; }
        public string TourId { get; set; }
        public string FreeTourId { get; set; }
        public int MinToursForOneFree { get; set; }
        public int MinToursForDiscount { get; set; }
    }
}
