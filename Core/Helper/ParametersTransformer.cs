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

        public static ForgivenessType AsDatabaseModel(this AddForgivenessTypeRequest model)
        {
            return new ForgivenessType()
            {
                Description = model.Description
            };
        }
        public static ForgivenessType AsDatabaseModel(this EditForgivenessTypeRequest model)
        {
            return new ForgivenessType()
            {
                Description = model.Description
                ,
                ID = model.ID
            };
        }
        public static Departments AsDatabaseModel(this AddDepartmentRequest model)
        {
            return new Departments()
            {
                Description = model.Description
            };
        }
        public static Departments AsDatabaseModel(this EditDepartmentRequest model)
        {
            return new Departments()
            {
                Description = model.Description
                ,
                ID = model.ID
            };
        }
        public static GetDeviceTypeListItem AsViewModel(this DeviceType model)
        {
            return new GetDeviceTypeListItem()
            {
                ID = model.ID,
                Description = model.Description
            };
        }
        public static GetDeviceLocationInBranchListItem AsViewModel(this DeviceLocationInBranch model)
        {
            return new GetDeviceLocationInBranchListItem()
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
        public static GetFineTypeListItem AsViewModel(this FineType model)
        {
            return new GetFineTypeListItem()
            {
                ID = model.ID,
                Description = model.Description
            };
        }
        public static GetForgivenessTypeListItem AsViewModel(this ForgivenessType model)
        {
            return new GetForgivenessTypeListItem()
            {
                ID = model.ID,
                Description = model.Description
            };
        }
        public static GetCurrencyTypeListItem AsViewModel(this CurrencyType model)
        {
            return new GetCurrencyTypeListItem()
            {
                ID = model.ID,
                Description = model.Description
            };
        }
        public static SalaryType AsDatabaseModel(this AddSalaryTypeRequest model)
        {
            return new SalaryType()
            {
                Description = model.Description
            };
        }
        public static SalaryType AsDatabaseModel(this EditSalaryTypeRequest model)
        {
            return new SalaryType()
            {
                Description = model.Description
                ,
                ID = model.ID
            };
        }
        public static EmployeePosition AsDatabaseModel(this AddEmployeePositionRequest model)
        {
            return new EmployeePosition()
            {
                Description = model.Description
            };
        }
        public static EmployeePosition AsDatabaseModel(this EditEmployeePositionRequest model)
        {
            return new EmployeePosition()
            {
                Description = model.Description
                ,
                ID = model.ID
            };
        }
        public static FineType AsDatabaseModel(this AddFineTypeRequest model)
        {
            return new FineType()
            {
                Description = model.Description
            };
        }
        public static FineType AsDatabaseModel(this EditFineTypeRequest model)
        {
            return new FineType()
            {
                Description = model.Description
                ,
                ID = model.ID
            };
        }
        public static DeviceLocationInBranch AsDatabaseModel(this AddDeviceLocationInBranchRequest model)
        {
            return new DeviceLocationInBranch()
            {
                Description = model.Description
            };
        }
        public static DeviceLocationInBranch AsDatabaseModel(this EditDeviceLocationInBranchRequest model)
        {
            return new DeviceLocationInBranch()
            {
                Description = model.Description
                ,
                ID = model.ID
            };
        }
        public static Branch AsDatabaseModel(this AddBranchRequest model)
        {
            return new Branch()
            {
                BranchName=model.BranchName,
                Address=model.Address,
                CityID=model.CityID,
                CountryID=model.CountryID
            };
        }
        public static Branch AsDatabaseModel(this EditBranchRequest model)
        {
            return new Branch()
            {
                Address = model.Address,
                BranchName=model.BranchName,
                CityID=model.CityID,
                CountryID=model.CountryID,
                ID = model.ID
            };
        }
    }
}
