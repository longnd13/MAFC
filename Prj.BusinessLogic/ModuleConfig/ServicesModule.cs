using Ninject.Modules;
using Prj.BusinessLogic.Implementations;
using Prj.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.BusinessLogic.ModuleConfig
{
   public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITestService>().To<TestService>();
         
        }
    }
}
