namespace Domain
{
    using System.Data.Entity;

    using Models;
    using Models.EntityModels;

    public partial class Database : DbContext
    {
        public Database()
            : base("name=Data")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<EmployeeDetails> EmployeeDetails { get; set; }
        public virtual DbSet<EmployeePosition> EmployeePositions { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }
        public virtual DbSet<EmployeeMobileNumbers> EmployeeMobileNumbers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
