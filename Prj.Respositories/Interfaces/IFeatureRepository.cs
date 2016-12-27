using Prj.Respositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Respositories.Interfaces
{
   public interface IFeatureRepository
    {
        FeatureListEntity GetAll(FeatureEntity entity, long pageIndex, long pageSize);
        FeatureEntity GetById(int id);
        bool Delete(int id);
        MessageEntity Create(FeatureEntity entity);
        MessageEntity Update(FeatureEntity entity);
    }
}
