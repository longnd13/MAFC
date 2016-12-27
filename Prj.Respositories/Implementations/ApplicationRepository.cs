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
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly IUnitOfWorkProvider _unitOfWorkProvider;
        public ApplicationRepository(IUnitOfWorkProvider unitOfWorkProvider)
        {
            _unitOfWorkProvider = unitOfWorkProvider;
        }

        public ApplicationListEntity GetAll(ApplicationEntity entity, long pageIndex, long pageSize)
        {
            var list = new ApplicationListEntity();
            try
            {
                using (var _uow = _unitOfWorkProvider.GetUnitOfWork())
                {
                    var query = PetaPoco.Sql.Builder.Append(@"SELECT * 
                                                              FROM Branch 
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

                    var result = _uow.Db.Page<ApplicationEntity>(pageIndex, pageSize, query);
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
        public ApplicationEntity GetById(int id)
        {
            var entity = new ApplicationEntity();
            try
            {
                using (var _uow = _unitOfWorkProvider.GetUnitOfWork())
                {
                    entity = _uow.Db.SingleOrDefault<ApplicationEntity>("SELECT * FROM Application WHERE Id=@0", id);
                    _uow.Commit();
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.RepoBranch, "GetById : ", ex.ToString());
            }

            return entity;
        }
        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                using (var _uow = _unitOfWorkProvider.GetUnitOfWork())
                {
                    _uow.Db.Execute("UPDATE Application SET bDeleted=@0 WHERE Id=@1", true, id);
                    result = true;
                    _uow.Commit();
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.RepoBranch, "Delete : ", ex.ToString());
            }
            return result;
        }
        public MessageEntity Create(ApplicationEntity entity)
        {
            var msgEntity = new MessageEntity();
            try
            {
                using (var _uow = _unitOfWorkProvider.GetUnitOfWork())
                {
                    int Id = Protector.Int(_uow.Db.Insert(entity));
                    if (Id > 0)
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
            }
            catch (Exception ex)
            {
                msgEntity.code = -1;
                msgEntity.result = false;
                msgEntity.message = ConstantsHandler.ErrorMessage.Message_EX;
                Logger.ErrorLog(ConstantsHandler.ForderLogName.RepoBranch, "Create : ", ex.ToString());
            }
            return msgEntity;
        }
        public MessageEntity Update(ApplicationEntity entity)
        {
            var msgEntity = new MessageEntity();
            try
            {
                using (var _uow = _unitOfWorkProvider.GetUnitOfWork())
                {
                    var data = _uow.Db.SingleOrDefault<ApplicationEntity>("SELECT * FROM Application WHERE Id=@0", entity.Id);
                    if (data != null && data.Id == entity.Id)
                    {
                        entity.CreatedBy = data.CreatedBy;
                        entity.CreatedDate = data.CreatedDate;
                        _uow.Db.Update(entity);
                        msgEntity.message = ConstantsHandler.ErrorMessage.Message_OK;
                        msgEntity.result = true;
                        msgEntity.code = 0;
                    }
                    _uow.Commit();
                }
            }
            catch (Exception ex)
            {
                msgEntity.result = false;
                msgEntity.message = ConstantsHandler.ErrorMessage.Message_EX;
                Logger.ErrorLog(ConstantsHandler.ForderLogName.RepoBranch, "Update : ", ex.ToString());
            }

            return msgEntity;
        }

        public List<ApplicationEntity> GetBranch(bool bActived)
        {
            var list = new List<ApplicationEntity>();
            try
            {
                using (var _uow = _unitOfWorkProvider.GetUnitOfWork())
                {
                    var query = PetaPoco.Sql.Builder.Append(@"SELECT Id, Name FROM Application
                                                              WHERE bDeleted=@0 AND bActived=@1", false, bActived);
                    //if (cityId > 0)
                    //{
                    //    query.Append("AND CityId=@0", cityId);
                    //}
                    query.Append("ORDER BY ModifiedDate DESC");
                    list = _uow.Db.Fetch<ApplicationEntity>(query);
                    _uow.Commit();
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.RepoBranch, "GetBranch : ", ex.ToString());
            }

            return list;
        }
    }

}
