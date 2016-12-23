using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetaPoco;
namespace Prj.Respositories.UnitOfWork
{
   public class UnitOfWork : IUnitOfWork
    {
        private readonly Transaction _petaTransaction;
        private readonly Database _db;
        public UnitOfWork()
        {
            _db = new Database("DBConnectionString");
            _petaTransaction = new Transaction(_db);
        }

        public void Dispose()
        {        
            _petaTransaction.Dispose();
          
        }

        public Database Db
        {
            get { return _db; }
        }

        public void Commit()
        {
            _petaTransaction.Complete();
        }
    }
}
