using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BillingLayer.Dao;

namespace BillingApi.App_Start
{
    public class DependencyConfig
    {
        public static Container RegisterDependencies(HttpConfiguration config)
        {
            Container container = new Container();

            RegisterInterfaces(container);

            container.Verify();
            return container;
        }

        private static void RegisterInterfaces(Container container)
        {
            container.Register<ProductTypeDao>(Lifestyle.Singleton);
            //container.Register<ICoverageService, CoverageService>(Lifestyle.Singleton);
            //container.Register<ITestingService, TestingService>(Lifestyle.Singleton);
        }
    }
}