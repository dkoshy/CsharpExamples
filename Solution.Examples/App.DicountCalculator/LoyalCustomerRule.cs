namespace App.DicountCalculator;

public class LoyalCustomerRule : IDiscountRule
{
    public LoyalCustomerRule()
    {
    }

    public decimal CalculateDiscount(Customer customer)
    {
        if (customer.DateOfFirstPurchase.HasValue)
        {
            if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-15))
            {
              return .15m;
            }
            else if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-10))
            {
               return .12m;
            }
            else if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-5))
            {

                return .10m;
            }
            else if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-2))
            {

                return .08m;
            }
            else if (customer.DateOfFirstPurchase.Value < DateTime.Now.AddYears(-1))
            {
                return .05m;
            }
            else
            {
                return 0m;
            }
            
        }
        return 0m;
    }
}