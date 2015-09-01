using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Autofac;
using DTO.Repository;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using System.Web.Http;
using System.Reflection;
using Autofac.Integration.WebApi;

[assembly: OwinStartup(typeof(Web.Startup))]

namespace Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<EmployeeRepository>().As<IEmployeeRepository>().InstancePerRequest();
            //...
            var container = builder.Build();
            //var config = GlobalConfiguration.Configuration;
            // OPTIONAL: Register the Autofac filter provider.
            //builder.RegisterWebApiFilterProvider(config);
            // This will add the Autofac middleware as well as the middleware
            // registered in the container.
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver
            //DependencyResolver.SetResolver(new AutofacWebApiDependencyResolver(container));
            //config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            app.UseAutofacMiddleware(container);
            ConfigureAuth(app);
        }
    }
}
