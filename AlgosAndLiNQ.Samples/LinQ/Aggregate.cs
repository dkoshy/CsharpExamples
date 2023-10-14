using LINQSamples;
using System.Numerics;

namespace AlgosAndLiNQ.Samples.LinQ
{
    public class Aggregate
    {
        private readonly List<Product> _prepo;

        public Aggregate()
        {
            _prepo =  ProductRepository.GetAll();
        }

        public int CountFilteredMethod()
        {
            return _prepo.Count(p => p.Color == "Read"); 
        }

        public decimal MinMethod()
        {
            var minvalue = _prepo.Min(p => p.ListPrice);

            return _prepo.Select(p => p.ListPrice).Min();
        }

        public decimal MaxMethod()
        {
            var minvalue = _prepo.Max(p => p.ListPrice);

            return _prepo.Select(p => p.ListPrice).Max();
        }


    }
}
