using OA.ApiTemp.DI_Resolver;
using OA.Repo.Repository;
using OA.Repo.UnitOfWork;
using OA.Service;
using OA.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;

namespace OA.ApiTemp
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //configure DI
            var container = new UnityContainer();
            container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
            container.RegisterType(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            container.RegisterType<IStudentBusiness, StudentService>();
            container.RegisterType<IFaculty, FacultyService>();

            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Enable Cors
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            

            //configure api to return json
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
