using SepetStokProject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SepetStokProject.DataAccess.Abstract
{
    public interface IStockClassDal:IRepository<StockClass>
    {
        StockClass GetStockByProductId(int productId);
        bool AddStockByProductId(int ProductId, int StockCount);
    }
}
