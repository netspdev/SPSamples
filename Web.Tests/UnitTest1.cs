using DTO.Employees;
using DTO.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Web.Areas.Api.Controllers;

namespace Web.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee() { Id = 1, FirstName = "First Name", LastName = "Last Name", Email = "first@lastemail.com", Phone = "333-333-3333" });
            employees.Add(new Employee() { Id = 2, FirstName = "First Name", LastName = "Last Name", Email = "first@lastemail.com", Phone = "333-333-3333" });
            employees.Add(new Employee() { Id = 3, FirstName = "First Name", LastName = "Last Name", Email = "first@lastemail.com", Phone = "333-333-3333" });

            var employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository.Setup(x => x.GetEmployees()).Returns(employees.AsQueryable());


            var controller = new EmployeesController(employeeRepository.Object);
            Assert.AreEqual(3, controller.GetEmployees().Where(x => x.Email == "first@lastemail.com").Count());

            //EmployeeDBContext context = new EmployeeDBContext();

            //Assert.AreEqual(true, context.Employees.Count() > 0);
        }
    }
}
