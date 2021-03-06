using Microsoft.Practices.Unity;
using System.Web.Mvc;
using Unity.Mvc3;
using Web.Areas.Api.Controllers;

namespace Web
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();       
            //container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            //container.RegisterType<IController, EmployeesController>("Employees");

            return container;
        }
    }
}