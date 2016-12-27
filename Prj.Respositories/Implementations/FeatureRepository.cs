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
   public class FeatureRepository : IFeatureRepository
    {
        private readonly IUnitOfWorkProvider _unitOfWorkProvider;
        public FeatureRepository(IUnitOfWorkProvider unitOfWorkProvider)
        {
            _unitOfWorkProvider = unitOfWorkProvider;
        }

        public FeatureListEntity GetAll(FeatureEntity entity, long pageIndex, long pageSize)
        {
            var list = new FeatureListEntity();
            try
            {
                using (var _uow = _unitOfWorkProvider.GetUnitOfWork())
                {
                    var query = PetaPoco.Sql.Builder.Append(@"SELECT * FROM Feature");
                    query.Append("ORDER BY ModifiedDate DESC");
                    var result = _uow.Db.Page<FeatureEntity>(pageIndex, pageSize, query);
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
                Logger.ErrorLog(ConstantsHandler.ForderLogName.RepoFeature, "GetAll : ", ex.ToString());
            }
            return list;
        }
        public FeatureEntity GetById(int id)
        {
            var entity = new FeatureEntity();
            try
            {
                using (var _uow = _unitOfWorkProvider.GetUnitOfWork())
                {
                    entity = _uow.Db.SingleOrDefault<FeatureEntity>("SELECT * FROM Feature WHERE Id=@0", id);
                    _uow.Commit();
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.RepoFeature, "GetById : ", ex.ToString());
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
                    _uow.Db.Execute("DELETE FROM Feature WHERE Id=@0", id);
                    result = true;
                    _uow.Commit();
                }
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.RepoFeature, "Delete : ", ex.ToString());
            }
            return result;
        }
        public MessageEntity Create(FeatureEntity entity)
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
                Logger.ErrorLog(ConstantsHandler.ForderLogName.RepoFeature, "Create : ", ex.ToString());
            }
            return msgEntity;
        }
        public MessageEntity Update(FeatureEntity entity)
        {
            var msgEntity = new MessageEntity();
            try
            {
                using (var _uow = _unitOfWorkProvider.GetUnitOfWork())
                {
                    var data = _uow.Db.SingleOrDefault<FeatureEntity>("SELECT * FROM Feature WHERE Id=@0", entity.Id);
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
                Logger.ErrorLog(ConstantsHandler.ForderLogName.RepoGroupPage, "Update : ", ex.ToString());
            }

            return msgEntity;
        }
    }
}
