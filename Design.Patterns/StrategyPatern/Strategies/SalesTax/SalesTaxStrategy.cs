namespace Design.Patterns.StrategyPatern.Strategies.SalesTax
{
    public interface ISalesTaxStrategy
    {
       decimal GetTaxFor(Order order);
    }

    public class SweedenSalestaxStrategy : ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order)
        {
            return order.TotalPrice * 0.25m;
        }
    }

    public class UASSalestaxStrategy : ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order)
        {
            
            switch (order.ShippingDetails.DestinationState.ToLowerInvariant())
            {
                case "la": return order.TotalPrice * 0.095m;
                case "ny": return order.TotalPrice * 0.04m;
                case "nyc": return order.TotalPrice * 0.045m;
                default: return 0m;
            }
        }
    }
}


