using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class GovernmentHolidaysRepository : BaseRepository<GovernmentHolidays>, IGovernmentHolidaysRepository
    {
        public GovernmentHolidaysRepository(Data database) : base(database)
        {

        }

        public GovernmentHolidays AddGHoliday(GovernmentHolidays addGHoliday)
        {
            var result = _database.GovernmentHolidays.Add(addGHoliday);
            _database.SaveChanges();
            return result;
        }

        public bool Delete(int gHolidayID)
        {
            var result = _database.GovernmentHolidays.Where(m => m.ID == gHolidayID).FirstOrDefault();
            _database.GovernmentHolidays.Remove(result);
            _database.SaveChanges();
            return true;
        }

        public IEnumerable<GovernmentHolidays> GetGovernmentHolidays()
        {
            return _database.GovernmentHolidays;
        }

        public GovernmentHolidays UpdateGHoliday(GovernmentHolidays gHoliday)
        {
            var result = _database.GovernmentHolidays.FirstOrDefault(h => h.ID == gHoliday.ID);
            if (result != null)
            {
                result.Description = gHoliday.Description;
                result.HolidayDate = gHoliday.HolidayDate;
                _database.Entry(result).State = System.Data.Entity.EntityState.Modified;
                _database.SaveChanges();
            }
            return result;
        }
    }
}
