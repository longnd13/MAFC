using Prj.Respositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Respositories.Interfaces
{
   public interface IGroupPageRepository
    {
        GroupPageListEntity GetAll(GroupPageEntity entity, long pageIndex, long pageSize);
        GroupPageEntity GetById(int id);
        bool Delete(int id);
        MessageEntity Create(GroupPageEntity entity);
        MessageEntity Update(GroupPageEntity entity);
    }
}
