﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interface;
using Models.EntityModels;

namespace Domain.Repository
{
    public class DepartmentsRepository : BaseRepository<Departments>, IDepartmentsRepository
    {
        public DepartmentsRepository(Data database) : base(database)
        {

        }

        public Departments AddDepartment(Departments model)
        {
            var result = _database.Departments.Add(model);
            _database.SaveChanges();
            return result;
        }

        public Departments EditDepartment(Departments model)
        {
            var result = _database.Departments.Where(m => m.ID == model.ID).FirstOrDefault();
            result.Description = model.Description;
            _database.SaveChanges();
            return result;
        }

        public IEnumerable<Departments> GetDepartments()
        {
            return _database.Departments.Include("ParentDepartment");
        }
    }
}
