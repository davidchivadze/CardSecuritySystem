using Domain.Interface;
using Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public class ScheduleGeneratorRepository : BaseRepository<ScheduleGenerator>, IScheduleGeneratorRepository
    {
        public ScheduleGeneratorRepository(Data database) : base(database)
        {
        }

        public bool AddScheduleGenerator(ScheduleGenerator model)
        {
            try { 
            var result= _database.ScheduleGenerators.Add(model);
            _database.SaveChanges();

                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool EditScheduleGenerator(ScheduleGenerator model)
        {
            try
            {
                var editObject = _database.ScheduleGenerators.Where(m => m.ID == model.ID).FirstOrDefault();
                if (editObject != null)
                {
                    editObject.MaxCheckOutTime = model.MaxCheckOutTime;
                    editObject.MinCheckInTime = model.MinCheckInTime;
                    editObject.Name = model.Name;
                    editObject.OnWorkingDaysOnly = model.OnWorkingDaysOnly;
                    editObject.OnWorkingHouresOnly = model.OnWorkingHouresOnly;
                    editObject.ScheduleTypeID = model.ScheduleTypeID;
                    editObject.StartTime = model.StartTime;
                    editObject.EndTime = model.EndTime;
                    editObject.WeekHouresAmount = model.WeekHouresAmount;
                    _database.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ScheduleGenerator> GetScheduleGenerators()
        {
            return _database.ScheduleGenerators.Include("ScheduleType").Where(m => m.IsActive == true);
        }
    }
}
