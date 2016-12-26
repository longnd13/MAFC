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
   public class BranchRepository : IBranchRepository
    {
        private readonly IUnitOfWorkProvider _unitOfWorkProvider;
        public BranchRepository(IUnitOfWorkProvider unitOfWorkProvider)
        {
            _unitOfWorkProvider = unitOfWorkProvider;
        }

        public BranchListEntity GetAll(BranchEntity entity, long pageIndex, long pageSize)
        {
            var list = new BranchListEntity();
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

                    var result = _uow.Db.Page<BranchEntity>(pageIndex, pageSize, query);
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
                Logger.ErrorLog(ConstantsHandler.ForderLogName.RepoBranch, "Branch_GetAll : ", ex.ToString());
            }
            return list;
        }
        public BranchEntity GetById(int id)
        {
            var entity = new BranchEntity();
            try
            {
                using (var _uow = _unitOfWorkProvider.GetUnitOfWork())
                {
                    entity = _uow.Db.SingleOrDefault<BranchEntity>("SELECT * FROM Branch WHERE Id=@0", id);                  
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
                    _uow.Db.Execute("UPDATE Branch SET bDeleted=@0 WHERE Id=@1", true, id);
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
        public MessageEntity Create(BranchEntity entity)
        {
            var msg = new MessageEntity();
            try
            {
                using (var _uow = _unitOfWorkProvider.GetUnitOfWork())
                {
                    int Id = Protector.Int(_uow.Db.Insert(entity));
                    if (Id > 0)
                    {                      
                        msg.result = true;
                        msg.message = ConstantsHandler.ErrorMessage.Message_OK;
                        _uow.Commit();
                    }
                    else
                    {
                        msg.result = false;
                        msg.message = ConstantsHandler.ErrorMessage.Message_ERR;
                    }
                }
            }
            catch (Exception ex)
            {
                msg.result = false;
                msg.message = ConstantsHandler.ErrorMessage.Message_EX;
                Logger.ErrorLog(ConstantsHandler.ForderLogName.RepoBranch, "Create : ", ex.ToString());
            }
            return msg;
        }
        public MessageEntity Update(BranchEntity entity)
        {
            var msg = new MessageEntity();
            try
            {
                using (var _uow = _unitOfWorkProvider.GetUnitOfWork())
                {
                    var data = _uow.Db.SingleOrDefault<BranchEntity>("SELECT * FROM Branch WHERE Id=@0", entity.Id);
                    if (data != null && data.Id == entity.Id)
                    {
                        entity.CreatedBy = data.CreatedBy;
                        entity.CreatedDate = data.CreatedDate;
                        _uow.Db.Update(entity);
                        msg.message = ConstantsHandler.ErrorMessage.Message_OK;
                        msg.result = true;
                        msg.code = 0;
                    }
                    _uow.Commit();
                }
            }
            catch (Exception ex)
            {
                msg.result = false;
                msg.message = ConstantsHandler.ErrorMessage.Message_EX;
                Logger.ErrorLog(ConstantsHandler.ForderLogName.RepoBranch, "Update : ", ex.ToString());
            }

            return msg;
        }
    }
}
