using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(Data database) : base(database)
        {
                
        }

        public IEnumerable<Country> GetCountries()
        {
            return _database.Countries;
        }
    }
}
