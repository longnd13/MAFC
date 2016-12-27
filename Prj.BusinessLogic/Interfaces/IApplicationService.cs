using Prj.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.BusinessLogic.Interfaces
{
    public interface IApplicationService
    {
        ApplicationListModel GetAll(ApplicationModel model, long pageIndex, long pageSize);
        ApplicationModel GetById(int id);
        bool Delete(int id);
        MessageModel Create(ApplicationModel model);
        MessageModel Update(ApplicationModel model);
        List<ApplicationModel> GetBranch(bool bActived);
    }
}
