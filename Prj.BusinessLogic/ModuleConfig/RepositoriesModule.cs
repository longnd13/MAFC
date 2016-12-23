using Ninject.Modules;
using Prj.Respositories.Implementations;
using Prj.Respositories.Interfaces;
using Prj.Respositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.BusinessLogic.ModuleConfig
{
   public class RepositoriesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IUnitOfWorkProvider>().To<UnitOfWorkProvider>();

            Bind<ITestRespository>().To<TestRespository>();


        }
    }
}
