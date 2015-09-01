using DTO.Repository;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Web.App_Start
{
    public class UnityConfig
    {
        public static void Register(HttpConfiguration httpConfig)
        {
            //var container = new UnityContainer();
            //container.RegisterType<IEmployeeRepository, EmployeeRepository>(new HierarchicalLifetimeManager());
            //httpConfig.DependencyResolver = new UnityResolver(container);
        }
    }
}