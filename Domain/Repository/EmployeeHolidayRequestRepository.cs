using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class EmployeeHolidayRequestRepository: BaseRepository<EmployeeHolidayRequest>, IEmployeeHolidayRequestRepository
    {
        public EmployeeHolidayRequestRepository(Data database) : base(database)
        {

        }

        public EmployeeHolidayRequest AddHolidayRequest(EmployeeHolidayRequest addModel)
        {
            var result = _database.EmployeeHolidayRequests.Add(addModel);
            _database.SaveChanges();
            return result;
        }

        public bool Delete(int holidayID)
        {
            var result = _database.EmployeeHolidayRequests.Where(m => m.ID == holidayID).FirstOrDefault();
            _database.EmployeeHolidayRequests.Remove(result);
            _database.SaveChanges();
            return true;
        }

        public IEnumerable<EmployeeHolidayRequest> GetHolidayRequestByEmployee(int? empID)
        {
            var result = _database.EmployeeHolidayRequests.Where(s => s.EmployeeID == (empID??s.EmployeeID));
            return result;
        }

        public EmployeeHolidayRequest UpdateHolidayRequest(EmployeeHolidayRequest holiday)
        {
            var result = _database.EmployeeHolidayRequests.FirstOrDefault(h => h.ID == holiday.ID);
            if (result != null)
            {
                
                result.EmployeeID = holiday.EmployeeID;
            
                result.HolidayTypeID = holiday.HolidayTypeID;
                result.FromDate = holiday.FromDate;
                result.ToDate = holiday.ToDate;
                result.AmountWorkDays = holiday.AmountWorkDays;
                _database.Entry(result).State = System.Data.Entity.EntityState.Modified;
                _database.SaveChanges();
            }
            return result;
        }
    }
}
