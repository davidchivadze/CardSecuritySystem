namespace Domain.Migrations
{
    using Core.Encryption;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Domain.Data>
    {
        private readonly bool _pendingMigrations;
        public Configuration()
        {

            AutomaticMigrationsEnabled = true;
            // Check if there are migrations pending to run, this can happen if database doesn't exists or if there was any
            //  change in the schema
            var migrator = new DbMigrator(this);
            _pendingMigrations = migrator.GetPendingMigrations().Any();

            // If there are pending migrations run migrator.Update() to create/update the database then run the Seed() method to populate
            //  the data if necessary
            if (_pendingMigrations)
            {
                migrator.Update();
                this.Seed(new Domain.Data());
            }
        }

        protected override void Seed(Domain.Data context)
        {
            if (context.Currencies.Count() == 0)
            {
                context.Currencies.Add(new Models.EntityModels.Currency() { ID = 1, Description = "₾" });
                context.Currencies.Add(new Models.EntityModels.Currency() { ID = 2, Description = "$" });
                context.Currencies.Add(new Models.EntityModels.Currency() { ID = 3, Description = "€" });
                context.SaveChanges();
            }
            if (context.ForgivenessTypes.Count() == 0) {
                context.ForgivenessTypes.Add(new Models.EntityModels.ForgivenessType() { ID = 1, Description="პატიების გარეშე" });
                context.ForgivenessTypes.Add(new Models.EntityModels.ForgivenessType() { ID = 2, Description= "X წუთის პატიება თვეში" });
                context.ForgivenessTypes.Add(new Models.EntityModels.ForgivenessType() { ID = 3, Description = "X რაოდენობის პატიება თვეში" });
                context.ForgivenessTypes.Add(new Models.EntityModels.ForgivenessType() { ID = 4, Description = "დარედაქტირდა" });
                context.SaveChanges();
            }
            if(context.FineTypes.Count()==0)
            {
                context.FineTypes.Add(new Models.EntityModels.FineType() { ID = 1, Description = "ჯარიმის გარეშე" });
                context.FineTypes.Add(new Models.EntityModels.FineType() { ID = 2, Description = "პროცენტული ჯარიმა წუთზე" });
                context.FineTypes.Add(new Models.EntityModels.FineType() { ID = 3, Description = "ფიქსირებული ჯარიმა წუთზე" });
                context.FineTypes.Add(new Models.EntityModels.FineType() { ID = 4, Description = "პროცენტული ჯარიმა" });
                context.FineTypes.Add(new Models.EntityModels.FineType() { ID = 5, Description = "ფიქსირებული ჯარიმა" });
                context.FineTypes.Add(new Models.EntityModels.FineType() { ID = 6, Description = "ბიჯური ჯარიმა" });
                context.SaveChanges();
            }
            if(context.SalaryTypes.Count()==0)
            {
                context.SalaryTypes.Add(new Models.EntityModels.SalaryType() { ID = 1, Description = "ყოველთვიური ანაზღაურება" });
                context.SalaryTypes.Add(new Models.EntityModels.SalaryType() { ID = 2, Description = "საათობრივი ანაზღაურება" });
                context.SalaryTypes.Add(new Models.EntityModels.SalaryType() { ID = 3, Description = "წლიური ანაზღაურება" });
                context.SalaryTypes.Add(new Models.EntityModels.SalaryType() { ID = 4, Description = "კვირეული ანაზღაურება" });
                context.SaveChanges();
            }
            if(context.Genders.Count()==0)
            {
                context.Genders.Add(new Models.EntityModels.Gender() { ID = 1, Description = "Male" });
                context.Genders.Add(new Models.EntityModels.Gender() { ID = 2, Description = "Female" });
                context.SaveChanges();
            }
            if (context.Countries.Count() == 0)
            {
                context.Countries.Add(new Models.EntityModels.Country() { ID = 1, Description = "საქართველო" });
                context.SaveChanges();
            }

            if (context.Cities.Count() == 0)
            {
                context.Cities.Add(new Models.EntityModels.City() { ID = 1, Description = "თბილისი",CountryID=1 });
                context.SaveChanges();
            }

            if (context.HolidayTypes.Count() == 0)
            {

                context.HolidayTypes.Add(new Models.EntityModels.HolidayType() { ID = 1, Description = "შვებულება" });
                context.HolidayTypes.Add(new Models.EntityModels.HolidayType() { ID = 2, Description = "დეკრეტი" });
                context.HolidayTypes.Add(new Models.EntityModels.HolidayType() { ID = 3, Description = "უხელფასო შვებულება" });
                context.HolidayTypes.Add(new Models.EntityModels.HolidayType() { ID = 4, Description = "Day Off" });
                context.HolidayTypes.Add(new Models.EntityModels.HolidayType() { ID = 5, Description = "გამონაკლისი" });
                context.HolidayTypes.Add(new Models.EntityModels.HolidayType() { ID = 6, Description = "ბიულეტინი" });
                context.SaveChanges();
            }
            if (context.ScheduleTypes.Count() == 0)
            {
                context.ScheduleTypes.Add(new Models.EntityModels.ScheduleType() { ID = 1, Description = "სტანდარტული" });
                context.ScheduleTypes.Add(new Models.EntityModels.ScheduleType() { ID = 2, Description = "არასტანდარტული" });

                context.SaveChanges();
            }
            if (context.DeviceTypes.Count() == 0)
            {
                context.DeviceTypes.Add(new Models.EntityModels.DeviceType()
                {
                    Description = "ZKTeco მოწყობილობა",
                    ID = 1
                });
                context.SaveChanges();
            }
            if (context.Users.Count() == 0)
            {
                context.Users.Add(new Models.EntityModels.Users()
                {
                    UserName = "admin",
                    Password = HashGenerator.CreateMD5("admin")
                });
            }
            if (context.EmployeeWorkingLogTimeTypes.Count() == 0)
            {
                context.EmployeeWorkingLogTimeTypes.Add(new Models.EntityModels.EmployeeWorkingLogTimeType()
                {
                    ID = 1,
                    Description = "ნამუშევარი საათები"
                });
                context.SaveChanges();

                context.EmployeeWorkingLogTimeTypes.Add(new Models.EntityModels.EmployeeWorkingLogTimeType()
                {
                    ID = 2,
                    Description = "შესვენება"
                });
                context.SaveChanges();
            }
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
