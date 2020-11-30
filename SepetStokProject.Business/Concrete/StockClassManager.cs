using SepetStokProject.Business.Abstract;
using SepetStokProject.DataAccess.Abstract;
using SepetStokProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SepetStokProject.Business.Concrete
{
    public class StockClassManager:IStockClassService
    {
        private IStockClassDal _stockClassDal;

        public StockClassManager(IStockClassDal stockClassDal)
        {
            _stockClassDal = stockClassDal;
        }
        public List<StockClass> GetAll()
        {
            return _stockClassDal.GetAll();
        }

        public StockClass GetStockByProductId(int productId)
        {
            return _stockClassDal.GetStockByProductId(productId);
        }

        public bool AddStockByProductId(int ProductId, int StockCount)
        {
           return _stockClassDal.AddStockByProductId(ProductId, StockCount);
        }
    }
}
