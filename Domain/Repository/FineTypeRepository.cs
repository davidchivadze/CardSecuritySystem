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

        public IEnumerable<FineType>GetFineTypes()
        {
            return _database.FineTypes;
        }
    }
}
