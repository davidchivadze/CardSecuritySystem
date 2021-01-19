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

        public IEnumerable<ForgivenessType> GetForgivenessTypes()
        {
            return _database.ForgivenessTypes;
        }

    }
}
