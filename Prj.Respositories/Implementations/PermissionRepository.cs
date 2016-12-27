using Prj.Respositories.Interfaces;
using Prj.Respositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Respositories.Implementations
{
   public class PermissionRepository : IPermissionRepository
    {
        private readonly IUnitOfWorkProvider _unitOfWorkProvider;
        public PermissionRepository(IUnitOfWorkProvider unitOfWorkProvider)
        {
            _unitOfWorkProvider = unitOfWorkProvider;
        }
    }
}
