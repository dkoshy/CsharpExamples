namespace App.DicountCalculator;

public class SeniorRule : IDiscountRule
{
    public decimal CalculateDiscount(Customer customer)
    {
        if (customer.DateOfBirth < DateTime.Now.AddYears(-65))
        {
            return .05m;
        }
        return 0;
    }
}