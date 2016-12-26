using Prj.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.BusinessLogic.Interfaces
{
  public  interface IBranchService
    {
        BranchListModel GetAll(BranchModel model, long pageIndex, long pageSize);
        BranchModel GetById(int id);
        bool Delete(int id);
        MessageModel Create(BranchModel model);
        MessageModel Update(BranchModel model);
        List<BranchModel> GetBranch(bool bActived);
     
    }
}
