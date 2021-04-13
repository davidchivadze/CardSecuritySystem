using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IBranchRepository : IBaseRepository<Branch>
    {
        IEnumerable<Branch> GetBranches();
        Branch AddBranch(Branch model);
        Branch EditBranch(Branch model);
        bool DeleteBranch(Branch model);
    }
}
