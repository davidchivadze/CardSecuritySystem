using Models.EntityModels;
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
        public static GetCitiesListItem AsViewModel(this City model)
        {
            return new GetCitiesListItem
            {
                ID = model.ID,
                Description = model.Description
            };
        }
    }
}
