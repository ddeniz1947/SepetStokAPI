using System;
using SepetStokProject.Entities;
using System.Collections.Generic;
using System.Text;

namespace SepetStokProject.DataAccess.Abstract
{
    public interface IProductsBasketDal:IRepository<ProductsBasket>
    {
        List<ProductsBasket> GetBasketDataById(int userId);
        bool AddProductByCount(ProductsBasket productsBasket);
        bool DeleteByProductId(int UserId,int ProductId , int ProductCountForDelete);
    }
}
