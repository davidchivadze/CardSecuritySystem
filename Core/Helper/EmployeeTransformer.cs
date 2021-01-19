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
                Name=model.Name,
                AllWritten=model.AllWritten,
                Used=model.Used,
                Left=model.Left,
                NumInYear=model.NumInYear,
                LeftInYear=model.LeftInYear,
                DeactivateDate=model.DeactivateDate,
                IsActive=model.IsActive,
                EmployeeID=model.EmployeeID
            };
        }
        
    }
}
