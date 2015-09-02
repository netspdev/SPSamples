using DTO.Employees;
using DTO.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.OData;
using System.Web.OData.Routing;

namespace Web.Areas.Api.Controllers
{
    //[Authorize]
    [System.Web.Mvc.RoutePrefix("/")]
    [ODataRoutePrefix("Employees")]
    public class EmployeesController : ODataController
    {
        private IEmployeeRepository _context;
        public EmployeesController(IEmployeeRepository employeeService)
        {
            this._context = employeeService;
        }

        [EnableQuery(PageSize = 2)]
        public IQueryable<Employee> Get(long id = 0)
        {
            if (id == 0)
                return this._context.GetEmployees();
            else
            {
                List<Employee> employees = new List<Employee>();
                var employee = this._context.GetEmployeeById(id);
                if (employee != null)
                    employees.Add(employee);
                return employees.AsQueryable();
            }
        }

        public async Task<IHttpActionResult> Post(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }


            var result = await this.StoreAsync(employee);
            return this.Ok<Employee>(result);
        }

        public async Task<IHttpActionResult> Delete(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            if (employee.Id == -1)
                return this.Ok<int>(await Clear());

            var result = await this.DeleteAsync(employee);
            return this.Ok<bool>(result);
        }

        public async Task<IHttpActionResult> Patch(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var result = await this._context.Update(employee);
            return this.Ok<Employee>(result);
        }

        private async Task<int> Clear()
        {
            return (await this._context.ClearAll());
        }

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
