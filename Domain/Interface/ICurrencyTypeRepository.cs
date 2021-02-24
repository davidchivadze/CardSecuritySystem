
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface ICurrencyTypeRepository:IBaseRepository<CurrencyType>
    {
        IEnumerable<CurrencyType> GetCurrencyTypes();

    }
}
