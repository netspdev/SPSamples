using System.Data.Entity;

namespace Entities.Employees
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
            : base("name=EmployeeConnection")
        {

            Database.SetInitializer(new CreateDatabaseIfNotExists<EmployeeDBContext>());
            //if (!this.Database.Exists())
            //    this.Database.Create();
            //this.Database.Initialize(true);
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = true;
            this.Configuration.LazyLoadingEnabled = true;

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee>().HasKey(t => new { t.Id, t.Email });
            base.OnModelCreating(modelBuilder);
        }

        protected override System.Data.Entity.Validation.DbEntityValidationResult ValidateEntity(System.Data.Entity.Infrastructure.DbEntityEntry entityEntry, System.Collections.Generic.IDictionary<object, object> items)
        {
            return base.ValidateEntity(entityEntry, items);
        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
