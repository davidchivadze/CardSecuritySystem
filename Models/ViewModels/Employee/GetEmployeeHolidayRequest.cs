﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels.Employee
{
    public class GetEmployeeHolidayReqListRequest
    {
        public int EmployeeID { get; set; }
    }

    public class GetEmployeeHolidayReqListResponse
    {
        public List<GetEmployeeHolidayReqListItem> GetEmployeeHolidayRequestList { get; set; }
    }
    public class GetEmployeeHolidayReqListItem
    {
        public int ID { get; set; }
        public DateTime RegistartionDate { get; set; }
        public int HolidayTypeID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public int AmountWorkDays { get; set; }
        public int EmployeeID { get; set; }

    }
}
