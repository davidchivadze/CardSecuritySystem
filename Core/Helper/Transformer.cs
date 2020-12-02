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
        public static Employee EmployeeAsDatabaseModel(this EmployeeViewModel model)
        {
            return new Employee
            {
                ID = model.ID,
                FirsName = model.FirsName,
                FirsName_ka = model.FirsName_ka,
                FirsName_ru = model.FirsName_ru,
                LastName = model.LastName,
                LastName_ka = model.LastName_ka,
                LastName_ru = model.LastName_ru,
                Address = model.Address,
                Address_ru = model.Address_ru,
                Address_ka = model.Address_ka,
                DateOfBirth = model.DateOfBirth,
                Email = model.Email,
                IsActive = model.IsActive,
            };
        }
        public static EmployeeViewModel EmployeeAsViewModel(this Employee model)
        {
            return new EmployeeViewModel
            {
                ID = model.ID,
                FirsName = model.FirsName,
                FirsName_ka = model.FirsName_ka,
                FirsName_ru = model.FirsName_ru,
                LastName = model.LastName,
                LastName_ka = model.LastName_ka,
                LastName_ru = model.LastName_ru,
                Address = model.Address,
                Address_ru = model.Address_ru,
                Address_ka = model.Address_ka,
                DateOfBirth = model.DateOfBirth,
                Email = model.Email,
                IsActive = model.IsActive,
            };
        }

        //public static Employee AsDatabaseModel(this EmployeeViewModel model)
        //{
        //    return new Employee
        //    {
        //        ID = model.ID,
        //        FirsName = model.FirstName,
        //        LastName = model.LastName
        //    };
        //}
        //public static EmployeeViewModel AsViewModel(this Employee model)
        //{
        //    return new EmployeeViewModel
        //    {
        //        ID = model.ID,
        //        FirstName = model.FirsName,
        //        LastName = model.LastName
        //    };
        //}

    }
}
