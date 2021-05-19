# ShoppingCartSystem
- Assume already got a list of tour records and added a SoldTours property to the list.

- Classes
1. ShoppingCart
  -> Add(tour): update SoldTours Property, increase 1 when a tour added
  -> Total: call CalculateTotal() method to calculate correct total price and return it

2. BulkDiscount
  -> calculate the total price by Bulk Discount rules.

3. Deal
  -> calculate the total price by three for tow deal rules
  
4. FreeTour
  -> calculate the total price using free tour rules

5. Tour
  -> modele class which has properties for tour
  
6. PromotionalRule 
  -> model class has properties for rules
  
- Interfaces
1. IPromotionCalculator  
  -> CalculateTotal(List<Tour> tours, PromotionalRule rule) : Promotion classes should implement details of this method.
  -> Assume only one promotion available in the certain period so, only one promotion class should have a relationship with this interface.
-> If we need to add a new promotion, create a new class and implement CalculateTotal(List<Tour> tours, PromotionalRule rule) method
    
 - Unit tests
 1. BuldDiscountTests, DealTests, FreeTourTests classes
 2. All tests passed. Please have a look at "test-result.png" file on the root.
 
 - To sum up, I need much more time than 2 hours becaues I really didn't want leave this as kind of messy and incomplete. 
 However, I'm happy with the outcome even though I'm sure much better solution out there. 
 
 Thanks,
 
