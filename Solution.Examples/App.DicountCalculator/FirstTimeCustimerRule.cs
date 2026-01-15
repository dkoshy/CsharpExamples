namespace App.DicountCalculator;

public class FirstTimeCustimerRule : IDiscountRule
{
    public FirstTimeCustimerRule()
    {
    }

    public decimal CalculateDiscount(Customer customer)
    {
        if (!customer.DateOfFirstPurchase.HasValue)
        {
            return .15m;
        }
        return 0m;
    }
}
