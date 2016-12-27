using Prj.BusinessLogic.Models;
using Prj.Respositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.BusinessLogic.Interfaces
{
  public interface IFeatureService
    {
        FeatureListModel GetAll(FeatureModel model, long pageIndex, long pageSize);
        FeatureModel GetById(int id);
        bool Delete(int id);
        MessageModel Create(FeatureModel model);
        MessageModel Update(FeatureModel model);
    }
}
