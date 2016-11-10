using CarFuel.Data;
using CarFuel.Models;
using CarFuel.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;

namespace CarFuel.Web {
  public class MvcApplication : System.Web.HttpApplication {
    protected void Application_Start() {

      InitialAutoFac();

      AreaRegistration.RegisterAllAreas();
      GlobalConfiguration.Configure(WebApiConfig.Register);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      BundleConfig.RegisterBundles(BundleTable.Bundles);
    }

    private void InitialAutoFac() {
      var builder = new ContainerBuilder();

      builder.RegisterControllers(typeof(MvcApplication).Assembly);

      builder.RegisterType<CarRepository>().As<IRepository<Car>>(); 

      builder.RegisterType<CarService>().As<IService<Car>>(); 

      builder.RegisterType<CarFuelDb>().As<DbContext>();

      var container = builder.Build();
      DependencyResolver.SetResolver(new AutofacDependencyResolver(container)); 
    }
  }
}
