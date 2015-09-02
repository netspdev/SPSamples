using Autofac;
using Autofac.Integration.WebApi;
using DTO.Employees;
using DTO.Repository;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System.Web.OData.Formatter;

namespace Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            var jsonSerializerSettings = config.Formatters.JsonFormatter.SerializerSettings;
            jsonSerializerSettings.Formatting = Formatting.None;
            jsonSerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Web API routes
            config.MapHttpAttributeRoutes();
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //var builder = new ContainerBuilder();
            //builder.RegisterInstance<IEmployeeRepository>(new EmployeeRepository());
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => !t.IsAbstract && typeof(ApiController).IsAssignableFrom(t)).InstancePerMatchingLifetimeScope();
            //var container = builder.Build();
            //var resolver = new AutofacWebApiDependencyResolver(container);
            //config.DependencyResolver = resolver;
            ODataModelBuilder builder = new ODataConventionModelBuilder();
            builder.Namespace = "Demo";
            builder.ContainerName = "DemoContainer";
            builder.EntitySet<Employee>("Employees");
            config.MapODataServiceRoute(routeName: "ODataRoute", routePrefix: "odata", model: builder.GetEdmModel());
        }
    }
}
