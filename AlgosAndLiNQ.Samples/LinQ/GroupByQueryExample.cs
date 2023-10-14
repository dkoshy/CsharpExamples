using LINQSamples;
using System.Net.NetworkInformation;

namespace AlgosAndLiNQ.Samples.LinQ
{
    public class GroupByQueryExample
    {
        private readonly List<Product> _repo;
        private readonly List<SalesOrder> _srepo;

        public GroupByQueryExample()
        {
            _repo = ProductRepository.GetAll();
            _srepo = SalesOrderRepository.GetAll();
        }

        public void  GroupByMethod()
        {

            var interResult = _repo.GroupBy(p => p.Size)
                   .Select(g => new
                   {
                       g.Key,
                       count = g.Count(),
                       productsGroup = g.GroupBy(p => p.Color)
                   });

          var result =  interResult.SelectMany(gp => gp.productsGroup,
                    (gp, p) =>
                    new
                    {
                        Size = gp.Key,
                        Total = gp.count,
                        Color = p.Key,
                        productCountWithSameColor = p.Count(),
                        products = p.ToList()
                    }).OrderBy(g => g.Size)
                      .ThenBy(g => g.Color);
                    
        }

        public List<IGrouping<string,Product>> GroupByWhereMethod() 
        {
            return _repo.GroupBy(p => p.Size)
                       .Where(s => s.Count() > 2)
                       .ToList();

        }

        public List<SaleProducts> GroupBySubQueryMethod()
        {
            return _srepo.OrderBy(s => s.SalesOrderID)
                    .GroupBy(p => p.SalesOrderID)
                    .Select(newSales => new SaleProducts
                    {
                        SalesOrderID=newSales.Key,
                        Products = _repo
                                    .OrderBy(p => p.ProductID)
                                    .Join(newSales
                                    , p => p.ProductID
                                    , s => s.ProductID
                                    , (prod, ssale) => prod)
                                    .ToList()
                    }).ToList();
        }

        public List<string?> GroupByDistinctMethod()
        {
            return _repo.GroupBy(p => p.Color)
                 .Select(groupedColor => groupedColor.FirstOrDefault()?.Color)
                 .Order().ToList();
        }
    }
}
