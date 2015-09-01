using DTO.Employees;
using System.Linq;
using System.Threading.Tasks;

namespace DTO.Repository
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> GetEmployees();
        Employee GetEmployeeById(long Id);
        Task<Employee> Add(Employee employee);
        Task<bool> Delete(Employee employee);
        Task<Employee> Update(Employee employee);
        Task<int> ClearAll();
    }
}
