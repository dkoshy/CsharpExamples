namespace App.DicountCalculator;

public class BirthdayRule : IDiscountRule
{
    public BirthdayRule()
    {
    }
    public decimal CalculateDiscount(Customer customer)
    {
        var isBirthday = customer.DateOfBirth.HasValue &&
                        customer.DateOfBirth.Value.Month == DateTime.Now.Month &&
                        customer.DateOfBirth.Value.Day == DateTime.Now.Day;
        if (isBirthday)
        {
             return IDiscountRule.CurrentDiscount + 0.10m;
        }
        return IDiscountRule.CurrentDiscount;
    }
}