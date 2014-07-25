using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
//using Autofac.Integration.Mvc;
using R2.Disaster.Core.DependencyManagement;
using R2.Disaster.Core.Infrastructure;
using R2.Disaster.WebFramework.EmbeddedViews;
using R2.Disaster.WebFramework.Mvc.Routes;


namespace R2.Disaster.WebFramework
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {  
            builder.RegisterType<EmbeddedViewResolver>().As<IEmbeddedViewResolver>().SingleInstance();
            builder.RegisterType<RoutePublisher>().As<IRoutePublisher>().SingleInstance();
        }

        public int Order
        {
            get { return 0; }
        }
    }

}
