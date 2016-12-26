using Prj.Respositories.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Respositories.Interfaces
{
   public interface IAccountRepository
    {
        AccountListEntity GetAll(AccountEntity entity, long pageIndex, long pageSize);
        MessageEntity CheckLogin(AccountEntity entity);
        MessageEntity ChangePassword(AccountChangePassEntity entity);
        MessageEntity CreateAccount(AccountEntity entity);
    }
}
