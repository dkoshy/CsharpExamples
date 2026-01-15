namespace App.DicountCalculator;

public class VeteranRule : IDiscountRule
{
    public decimal CalculateDiscount(Customer customer)
    {
        if (customer.IsVeteran)
        {
            return .10m;
        }
        return 0;
    }
}