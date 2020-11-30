using SepetStokProject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SepetStokProject.DataAccess.Concrete.EFCore
{
    public class ShopContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=ShopDbCicekSepeti;integrated security=true;");
        }
        public DbSet<ProductsBasket> ProductsBaskets { get; set; }
        public DbSet<StockClass> stockClasses { get; set; }
    }
}
