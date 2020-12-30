using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;
using Models.EntityModels;

namespace Domain.Repository
{
    public class DepartmentsRepository : BaseRepository<Departments>, IDepartmentsRepository
    {
        public DepartmentsRepository(Data database) : base(database)
        {

        }

        public IEnumerable<Departments> GetDepartments()
        {
            return _database.Departments;
        }
    }
}
