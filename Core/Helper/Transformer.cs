using Models;
using Models.EntityModels;
using Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helper
{
    public static class Transformer
    {
        public static Employee AsDatabaseModel(this EmployeeViewModel model)
        {
            return new Employee
            {
                ID = model.ID,
                FirsName = model.FirstName,
                LastName = model.LastName
            };
        }
        public static EmployeeViewModel AsViewModel(this Employee model)
        {
            return new EmployeeViewModel
            {
                ID = model.ID,
                FirstName = model.FirsName,
                LastName = model.LastName
            };
        }

    }
}
