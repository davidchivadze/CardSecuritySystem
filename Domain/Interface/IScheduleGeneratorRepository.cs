using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IScheduleGeneratorRepository: IBaseRepository<ScheduleGenerator>
    {
        IEnumerable<ScheduleGenerator> GetScheduleGenerators();
        bool AddScheduleGenerator(ScheduleGenerator model);
        bool EditScheduleGenerator(ScheduleGenerator model);
    }
}
