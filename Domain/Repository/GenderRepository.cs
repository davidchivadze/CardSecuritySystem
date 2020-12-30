using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class GenderRepository : BaseRepository<Gender>, IGenderRepository
    {
        public GenderRepository(Data database) : base(database)
        {

        }

        public IEnumerable<Gender> GetGenders()
        {
            return _database.Genders;
        }
    }
}
