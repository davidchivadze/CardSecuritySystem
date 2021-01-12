using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class SalaryTypeRepository : BaseRepository<SalaryType>, ISalaryTypeRepository
    {
        public SalaryTypeRepository(Data database) : base(database)
        {
        }


        public IEnumerable<SalaryType> GetSalarieTypes()
        {
            return _database.SalaryTypes;
        }
    }
}
