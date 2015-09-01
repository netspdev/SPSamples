// Uncomment the following to provide samples for PageResult<T>. Must also add the Microsoft.AspNet.WebApi.OData
// package to your project.
////#define Handle_PageResultOfT

using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using DTO.Repository;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.OData.Builder;

namespace Web.Areas.Api
{
    /// <summary>
    /// Use this class to customize the Help Page.
    /// For example you can set a custom <see cref="System.Web.Http.Description.IDocumentationProvider"/> to supply the documentation
    /// or you can provide the samples for the requests/responses.
    /// </summary>
    public static class ApiAreaConfig
    {
        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
            MessageId = "Web.Areas.HelpPage.TextSample.#ctor(System.String)",
            Justification = "End users may choose to merge this string with existing localized resources.")]
        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly",
            MessageId = "bsonspec",
            Justification = "Part of a URI.")]
        public static void Register(HttpConfiguration config)
        {
            //ODataModelBuilder builder = new ODataConventionModelBuilder();
            //builder.EntitySet<Employee>("Employees");
            //config.Routes.Ma.MapODataServiceRoute(
            //    routeName: "ODataRoute",
            //    routePrefix: null,
            //    model: builder.GetEdmModel());
        }
    }
}