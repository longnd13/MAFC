using Prj.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.BusinessLogic.Interfaces
{
   public interface IDepartmentService
    {
        List<DepartmentModel> GetDepartment(bool bActived, int branchId);
    }
}
