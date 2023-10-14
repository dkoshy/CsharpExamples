using LINQSamples;
using System.Xml;

namespace AlgosAndLiNQ.Samples.LinQ
{
    public class Comparison
    {
        private readonly List<Product> _allproducts;
        private readonly List<SalesOrder> _allsales;


        public Comparison()
        {
            _allproducts = ProductRepository.GetAll();
            _allsales = SalesOrderRepository.GetAll();
        }


        public bool CompareTwoSeequence()
        {
            var arr1 = new int[] { 1, 2, 3 };
            var arr2 = new int[] { 1, 2, 3 };

            return arr1.SequenceEqual(arr2);
        }

        public bool CompareProducts()
        {
            ProductComparer pc = new ProductComparer();
            var p1 = _allproducts;
            var p2 = _allproducts;

            return p1.SequenceEqual(p2 , pc);
        }

        /// <summary>
        /// Find all values in one list that are not in the other list
        /// </summary>
        public List<int> ExceptIntegersQuery()
        {
            List<int> list1 = new () { 5, 2, 3, 4, 5 };
             // Create a list of numbers
            List<int> list2 = new() { 3, 4, 5 };

            //All elements in list1 but not in list2
            return list2.Except(list1).ToList();
        }

        /// <summary>
        /// Find all productid that is not sold.
        /// </summary>
        /// <returns></returns>
        public List<int> ExceptProductSalesQuery()
        {
            return _allproducts.Select(p => p.ProductID)
                    .Except(_allsales.Select(s=>s.ProductID)).ToList();
        }

        public List<Product> ExceptUsingComparerQuery()
        {
            ProductComparer pc = new ProductComparer();
            var list1 = _allproducts;
            var list2 = ProductRepository.GetAll();

            list2.RemoveAll(p => p.Color == "Black");

            return list1.Except(list2, pc).ToList();
        }

        public List<Product> ExceptByMethod()
        {
            ProductComparer pc = new ProductComparer();
            var list1 = _allproducts;
            var colors = new List<string>{"Black","White" };

            return list1.ExceptBy(colors, p => p.Color).ToList();
        }

        public List <Product> ExceptByProductSalesMethod()
        {
            
            return _allproducts
                .ExceptBy<Product, int>(_allsales.Select(s=>s.ProductID), p=>p.ProductID)
                .ToList();
        }

        public List<int> IntersectIntegersQuery()
        {
            return _allproducts.Select(p=> p.ProductID)
                       .Intersect(_allsales.Select(s=> s.ProductID))
                       .ToList();
        }

        public List<Product> IntersectByQuery()
        {
            return _allproducts
                .IntersectBy(new List<string> { "Black" , "White"},p=>p.Color)
                .ToList() ;
        }

        public List<Product> IntersectByProduct()



        {
            var list1 = _allproducts;
            var list2 = ProductRepository.GetAll();
            var colors = new List<string>{ "Black" , "White"};

            list2.RemoveAll(p => colors.Contains(p.Color));

            return list1.IntersectBy(list2,p=>p,new ProductComparer())
                .ToList();
        }

        public List<Product> IntersectByProductSalesMethod()
        {
            return _allproducts
                .IntersectBy(_allsales.Select(s=>s.ProductID) , p=>p.ProductID)
                .ToList();
        }
        /// <summary>
        /// Combines two list and avoid duplicates.
        /// </summary>
        /// <returns></returns>
        public List<Product> UnionMethod()
        {
            var list1 = _allproducts;
            var list2 = ProductRepository.GetAll();

            list2.RemoveAll(p =>
                                new List<string> { "Black", "White" }
                               .Contains(p.Color)
                            );

            return list1.Union(list2,new ProductComparer())
                   .ToList();  
                  
        }
        /// <summary>
        /// Union based on a spefic parameter.
        /// </summary>
        /// <returns></returns>
        public List<Product> UnionByMethod()
        {
            var list1 = _allproducts;
            var list2 = ProductRepository.GetAll();

            return list1.UnionBy(list1,l=>l.Color)
                    .ToList();
        }

        //Conncat can be used combine two list together.

    }
}
