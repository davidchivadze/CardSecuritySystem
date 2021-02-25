using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class HolidayTypesRepository : BaseRepository<HolidayType>, IHolidayTypesRepository
    {
        public HolidayTypesRepository(Data database) : base(database)
        {
        }

        public HolidayType AddHolidayTypes(HolidayType model)
        {
            var result=_database.HolidayTypes.Add(model);
            _database.SaveChanges();
            return result;
        }


        public HolidayType EditHolidayTypes(HolidayType model)
        {
            var result = _database.HolidayTypes.Where(m=>m.ID==model.ID).FirstOrDefault();
            result.Description = model.Description;
         
            _database.SaveChanges();
            return result;
        }

        public IEnumerable<HolidayType> GetHolidayTypes()
        {
            return _database.HolidayTypes;
        }
    }
}
