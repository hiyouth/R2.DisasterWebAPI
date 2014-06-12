using Autofac;
using R2.Disaster.Core.DependencyManagement;
using R2.Disaster.Core.Infrastructure;
using System.Linq;
using Autofac.Integration.WebApi;
using R2.Disaster.Service;
using R2.Disaster.Repository;
using R2.Disaster.Data;
using R2.Disaster.WebAPI.Controllers;
using R2.Disaster.Service.GeoDisaster;
using R2.Disaster.Service.GeoDisaster.Investigation;

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
            builder.RegisterType<ComprehensiveService>().As<IComprehensiveService>().InstancePerRequest();
            builder.RegisterType<DebrisFlowService>().As<IDebrisFlowService>().InstancePerRequest();
            builder.RegisterType<PhyGeoDisasterService>().As<IPhyGeoDisasterService>().InstancePerRequest();
        }

        public int Order
        {
            get { return 0; }
        }
    }
}