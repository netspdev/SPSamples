using AutoMapper;
using Entities.Employees;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DTO.Repository
{
    public class EmployeeRepository : IEmployeeRepository, IDisposable
    {
        EmployeeDBContext dbContext;
        public EmployeeRepository()
        {
            this.dbContext = new EmployeeDBContext();
            //if (this.dbContext.Employees.Count() <= 10)
            //{
            //    this.dbContext.Employees.Add(
            //           new Employee()
            //           {
            //               Email = "test@test.com",
            //               FirstName = "T1",
            //               LastName = "T2",
            //               Phone = "333-333-3333"
            //           });
            //}

            //if (this.dbContext.ChangeTracker.HasChanges())
            //    this.dbContext.SaveChanges();
        }

        public IQueryable<DTO.Employees.Employee> GetEmployees()
        {
            return Mapper.Map<DTO.Employees.Employee[]>(this.dbContext.Employees).AsQueryable();
        }

        public DTO.Employees.Employee GetEmployeeById(long Id)
        {
            return Mapper.Map<DTO.Employees.Employee>(this.dbContext.Employees.SingleOrDefault(x => x.Id == Id));
        }

        public async Task<DTO.Employees.Employee> Add(DTO.Employees.Employee employee)
        {
            var emp = Mapper.Map<Entities.Employees.Employee>(employee);
            this.dbContext.Employees.Add(emp);
            await dbContext.SaveChangesAsync();

            return Mapper.Map<DTO.Employees.Employee>(this.dbContext.Employees.OrderByDescending(x => x.Id).FirstOrDefault());

        }

        public async Task<bool> Delete(DTO.Employees.Employee employee)
        {
            var deleteItem = this.dbContext.Employees.FirstOrDefault(x => x.Email == employee.Email);
            if (deleteItem != null)
            {
                this.dbContext.Employees.Remove(deleteItem);
                await dbContext.SaveChangesAsync();

                return this.dbContext.Employees.FirstOrDefault(x => x.FirstName == employee.FirstName && x.Email == employee.Email && employee.LastName == employee.LastName) == null;
            }


            throw new System.Data.Entity.Validation.DbEntityValidationException(string.Format("employee with email {0} could not be found", employee.Email));

        }

        public async Task<DTO.Employees.Employee> Update(DTO.Employees.Employee employee)
        {
            var updateItem = this.dbContext.Employees.FirstOrDefault(x => x.Id == employee.Id);

            if (updateItem != null)
            {
                updateItem.FirstName = employee.FirstName;
                updateItem.LastName = employee.LastName;

                await dbContext.SaveChangesAsync();

                return Mapper.Map<DTO.Employees.Employee>(this.dbContext.Employees.FirstOrDefault(x => x.FirstName == employee.FirstName && x.Email == employee.Email && employee.LastName == employee.LastName));
            }

            throw new System.Data.Entity.Validation.DbEntityValidationException(string.Format("employee with email {0} could not be found", employee.Email));
        }

        public async Task<int> ClearAll()
        {
            this.dbContext.Employees.RemoveRange(this.dbContext.Employees);
            return this.dbContext.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.dbContext != null)
                {
                    this.dbContext.Dispose();
                    this.dbContext = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}