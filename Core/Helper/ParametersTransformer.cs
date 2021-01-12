using Models.EntityModels;
using Models.ViewModels.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helper
{
    public static class ParametersTransformer
    {
        public static GetGenderListItem AsViewModel(this Gender model)
        {
            return new GetGenderListItem()
            {
                ID = model.ID,
                Description = model.Description
            };
        }
        public static GetDepartmentsListItem AsViewModel(this Departments model)
        {
            return new GetDepartmentsListItem()
            {
                ID = model.ID,
                Description = model.Description
            };
        }
        public static GetBranchListItem AsViewModel(this Branch model)
        {
            return new GetBranchListItem()
            {
                ID = model.ID,
                Description = model.BranchName
            };
        }
        public static GetEmployeePositionsListItem AsViewModel(this EmployeePosition model)
        {
            return new GetEmployeePositionsListItem()
            {
                ID = model.ID,
                Description = model.Description
            };
        }
        public static GetCountryListItem AsViewModel(this Country model)
        {
            return new GetCountryListItem
            {
                ID = model.ID,
                Description = model.Description
            };
        }
        public static GetCitiesListItem AsViewModel(this City model)
        {
            return new GetCitiesListItem
            {
                ID = model.ID,
                Description = model.Description
            };
        }
        public static GetSalaryTypeListItem AsViewModel(this SalaryType model)
        {
            return new GetSalaryTypeListItem()
            {
                ID = model.ID,
                Description = model.Description
            };
        }
    }
}
