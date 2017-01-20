using Autofac;
using Autofac.Integration.WebApi;
using Newtonsoft.Json.Serialization;
using SAPAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using System.Web.Mvc;
using SAPAPI.Models;
using System.Data.Entity;

namespace SAPAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            


            //config.EnsureInitialized();

            // Register your Web API controllers.
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers("Controller", Assembly.GetExecutingAssembly());


            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // Set the dependency resolver to be Autofac.\




            // GlobalConfiguration.Configure(WebApiConfig.Register);
            //builder.RegisterType<b1>()
            //    .As<b1>()
            //    .SingleInstance();

            //builder.RegisterType<OCRDController>().InstancePerRequest();


            builder.RegisterType<SAPAPIContext>()
           .As<SAPAPIContext>()
           .InstancePerLifetimeScope();

            //HttpConfiguration config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            //WebApiConfig.Register(config);
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);


            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);


            //RegisterBundles(BundleTable.Bundles);

        }

        

        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //   name: "Default",
            //    url: "api/{controller}/{action}/{id}",
            //    defaults: new { action = "Index", id = UrlParameter.Optional }
            //);

            routes.MapHttpRoute(
                name: "DefaultApi",
                //routeTemplate: "api/{controller}/{id}",
                routeTemplate: "api/{controller}/{action}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );

        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }


        public static void ConnectToB1( )
        {
            b1.Connect();
        }
    }
}
