using System;
using System.Collections.Generic;
using System.Text;

namespace SepetStokProject.Entities
{
    public class ProductsBasket
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int UserID { get; set; }


    }
}
