using Autofac;
using R2.Disaster.Core.DependencyManagement;
using R2.Disaster.Core.Infrastructure;
using System.Linq;
using Autofac.Integration.WebApi;
using R2.Disaster.Service;
using R2.Disaster.Repository;
using R2.Disaster.Data;
using R2.Disaster.Service.GeoDisaster.Investigation;
using R2.Disaster.WebAPI.Controllers;

namespace R2.Disaster.WebAPI
{
    public class DenpendencyRegistrar:IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterApiControllers(typeFinder.GetAssemblies().ToArray());
            builder.RegisterType<R2DisasterContext>().As<IDbContext>().InstancePerRequest();
            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IRepository<>)).InstancePerRequest();
            builder.RegisterType<BookRepository>().As<IBookRepository>().InstancePerRequest();
            builder.RegisterType<BookService>().As<IBookService>().InstancePerRequest();
            builder.RegisterType<Class1>().InstancePerRequest();

            builder.RegisterType<ComprehensiveService>().As<IComprehensiveService>().InstancePerRequest();
        }

        public int Order
        {
            get { return 0; }
        }
    }
}