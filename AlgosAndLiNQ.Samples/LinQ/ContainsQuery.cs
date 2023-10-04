using LINQSamples;
using System.Linq;

namespace AlgosAndLiNQ.Samples.LinQ
{
    public class ContainsQuery
    {
        private readonly List<Product> _allProducts;
        private readonly List<SalesOrder> _sales;
        public ContainsQuery()
        {
            _allProducts = ProductRepository.GetAll();
            _sales = SalesOrderRepository.GetAll();
        }

        public bool CotainsMethod()
        {   
            ProductIdComparer pc = new ProductIdComparer();

            return _allProducts
                    .Contains(new Product { ProductID = 744 }, pc);
                       
        }

        public bool AnyMethod()
        {
            return _sales.Any(s => s.LineTotal  > 10000);
        }

    }
}
