using Prj.Respositories.Entity;
using Prj.Respositories.Interfaces;
using Prj.Respositories.UnitOfWork;
using Prj.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Prj.Respositories.Implementations
{
  public class DepartmentRepository : IDepartmentRepository
    {
        private readonly IUnitOfWorkProvider _unitOfWorkProvider;
        public DepartmentRepository(IUnitOfWorkProvider unitOfWorkProvider)
        {
            _unitOfWorkProvider = unitOfWorkProvider;
        }

        public List<DepartmentEntity> GetDepartment(bool bActived, int branchId)
        {
            var list = new List<DepartmentEntity>();
            try
            {
                using (var _uow = _unitOfWorkProvider.GetUnitOfWork())
                {
                    var query = PetaPoco.Sql.Builder.Append(@"SELECT Id, Name
                                                              FROM Department
                                                              WHERE bDeleted=@0 
                                                              AND bActived=@1 
                                                              AND BranchId=@2", false, bActived, branchId);
                    //if (cityId > 0)
                    //{
                    //    query.Append("AND CityId=@0", cityId);
                    //}
                    query.Append("ORDER BY ModifiedDate DESC");
                    list = _uow.Db.Fetch<DepartmentEntity>(query);
                    _uow.Commit();
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.RepoDepartment, "GetDepartment : ", ex.ToString());
            }

            return list;
        }
    }
}
