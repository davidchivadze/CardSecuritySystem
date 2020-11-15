using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class EmployeeMobileNumbersRepository : BaseRepository<EmployeeMobileNumbers>, IEmployeeMobileNumbersRepository
    {
        public EmployeeMobileNumbersRepository(Data database) : base (database)
        {
               
        }
    }
}
