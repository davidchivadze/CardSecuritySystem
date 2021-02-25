using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IDepartmentsRepository : IBaseRepository<Departments>
    {
        IEnumerable<Departments> GetDepartments();
        Departments AddDepartment(Departments model);
        Departments EditDepartment(Departments model);
    }
}
