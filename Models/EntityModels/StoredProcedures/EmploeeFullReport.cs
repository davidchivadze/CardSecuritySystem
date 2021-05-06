using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.EntityModels.StoredProcedures
{
    public class EmploeeFullReport
    {
        public int EmployeeID            {get;set;}
        public DateTime? ScheduleFromTime      {get;set;}
        public DateTime? ScheduleToTime        {get;set;}
        public bool IsWorkingDay          {get;set;}
        public DateTime? CheckInTime           {get;set;}
        public DateTime? CheckOutTime          {get;set;}
        public int? LateCheckInMinutes    {get;set;}
        public int? EarlyCheckInMinutes   {get;set;}          
        public int? EarlyCheckOutMinutes  {get;set;}
        public int? LateCheckOutMinutes   {get;set;}
        public string WorkStatus            {get;set;}
        public string FullName              {get;set;}
        public int IndRegID              {get;set;}
        public int? WorkedMinutess        {get;set;}
        public int? FineMinutes           {get;set;}
        public int? WorkedInSchedule      {get;set;}
        public int? WorkedOutSchedule     { get; set; }
        public int? MissedMinutes { get; set; }

    }
}
