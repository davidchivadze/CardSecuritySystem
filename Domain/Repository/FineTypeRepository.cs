using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class FineTypeRepository:BaseRepository<FineType>,IFineTypeRepository
    {
        public FineTypeRepository(Data database):base(database)
        {

        }

        public FineType AddFineType(FineType model)
        {
            var result = _database.FineTypes.Add(model);
            _database.SaveChanges();
            return result;
        }

        public FineType EditFineType(FineType model)
        {
            var result = _database.FineTypes.Where(m => m.ID == model.ID).FirstOrDefault();
            result.Description = model.Description;
            _database.SaveChanges();
            return result;
        }

        public IEnumerable<FineType>GetFineTypes()
        {
            return _database.FineTypes;
        }
    }
}
