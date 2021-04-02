using Models.EntityModels;
using Models.ViewModels.Employee;
using Models.ViewModels.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Helper
{
    public static class EmployeeTransformer
    {
        public static GetEmployeeHolidayListItem AsViewModel(this EmployeeHolidays model)
        {
            return new GetEmployeeHolidayListItem
            {
                ID = model.ID,

                AllWritten = model.AllWritten,
                Used = model.Used,
                Left = model.Left,
                NumInYear = model.NumInYear,
                LeftInYear = model.LeftInYear,
                DeactivateDate = model.DeactivateDate,
                IsActive = model.IsActive,
                EmployeeID = model.EmployeeID
            };
        }
        public static EmployeeHolidays AsDatabaseModel(this Models.ViewModels.EmployeeHolidays model)
        {
            return new EmployeeHolidays()
            {
                AllWritten = model.AllWritten,
                DeactivateDate = model.DeactivateDate,
                HolidayTypeID = model.HolidayTypeID,
                IsActive = model.IsActive,
                Left = model.Left,
                LeftInYear = model.LeftInYear,
                NumInYear = model.NumInYear,
                Used = model.Used,

            };
        }

    }
}
