using AutoMapper;
using Prj.BusinessLogic.Interfaces;
using Prj.BusinessLogic.Models;
using Prj.Respositories.Entity;
using Prj.Respositories.Interfaces;
using Prj.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.BusinessLogic.Implementations
{
  public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public MessageModel CheckLogin(AccountModel model)
        {
            var msgModel = new MessageModel();
            try
            {
                var mapper = Mapper.Map<AccountModel, AccountEntity>(model);
                var msgEntity = _accountRepository.CheckLogin(mapper);
                msgModel = Mapper.Map<MessageEntity, MessageModel>(msgEntity);
            }
            catch (Exception ex)
            {
                msgModel.code = -1;
                msgModel.result = false;
                msgModel.message = ConstantsHandler.ErrorMessage.Message_EX;
                Logger.ErrorLog(ConstantsHandler.ForderLogName.ServiceAccount, "CheckLogin : ", ex.ToString());
            }
            return msgModel;
        }

        public MessageModel CreateAccount(AccountModel model)
        {
            var msgEntity = new MessageModel();
            try
            {
                msgEntity = ValidateAccount(model);
                if (msgEntity.result == false)
                {
                    return msgEntity;
                }
                var mapper = Mapper.Map<AccountModel, AccountEntity>(model);
                var mapperEntity = _accountRepository.CreateAccount(mapper);
                msgEntity = Mapper.Map<MessageEntity, MessageModel>(mapperEntity);
            }
            catch (Exception ex)
            {
                msgEntity.code = -1;
                msgEntity.result = false;
                msgEntity.message = ConstantsHandler.ErrorMessage.Message_EX;
                Logger.ErrorLog(ConstantsHandler.ForderLogName.ServiceAccount, "CreateAccount : ", ex.ToString());
            }
            return msgEntity;
        }

        public MessageModel ChangePassword(AccountChangePassModel model)
        {
            var msgModel = new MessageModel();
            try
            {
                msgModel = ValidateChangePass(model);
                if (msgModel.result.Equals(false))
                {
                    return msgModel;
                }
                var mapper = Mapper.Map<AccountChangePassModel, AccountChangePassEntity>(model);
                var mapperEntity = _accountRepository.ChangePassword(mapper);
                msgModel = Mapper.Map<MessageEntity, MessageModel>(mapperEntity);
            }
            catch (Exception ex)
            {
                msgModel.result = false;
                msgModel.message = ConstantsHandler.ErrorMessage.Message_EX;
                Logger.ErrorLog(ConstantsHandler.ForderLogName.ServiceAccount, "ChangePassword : ", ex.ToString());
            }
            return msgModel;
        }

        private MessageModel ValidateAccount(AccountModel model)
        {
            var msg = new MessageModel();

            if (model.UserName == "")
            {
                msg.message = "Please Input UserName !";
                msg.result = false;
            }
            else if (model.Password == "")
            {
                msg.message = "Please Input Password !";
                msg.result = false;
            }
            else
            {
                msg.message = ConstantsHandler.ErrorMessage.Message_OK;
                msg.result = true;
            }
            return msg;
        }
        private MessageModel ValidateChangePass(AccountChangePassModel model)
        {
            var msgModel = new MessageModel();
            if (model == null)
            {
                msgModel.result = false;
                msgModel.message = "Account Incorrect !";
            }
            else if (model.PassNew != model.PassNew)
            {
                msgModel.result = false;
                msgModel.message = "Password Invalid, please check again !";
            }
            else
            {
                msgModel.result = true;
                msgModel.message = ConstantsHandler.ErrorMessage.Message_OK;
            }
            return msgModel;

        }
    }
}
