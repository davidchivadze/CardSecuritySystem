using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class CurrencyTypeRespository:BaseRepository<CurrencyType>, ICurrencyTypeRepository
    {
        public CurrencyTypeRespository(Data database) : base(database)
        {

        }

        //public IEnumerable<CurrencyType> GetCurrencyTypes()
        //{
        //    return _database.CurrencyTypes;
        //}

    }
}
