using Prj.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.BusinessLogic.Interfaces
{
  public interface IAccountService
    {
        MessageModel CheckLogin(AccountModel model);
        MessageModel CreateAccount(AccountModel model);
        MessageModel ChangePassword(AccountChangePassModel model);
    }
}
