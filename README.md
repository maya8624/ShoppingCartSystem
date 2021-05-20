# Shopping Cart System
- Assume already got a list of tour records and only one special available in the certain period.

- Classes
1. ShoppingCart
  -> Add(tour): update Booking Count Property, increase 1 when a tour added and Amount property according to Count (Count * Price)
  -> Total: call CalculateTotal() method to calculate correct total price and return it

2. BulkDiscount
  -> calculate the total price by Bulk Discount rules.

3. Deal
  -> calculate the total price by three for tow deal rules
  
4. FreeTour
  -> calculate the total price by free tour rules

5. Booking
  -> modele class which has properties for Booking
    
- Interfaces
1. IPromotion
  -> CalculateTotal(List<Booking> bookings) method: Promotion classes should implement details of this method.  
    
 - Unit tests using NUnit
 1. BuldDiscountTests, DealTests, FreeTourTests classes
 2. All tests passed. Please have a look at "test-result.png" file on the root.
 
 Thanks,
 
