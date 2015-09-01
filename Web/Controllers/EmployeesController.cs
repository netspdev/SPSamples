using DTO.Employees;
using DTO.Repository;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace Web.Controllers
{
    [System.Web.Mvc.Authorize]
    public class EmployeesController : Controller
    {
        private IEmployeeRepository _context;
       public EmployeesController(IEmployeeRepository employeeService)
       {
           this._context = employeeService;
       }

       public IQueryable<Employee> GetEmployees()
       {
           return this._context.GetEmployees();
       }

       //public async Task<IHttpActionResult> Post(Employee employee)
       //{
       //    if (!ModelState.IsValid)
       //    {
       //        return this.BadRequest(this.ModelState);
       //    }


       //    var result = await this.StoreAsync(employee);
       //    return this.Ok<Employee>(result);
       //}

       //public async Task<IHttpActionResult> Delete(Employee employee)
       //{
       //    if (!ModelState.IsValid)
       //    {
       //        return this.BadRequest(this.ModelState);
       //    }


       //    var result = await this.DeleteAsync(employee);
       //    return this.Ok<bool>(result);
       //}

       //public async Task<IHttpActionResult> Patch(Employee employee)
       //{
       //    if (!ModelState.IsValid)
       //    {
       //        return this.BadRequest(this.ModelState);
       //    }


       //    var result = await this._context.Update(employee);
       //    return this.Ok<Employee>(result);
       //}

       private async Task<Employee> StoreAsync(Employee employee)
       {
           var result = await this._context.Add(employee);

           return result;
       }

       private async Task<bool> DeleteAsync(Employee employee)
       {
           var result = await this._context.Delete(employee);

           return result;
       }
    }
}