namespace Entities.Migrations
{
    using Entities.Employees;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<Entities.Employees.EmployeeDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Entities.Employees.EmployeeDBContext";
        }

        protected override void Seed(Entities.Employees.EmployeeDBContext context)
        {
            //context.Employees.Add(
            //        new Employee()
            //    {
            //        Email = "test@test.com",
            //        FirstName = "T1",
            //        LastName = "T2",
            //        Phone = "333-333-3333"
            //    });
            //context.Employees.AddOrUpdate(x =>
            //    x.Id,
            //    new Employee()
            //    {
            //        Email = "test@test.com",
            //        FirstName = "T1",
            //        LastName = "T2",
            //        Phone = "333-333-3333"
            //    });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
