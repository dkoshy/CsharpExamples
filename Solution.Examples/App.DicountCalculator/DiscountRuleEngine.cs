namespace App.DicountCalculator;

public class DiscountRuleEngine
{
    private readonly List<IDiscountRule> _discountRules;

    public DiscountRuleEngine(List<IDiscountRule> discountRules)
    {
        _discountRules = discountRules ?? throw new ArgumentNullException(nameof(discountRules));
    }

    public decimal CalculateDiscountFromRules(Customer customer)
    {
        var discount = 0m;
        foreach (var rule in _discountRules)
        {
            discount = Math.Max(discount, rule.CalculateDiscount(customer));
            IDiscountRule.CurrentDiscount = discount;
        }
        return discount;
    }
}
