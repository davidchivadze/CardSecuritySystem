using Domain.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class CurrencyTypeRepository
    {
        public CurrencyTypeRepository(Data database) : base(database)
        {

        }

        public IEnumerable<CurrencyType> GetCurrencyTypes()
        {
            return _database.CurrencyTypes;
        }
    }
}
