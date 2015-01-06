using Autofac;
using R2.Disaster.Core.DependencyManagement;
using R2.Disaster.Core.Infrastructure;
using System.Linq;
using Autofac.Integration.WebApi;
using R2.Disaster.Service;
using R2.Disaster.Repository;
using R2.Disaster.Data;
using R2.Disaster.Service.GeoDisaster.PotentialThreats;
using R2.Disaster.WebAPI.Controllers;
using R2.Disaster.Service.GeoDisaster;
using R2.Disaster.Service.GeoDisaster.Investigation;
using R2.Disaster.CoreEntities.Domain.GeoDisaster.MassPres;
using R2.Disaster.Service.GeoDisaster.MassPres;
using R2.Disaster.Service.Monitor;
using R2.Disaster.Service.GeoDisaster.Emergency;
using R2.Disaster.Service.MineRecovery;
using R2.Disaster.Service.GeoDisaster.Relocation;

namespace R2.Disaster.WebAPI
{
    public class DenpendencyRegistrar : IDependencyRegistrar
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
            //   builder.RegisterType<Phy>().As<IPhyGeoDisasterService>().InstancePerRequest();
            builder.RegisterType<MassPreService>().As<IMassPreService>().InstancePerRequest();
            builder.RegisterType<MonthlyReportService>().As<IMonthlyReportService>().InstancePerRequest();
            builder.RegisterType<EmergencySurveyReportService>().As<IEmergencySurveyReportService>().InstancePerRequest();
            //矿山复绿
            builder.RegisterType<MineArchiveService>().As<IMineArchiveService>().InstancePerRequest();
            builder.RegisterType<MineEnvironmentSurveyService>().As<IMineEnvironmentSurveyService>().InstancePerRequest();
            builder.RegisterType<MineRemoteSensingCardService>().As<IMineRemoteSensingCardService>().InstancePerRequest();
            //移民搬迁
            builder.RegisterType<RelocationComprehensiveService>().As<IRelocationComprehensiveService>().InstancePerRequest();
            builder.RegisterType<RelocationDebrisFlowCheckService>().As<IRelocationDebrisFlowCheckService>().InstancePerRequest();
            builder.RegisterType<RelocationLandCollapseCheckService>().As<IRelocationLandCollapseCheckService>().InstancePerRequest();
            builder.RegisterType<RelocationLandSlideCheckService>().As<IRelocationLandSlideCheckService>().InstancePerRequest();
            builder.RegisterType<RelocationLandSlipCheckService>().As<IRelocationLandSlipCheckService>().InstancePerRequest();
            builder.RegisterType<RelocationSlopeCheckService>().As<IRelocationSlopeCheckService>().InstancePerRequest();
            builder.RegisterType<RelocationPlaceEvaluationService>().As<IRelocationPlaceEvaluationService>().InstancePerRequest();
            //隐患点主表服务
            builder.RegisterType<ThreatService>().As<IThreatService>().InstancePerRequest();
            //防治规划
            builder.RegisterType<PreventionPlanningService>().As<IPreventionPlanningService>().InstancePerRequest();
            builder.RegisterType<PrePlanService>().As<IPrePlanService>().InstancePerRequest();
            builder.RegisterType<WorkingGuideCardService>().As<IWorkingGuideCardService>().InstancePerRequest();
            builder.RegisterType<AvoidRiskCardService>().As<IAvoidRiskCardService>().InstancePerRequest();
            builder.RegisterType<RainfallStationService>().As<IRainfallStationService>().InstancePerRequest();
        }

        public int Order
        {
            get { return 0; }
        }
    }
}