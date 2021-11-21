using Autofac;
using Autofac.Integration.Mvc;
using log4net;
using PayRoll.Controllers;
using PayRoll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PayRoll
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            AutofacRegister();
        }

        private void AutofacRegister() 
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModule<AutofacWebTypesModule>();

            builder.RegisterType<ApplicationDbContext>().AsSelf().SingleInstance();
            builder.RegisterType<Repository.CompanyRepository>().As<Repository.ICompanyRepository>().InstancePerLifetimeScope();
            builder.RegisterType<Repository.EmployeeRepository>().As<Repository.IEmployeeRepository>().InstancePerLifetimeScope();

            log4net.Config.XmlConfigurator.Configure();
            
            builder.Register(c => LogManager.GetLogger(typeof(HomeController))).As<ILog>();


            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
