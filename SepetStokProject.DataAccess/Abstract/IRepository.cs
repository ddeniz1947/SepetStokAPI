using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SepetStokProject.DataAccess.Abstract
{
    public interface IRepository<T>
    {

        List<T> GetAll();
        void Add(T entity);
        void Delete(T entity);

    }
}
