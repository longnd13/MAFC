using AutoMapper;
using Prj.BusinessLogic.Interfaces;
using Prj.BusinessLogic.Models;
using Prj.Respositories.Entity;
using Prj.Respositories.Interfaces;
using Prj.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.BusinessLogic.Implementations
{
   public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public List<DepartmentModel> GetDepartment(bool bActived, int branchId)
        {
            var list = new List<DepartmentModel>();
            try
            {
                var data = _departmentRepository.GetDepartment(bActived, branchId);
                list = Mapper.Map<List<DepartmentEntity>, List<DepartmentModel>>(data);
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.ServiceDepartment, "GetDepartment : ", ex.ToString());
            }
            return list;
        }
    }
}
