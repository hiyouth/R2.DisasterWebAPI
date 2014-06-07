using Autofac;
using Autofac.Integration.WebApi;
using R2.Disaster.Core.Infrastructure;
using R2.Disaster.Repository;
using R2.Disaster.Service;
using System.Web.Http;
using System.Linq;
using System.Reflection;
using R2.Disaster.WebAPI.Controllers;
using Newtonsoft.Json;
using System.Web.Routing;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Optimization;

namespace R2.Disaster.WebAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            EngineContext.Initialize(false);

            var configuration = GlobalConfiguration.Configuration;


            var resolver = new AutofacWebApiDependencyResolver(
                EngineContext.Current.ContainerManager.Container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
            

            //GlobalConfiguration.Configuration.DependencyResolver
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
           

            //TODO 阻止循环引用序列化（记录到RRDL）
            //阻止循环引用序列化
            var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling =
            //    Newtonsoft.Json.PreserveReferencesHandling.Objects;
            json.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        }
    }
}
