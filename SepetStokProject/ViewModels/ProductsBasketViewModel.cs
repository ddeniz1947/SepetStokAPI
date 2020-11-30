using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SepetStokProject.API.ViewModels
{
    public class ProductsBasketViewModel
    {
        public string Name { get; set; }
        public string imageurl { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public int Userid { get; set; }
        public int productid { get; set; }
        public int productcount { get; set; }
    }
}
