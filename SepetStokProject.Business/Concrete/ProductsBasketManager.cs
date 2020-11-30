using SepetStokProject.Business.Abstract;
using SepetStokProject.DataAccess.Abstract;
using SepetStokProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SepetStokProject.Business.Concrete
{
    public class ProductsBasketManager : IProductsBasketService
    {
        private IProductsBasketDal _productsBasketDal;

        public ProductsBasketManager(IProductsBasketDal productsBasketDal)
        {
            _productsBasketDal = productsBasketDal;
        }

        public bool AddProductByCount(ProductsBasket entity)
        {
            return(_productsBasketDal.AddProductByCount(entity));
        }


        public bool DeleteByProductId(int UserId, int ProductId, int ProductCountForDelete)
        {
          return  _productsBasketDal.DeleteByProductId(UserId, ProductId, ProductCountForDelete);
        }

        public List<ProductsBasket> GetAll()
        {
           return _productsBasketDal.GetAll();
        }
        public List<ProductsBasket> GetBasketDataByUserId(int id)
        {
            return _productsBasketDal.GetBasketDataById(id);
        }
    }
}
