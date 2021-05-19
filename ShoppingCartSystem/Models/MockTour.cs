using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCartSystem.Models
{
    public class MockTour
    {
        private readonly List<Tour> _tours;

        public MockTour()
        {
            _tours = new List<Tour>()
            {
               new Tour { Id = "OH", Name="OPera house tour", Price = 300.00m, SoldTours = 0},
               new Tour { Id = "BC", Name="Sydney Bridge Climb", Price = 110.00m, SoldTours = 0},
               new Tour { Id = "SK", Name="Sydney Sky Tower", Price = 30.00m, SoldTours = 0}
            };
        }

        public List<Tour> GetTours()
        {
            return _tours;
        }
    }
}
