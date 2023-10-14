using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSamples.DataLayer.CompositeClasses
{
    public class ProductBySize
    {
        public int  Size { get; set; }
        public int  TotalProductWitSize { get; set; }
        public ProductByColor ProductByColor { get; set; }
     }

    public class ProductByColor
    {

        public string Color { get; set; }
        public int  NumberOfProductsWithColor  { get; set; }
        public List<Product> Products { get; set; }
    }
}
