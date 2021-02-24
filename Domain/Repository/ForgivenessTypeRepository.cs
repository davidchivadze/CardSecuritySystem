using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class ForgivenessTypeRepository:BaseRepository<ForgivenessType>, IForgivenessTypeRepository
    {
        public ForgivenessTypeRepository(Data database) : base(database)
        {

        }

        public ForgivenessType AddForgivenessType(ForgivenessType model)
        {
            var result= _database.ForgivenessTypes.Add(model);
            _database.SaveChanges();
            return result;
        }

        public ForgivenessType EditForgivenessType(ForgivenessType model)
        {
            var result = _database.ForgivenessTypes.Where(m => m.ID == model.ID).FirstOrDefault();
            result.Description = model.Description;
            _database.SaveChanges();
            return result;
        }

        public IEnumerable<ForgivenessType> GetForgivenessTypes()
        {
            return _database.ForgivenessTypes;
        }

    }
}
