using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;
using Models.EntityModels;

namespace Domain.Repository
{
    class DepartmentsRepository : BaseRepository<Departments>, IDepartmentsRepository
    {
        public DepartmentsRepository(Data database) : base(database)
        {

        }
    }
}
