using Ninject;
using Ninject.Modules;
using Prj.BusinessLogic.ModuleConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Prj.Web.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;
        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
            AddBinding();
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _kernel.GetAll(serviceType);
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }

        private void AddBinding()
        {
            var modules = new List<INinjectModule>
            {
                new RepositoriesModule(),
            };
            _kernel.Load(modules);
            //var topClass = _kernel.Get<ITestService>();

        }
    }
}