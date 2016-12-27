using Prj.Respositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Respositories.Interfaces
{
    public interface  IApplicationRepository
    {
        ApplicationListEntity GetAll(ApplicationEntity entity, long pageIndex, long pageSize);
        ApplicationEntity GetById(int id);
        bool Delete(int id);
        MessageEntity Create(ApplicationEntity entity);
        MessageEntity Update(ApplicationEntity entity);
        List<ApplicationEntity> GetBranch(bool bActived);
    }
}
