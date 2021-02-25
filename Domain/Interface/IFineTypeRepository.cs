using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IFineTypeRepository:IBaseRepository<FineType>
    {
        IEnumerable<FineType> GetFineTypes();
        FineType AddFineType(FineType model);
        FineType EditFineType(FineType model);
    }
}
