using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Respositories.UnitOfWork
{
   public interface IUnitOfWorkProvider
    {
        IUnitOfWork GetUnitOfWork();
    }
}
