using Autofac;
using Autofac.Integration.Mvc;
using Hippo.SuperMarket.Domain.Abstract;
using Hippo.SuperMarket.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hippo.SuperMarket.WebApp
{
    public class IocConfig
    {
        public static void ConfigIoc()
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterControllers(typeof(MvcApplication).Assembly)
                .PropertiesAutowired();

            builder
                .RegisterInstance<IProductsRepository>(new EFProductRepository())
                .PropertiesAutowired();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}