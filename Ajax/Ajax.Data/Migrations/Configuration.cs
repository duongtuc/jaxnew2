namespace Ajax.Data.Migrations
{
    using Ajax.Data.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ajax.Data.EmployeeDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Ajax.Data.EmployeeDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Employees.AddOrUpdate(
                new Employee
                {
                    Name = "Nguyen van C",
                    Age = 22,
                    CreateDate = DateTime.Now,
                    Status = true
                },
                new Employee
                {
                    Name = "Nguyen van A",
                    Age = 22,
                    CreateDate = DateTime.Now,
                    Status = true
                }, new Employee
                {
                    Name = "Nguyen van B",
                    Age = 22,
                    CreateDate = DateTime.Now,
                    Status = true
                }, new Employee
                {
                    Name = "Nguyen van D",
                    Age = 22,
                    CreateDate = DateTime.Now,
                    Status = true
                }, new Employee
                {
                    Name = "Nguyen van E",
                    Age = 22,
                    CreateDate = DateTime.Now,
                    Status = true
                }
                );
        }
    }
}
