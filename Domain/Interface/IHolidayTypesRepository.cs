using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IHolidayTypesRepository:IBaseRepository<HolidayType>
    {
        IEnumerable<HolidayType> GetHolidayTypes();

        HolidayType EditHolidayTypes(HolidayType model);
       HolidayType AddHolidayTypes(HolidayType model);
    }
}
