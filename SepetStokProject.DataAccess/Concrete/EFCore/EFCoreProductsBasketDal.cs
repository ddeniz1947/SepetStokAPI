using SepetStokProject.DataAccess.Abstract;
using SepetStokProject.DataAccess.Concrete.EFCore;
using SepetStokProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SepetStokProject.DataAccess.Concrete.EFCore
{
    public class EFCoreProductsBasketDal : EFCoreGenericRepository<ProductsBasket, ShopContext>, IProductsBasketDal
    {

        public bool AddProductByCount(ProductsBasket productsBasket)
        {
            ProductsBasket addModel = new ProductsBasket();
            using (var context = new ShopContext())
            {
                addModel = context.ProductsBaskets.FirstOrDefault(x => (x.UserID == productsBasket.UserID && x.ProductId == productsBasket.ProductId));
                var stockModel = context.stockClasses.FirstOrDefault(x => (x.ProductId == productsBasket.ProductId));
               
                if(stockModel != null)
                {

                    int stockControlModel = stockModel.StockCount - productsBasket.ProductCount;
                    if (stockControlModel >= 0)
                    {
                        if (addModel != null)
                        {
                            int addModelCount = addModel.ProductCount;
                            if (stockControlModel >= 0)
                            {
                                addModel.ProductCount = addModelCount + productsBasket.ProductCount;
                                context.ProductsBaskets.Update(addModel);
                                stockModel.StockCount = stockControlModel;
                                context.stockClasses.Update(stockModel);
                                context.SaveChanges();
                                return true;
                            }
                            else
                            {
                                return false;
                            }


                        }
                        else
                        {
                            if (stockControlModel >= 0)
                            {
                                context.ProductsBaskets.Add(productsBasket);
                                stockModel.StockCount = stockControlModel;
                                context.stockClasses.Update(stockModel);
                                context.SaveChanges();
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
              
                

            }
        }
        public List<ProductsBasket> GetBasketDataById(int userId)
        {
            using (var context = new ShopContext())
            {
                return context.ProductsBaskets.Where(x => x.UserID == userId).ToList();
            }
        }
        public bool DeleteByProductId(int UserId, int ProductId, int ProductCountForDelete)
        {
            ProductsBasket productsBasket = new ProductsBasket();
            using (var context = new ShopContext())
            {
                productsBasket = context.ProductsBaskets.Where(x => (x.UserID == UserId && x.ProductId == ProductId)).FirstOrDefault();
                 var stockModel = context.stockClasses.FirstOrDefault(x => x.ProductId == ProductId);
                if(productsBasket != null)
                {
                  
                    if (productsBasket.ProductCount - ProductCountForDelete <= 0)
                    {
                        context.ProductsBaskets.Remove(productsBasket);
                        if(stockModel != null)
                        {
                            int stockCount = stockModel.StockCount + productsBasket.ProductCount;
                            stockModel.StockCount = stockCount;
                            context.stockClasses.Update(stockModel);
                        }
                       
                        context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        int dummyCount = productsBasket.ProductCount;
                        productsBasket.ProductCount = dummyCount - ProductCountForDelete;
                        context.ProductsBaskets.Update(productsBasket);
                        if (stockModel != null)
                        {
                            int stockCount = stockModel.StockCount + ProductCountForDelete;
                            stockModel.StockCount = stockCount;
                            context.stockClasses.Update(stockModel);
                        }

                        context.SaveChanges();
                        return true;
                    }
                }
                else
                {
                    return false;
                }
              

            }
        }

     

    }
}
