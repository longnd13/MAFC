using Prj.Respositories.Entity;
using Prj.Respositories.Interfaces;
using Prj.Respositories.UnitOfWork;
using Prj.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Respositories.Implementations
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IUnitOfWorkProvider _unitOfWorkProvider;
        public AccountRepository(IUnitOfWorkProvider unitOfWorkProvider)
        {
            _unitOfWorkProvider = unitOfWorkProvider;
        }

        public AccountListEntity GetAll(AccountEntity entity, long pageIndex, long pageSize)
        {
            var list = new AccountListEntity();
            try
            {
                using (var _uow = _unitOfWorkProvider.GetUnitOfWork())
                {
                    var query = PetaPoco.Sql.Builder.Append(@"SELECT * 
                                                              FROM Account 
                                                              WHERE bDeleted=@0", entity.bDeleted);
                    //if (entity.CityId > 0)
                    //{
                    //    query.Append("AND CityId=@0", entity.CityId);
                    //}
                    //if (entity.Star > 0)
                    //{
                    //    query.Append("AND Star=@0", entity.Star);
                    //}
                    query.Append("ORDER BY ModifiedDate DESC");

                    var result = _uow.Db.Page<AccountEntity>(pageIndex, pageSize, query);
                    if (result != null && result.TotalItems > 0)
                    {
                        list.List = result.Items; // danh sách data trả về
                        list.PageTotal = result.TotalPages; // tổng số Pages
                        list.PageIndex = result.CurrentPage; // Page hiện tại của data duoc trả về
                        list.Count = Protector.Int(result.TotalItems); //  count data
                    }
                    _uow.Commit();
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.RepoBranch, "GetAll : ", ex.ToString());
            }
            return list;
        }

        public MessageEntity CheckLogin(AccountEntity entity)
        {
            var msgEntity = new MessageEntity();
            try
            {
                using (var _uow = _unitOfWorkProvider.GetUnitOfWork())
                {
                    var accountEntity = _uow.Db.SingleOrDefault<AccountEntity>(@"SELECT UserName, bLock 
                                                                                 FROM Account 
                                                                                 WHERE UserName=@0 
                                                                                 AND Password =@1", entity.UserName, entity.Password);
                    if (accountEntity == null)
                    {
                        msgEntity.code = -2;
                        msgEntity.result = false;
                        msgEntity.message = ConstantsHandler.ErrorMessage.Message_NULL;
                    }
                    else if (accountEntity.bLock == false)
                    {
                        msgEntity.code = -3;
                        msgEntity.result = false;
                        msgEntity.message = "Account Locked ! Please contact IT Department.";
                    }
                    else
                    {
                        msgEntity.code = 0;
                        msgEntity.result = true;
                        msgEntity.message = ConstantsHandler.ErrorMessage.Message_OK;
                    }
                    _uow.Commit();
                }
            }
            catch (Exception ex)
            {
                msgEntity.code = -1;
                msgEntity.result = false;
                msgEntity.message = ConstantsHandler.ErrorMessage.Message_EX;
                Logger.ErrorLog(ConstantsHandler.ForderLogName.RepoAccount, "CheckLogin : ", ex.ToString());
            }
            return msgEntity;
        }

        public MessageEntity ChangePassword(AccountChangePassEntity entity)
        {
            var msgEntity = new MessageEntity();
            try
            {
                using (var _uow = _unitOfWorkProvider.GetUnitOfWork())
                {
                    var data = _uow.Db.SingleOrDefault<AccountEntity>(@"SELECT * 
                                                                        FROM Account 
                                                                        WHERE UserName=@0 
                                                                        AND Password = @1", entity.UserName, entity.PassOld);
                    if (data != null)
                    {
                        data.Password = entity.PassNew;
                        int iUpdatePass = Protector.Int(_uow.Db.Update(data));
                        if (iUpdatePass > 0)
                        {
                            msgEntity.code = 0;
                            msgEntity.result = true;
                            msgEntity.message = ConstantsHandler.ErrorMessage.Message_OK;
                            _uow.Commit();
                        }
                        else
                        {
                            msgEntity.code = -2;
                            msgEntity.result = false;
                            msgEntity.message = ConstantsHandler.ErrorMessage.Message_ERR;
                        }
                    }
                    else
                    {
                        msgEntity.code = -3;
                        msgEntity.result = false;
                        msgEntity.message = ConstantsHandler.ErrorMessage.Message_INVALID;
                    }
                }
            }
            catch (Exception ex)
            {
                msgEntity.code = -1;
                msgEntity.result = false;
                msgEntity.message = ConstantsHandler.ErrorMessage.Message_EX;
                Logger.ErrorLog(ConstantsHandler.ForderLogName.RepoAccount, "ChangePassword : ", ex.ToString());
            }
            return msgEntity;
        }

        public MessageEntity CreateAccount(AccountEntity entity)
        {
            var msgEntity = new MessageEntity();
            try
            {
                using (var _uow = _unitOfWorkProvider.GetUnitOfWork())
                {
                    int Id = Protector.Int(_uow.Db.Insert(entity));
                    if (Id > 0)
                    {
                        msgEntity.code = 0; // success
                        msgEntity.result = true;
                        msgEntity.message = ConstantsHandler.ErrorMessage.Message_OK;
                        _uow.Commit();
                    }
                    else
                    {
                        msgEntity.code = -2; // error 
                        msgEntity.result = false;
                        msgEntity.message = ConstantsHandler.ErrorMessage.Message_ERR;
                    }
                }
            }
            catch (Exception ex)
            {
                msgEntity.code = -1; // exeption
                msgEntity.result = false;
                msgEntity.message = ConstantsHandler.ErrorMessage.Message_EX;
                Logger.ErrorLog(ConstantsHandler.ForderLogName.RepoAccount, "CreateAccount : ", ex.ToString());
            }

            return msgEntity;
        }
    }
}
