using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> Get();
        T Update(T entity);
        T Add(T entity);
    }
}
