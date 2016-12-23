using Ninject;
using Prj.BusinessLogic.MapperConfig;
using Prj.BusinessLogic.ModuleConfig;
using Prj.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Prj.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.ConfigureMapper();
            IKernel kernel = new StandardKernel(new ServicesModule());
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
