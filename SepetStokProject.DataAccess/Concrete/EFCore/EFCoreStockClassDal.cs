using SepetStokProject.DataAccess.Abstract;
using SepetStokProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SepetStokProject.DataAccess.Concrete.EFCore
{
    public class EFCoreStockClassDal : EFCoreGenericRepository<StockClass, ShopContext>, IStockClassDal
    {
        public StockClass GetStockByProductId(int productId)
        {
            using(var context = new ShopContext())
            {
                return context.stockClasses.FirstOrDefault(x => x.ProductId == productId);
            }
        }
        public bool AddStockByProductId(int ProductId, int StockCount)
        {
            StockClass stockModel = new StockClass();
            using (var context = new ShopContext())
            {
                var stockAddModel = context.stockClasses.FirstOrDefault(x => x.ProductId == ProductId);
                if(stockAddModel != null)
                {
                    int stockAddCount = stockAddModel.StockCount + StockCount;
                    stockAddModel.StockCount = stockAddCount;
                    context.Update(stockAddModel);
                    context.SaveChanges();

                }
                else
                {
                    stockModel.ProductId = ProductId;
                    stockModel.StockCount = StockCount;
                    context.stockClasses.Add(stockModel);
                    context.SaveChanges();
                }
                return true;
            }

        }
    }
}
