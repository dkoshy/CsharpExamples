namespace App.DicountCalculator;

public class DiscountCalculator
{
    private readonly DiscountRuleEngine _discountRuleEngine;

    public DiscountCalculator()
    {
        _discountRuleEngine = new DiscountRuleEngine(new List<IDiscountRule>
        {
            new LoyalCustomerRule(),
            new FirstTimeCustimerRule(),
            new SeniorRule(),
            new VeteranRule(),
            new BirthdayRule(),
        });
    }

    public decimal CalculateDiscountPercentage(Customer customer)
    {
        return _discountRuleEngine.CalculateDiscountFromRules(customer);
    }

}
