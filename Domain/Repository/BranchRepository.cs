using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class BranchRepository : BaseRepository<Branch>, IBranchRepository
    {
        public BranchRepository(Data database) : base(database)
        {

        }

        public Branch AddBranch(Branch model)
        {
            var result = _database.Branches.Add(model);
            _database.SaveChanges();
            return result;
        }

        public Branch EditBranch(Branch model)
        {
            var result = _database.Branches.Where(m => m.ID == model.ID).FirstOrDefault();
            result.Address = model.Address;
            result.BranchName = model.BranchName;
            result.CityID = model.CityID;
            result.CountryID = model.CountryID;
            _database.SaveChanges();
            return result;
        }

        public IEnumerable<Branch> GetBranches()
        {
            return _database.Branches;
        }
    }
}
