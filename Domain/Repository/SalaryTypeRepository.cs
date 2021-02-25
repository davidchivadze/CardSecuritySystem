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

        public SalaryType AddSalaryType(SalaryType model)
        {
            var result = _database.SalaryTypes.Add(model);
            _database.SaveChanges();
            return result;
        }

        public SalaryType EditSalaryType(SalaryType model)
        {
            var result = _database.SalaryTypes.Where(m => m.ID == model.ID).FirstOrDefault();
            result.Description = model.Description;
            _database.SaveChanges();
            return result;
        }

        public IEnumerable<SalaryType> GetSalarieTypes()
        {
            return _database.SalaryTypes;
        }
    }
}
