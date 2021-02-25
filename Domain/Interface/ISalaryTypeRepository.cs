using Domain.Repository;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface ISalaryTypeRepository:IBaseRepository<SalaryType>
    {
        IEnumerable<SalaryType> GetSalarieTypes();
        SalaryType AddSalaryType(SalaryType model);
        SalaryType EditSalaryType(SalaryType model);
    }
}
