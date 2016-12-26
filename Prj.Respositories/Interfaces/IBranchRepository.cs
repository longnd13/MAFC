using Prj.Respositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Respositories.Interfaces
{
    public interface IBranchRepository
    {
        BranchListEntity GetAll(BranchEntity entity, long pageIndex, long pageSize);
        BranchEntity GetById(int id);
        bool Delete(int id);
        MessageEntity Create(BranchEntity entity);
        MessageEntity Update(BranchEntity entity);
        List<BranchEntity> GetBranch(bool bActived);
    }
}
