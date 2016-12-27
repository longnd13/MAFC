using Prj.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.BusinessLogic.Interfaces
{
  public interface IGroupPageService
    {
        GroupPageListModel GetAll(GroupPageModel model, long pageIndex, long pageSize);
        GroupPageModel GetById(int id);
        bool Delete(int id);
        MessageModel Create(GroupPageModel model);
        MessageModel Update(GroupPageModel model);
    }
}
