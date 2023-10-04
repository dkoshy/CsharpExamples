using LINQSamples;

namespace AlgosAndLiNQ.Samples.LinQ
{
    public class JoinOperations
    {
        private readonly List<Product> _allProducts;
        private readonly List<SalesOrder> _allSales;

        public JoinOperations()
        {
            _allProducts = ProductRepository.GetAll();
            _allSales = SalesOrderRepository.GetAll();
        }

        public List<ProductOrder> InnerJoinMethod()
        {
            return _allProducts.Join(_allSales
                        , p => p.ProductID
                        , s => s.ProductID
                        , (p, s) => new ProductOrder
                        {
                            ProductID = p.ProductID,
                            Name = p.Name,
                            Color = p.Color,
                            StandardCost = p.StandardCost,
                            ListPrice = p.ListPrice,
                            Size = p.Size,
                            SalesOrderID = s.SalesOrderID,
                            OrderQty = s.OrderQty,
                            UnitPrice = s.UnitPrice,
                            LineTotal = s.LineTotal
                        }).OrderBy(p => p.Name).ToList();


        }
        public List<ProductOrder> InnerJoinTwoFieldsMethod()
        {

            return _allProducts.Join(_allSales
                , p => new { p.ProductID, Qty = (short)6 }
                , s => new { s.ProductID, Qty = s.OrderQty }
                , (p, s) => new ProductOrder
                {
                    ProductID = p.ProductID,
                    Name = p.Name,
                    Color = p.Color,
                    StandardCost = p.StandardCost,
                    ListPrice = p.ListPrice,
                    Size = p.Size,
                    SalesOrderID = s.SalesOrderID,
                    OrderQty = s.OrderQty,
                    UnitPrice = s.UnitPrice,
                    LineTotal = s.LineTotal
                })
                .OrderBy(p => p.Name).ToList();
        }

        /// <summary>
        /// Use 'into' to create a new object with a Sales collection for each Product
        /// This is like a combination of an inner join and left outer join
        /// The GroupJoin() method replaces the into keyword
        /// </summary>
        public List<ProductSales> JoinIntoMethod()
        {
            return _allProducts.GroupJoin(_allSales
                    , p => p.ProductID
                    , s => s.ProductID
                    , (product, salesData) => new ProductSales
                    {
                        Product = product,
                        Sales = salesData.OrderBy(s => s.SalesOrderID).ToList()
                    })
                    .OrderBy(ps => ps.Product.ProductID).ToList();
        }

        /// <summary>
        /// Leftouter join using selectmany()
        /// </summary>
        /// <returns></returns>
        public List<ProductOrder> LeftOuterJoinMethod()
        {
            return _allProducts.SelectMany(
                product => _allSales.Where(s => s.ProductID == product.ProductID).DefaultIfEmpty()
                , (p, s) => new ProductOrder
                {
                    ProductID = p.ProductID,
                    Name = p.Name,
                    Color = p.Color,
                    StandardCost = p.StandardCost,
                    ListPrice = p.ListPrice,
                    Size = p.Size,
                    SalesOrderID = s?.SalesOrderID,  // Use the null-conditional operator
                    OrderQty = s?.OrderQty,
                    UnitPrice = s?.UnitPrice,
                    LineTotal = s?.LineTotal
                }).OrderBy(p => p.Name).ToList();

        }
    }
}
