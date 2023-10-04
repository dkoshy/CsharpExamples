using LINQSamples;

namespace AlgosAndLiNQ.Samples.LinQ
{
    public  class PartitionDistinct
    {
        private readonly List<Product> _allProducts;

        public PartitionDistinct()
        {
            _allProducts =  ProductRepository.GetAll();
        }
        public List<Product> TakeMethod()
        {
            var products = _allProducts
                            .OrderBy(p =>  p.Name)
                            .Take(5).ToList();

            return products;
        }

        public List<Product> TakeRangeMethod()
        {
            return _allProducts.OrderBy(p => p.Name).Take(10..20).ToList();
        }

        public List<string> DistinctQuery()
        {
            return _allProducts.Select(p => p.Color)
                       .Distinct().Order().ToList();
        }

        public List<Product> DistinctByMethod()
        {
            return _allProducts.DistinctBy(p=>p.Color,default)
                        .OrderBy(p => p.Color).ToList();
        }
        public List<Product[]> ChunkMethod()
        {

            return _allProducts.Chunk(10).ToList();
        }
    }
}
