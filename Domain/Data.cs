namespace Domain
{
    using System.Data.Entity;

    using Models;
    using Models.EntityModels;

    public partial class Data : DbContext
    {
        public Data()
            : base("name=Data")
        {
        }

        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<HolidayType> HolidayTypes { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public virtual DbSet<EmployeePosition> EmployeePositions { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<SalaryType> SalaryTypes { get; set; }
        public virtual DbSet<Forgiveness> Forgiveness { get; set; }
        public virtual DbSet<ForgivenessType> ForgivenessTypes { get; set; }
        public virtual DbSet<Fine> Fines { get; set; }
        public virtual DbSet<FineType> FineTypes { get; set; }
        public virtual DbSet<EmployeeHolidays> EmployeeHolidays { get; set; }
        public virtual DbSet<EmployeeMobileNumbers> EmployeeMobileNumbers { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
        public virtual DbSet<ScheduleDetails> ScheduleDetails { get; set; }
       // public virtual DbSet<ScheduleGenerator> ScheduleGenerators { get; set; }
        public virtual DbSet<ScheduleType> ScheduleTypes { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<DeviceType> DeviceTypes { get; set; }
        public virtual DbSet<RemoteDeviceSyncLog> RemoteDeviceSyncLogs { get; set; }
        public virtual DbSet<DeviceLocationInBranch> DeviceLocationInBranches { get; set; }
        public virtual DbSet<DeviceUserLog> DeviceUserLogs { get; set; }
        public virtual DbSet<DeviceRegistratedUsers> DeviceRegistratedUsers { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
