using Domain.Repository;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IForgivenessTypeRepository:IBaseRepository<ForgivenessType>
    {
        IEnumerable<ForgivenessType> GetForgivenessTypes();

    }
}
