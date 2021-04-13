using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class EmployeePositionRepository : BaseRepository<EmployeePosition>, IEmployeePositionRepositoy
    {
        public EmployeePositionRepository(Data databse) : base(databse)
        {
                
        }

        public EmployeePosition AddEmployeePosition(EmployeePosition model)
        {
            var result = _database.EmployeePositions.Add(model);
            _database.SaveChanges();
            return result;
        }

        public EmployeePosition EditEmployeePosition(EmployeePosition model)
        {

            var result = _database.EmployeePositions.Where(m => m.ID == model.ID).FirstOrDefault();
            result.Description = model.Description;
            _database.SaveChanges();
            return result;
        }

        public IEnumerable<EmployeePosition> GetEmployeePositions()
        {
           return _database.EmployeePositions.Where(m=>m.IsActive);
        }
        public bool DeleteEmployeePosition(int employeePositionID)
        {
            try { 
            var editModel = _database.EmployeePositions.Where(m => m.ID == employeePositionID).FirstOrDefault();
            editModel.IsActive = false;
            _database.SaveChanges();
            return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
