using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;
namespace Prj.Respositories.UnitOfWork
{
  public  interface IUnitOfWork : IDisposable
    {
        void Commit();
        Database Db { get; }
    }
}
