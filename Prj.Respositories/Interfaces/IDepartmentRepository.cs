using Prj.Respositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Respositories.Interfaces
{
 public interface IDepartmentRepository
    {
        List<DepartmentEntity> GetDepartment(bool bActived, int branchId);
    }
}
