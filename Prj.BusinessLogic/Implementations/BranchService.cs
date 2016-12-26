using Prj.Respositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prj.BusinessLogic.Models;
using AutoMapper;
using Prj.Respositories.Entity;
using Prj.Utilities;
using Prj.BusinessLogic.Interfaces;

namespace Prj.BusinessLogic.Implementations
{
  public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public BranchListModel GetAll(BranchModel model, long pageIndex, long pageSize)
        {
            var list = new BranchListModel();
            try
            {
                var mapper = Mapper.Map<BranchModel, BranchEntity>(model);
                var data = _branchRepository.GetAll(mapper, pageIndex, pageSize);
                list = Mapper.Map<BranchListEntity, BranchListModel>(data);
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.ServiceBranch, "GetAll : ", ex.ToString());
            }

            return list;
        }

        public BranchModel GetById(int id)
        {
            var model = new BranchModel();
            try
            {
                var data = _branchRepository.GetById(id);
                model = Mapper.Map<BranchEntity, BranchModel>(data);
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.ServiceBranch, "GetById : ", ex.ToString());
            }

            return model;
        }

        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                result = _branchRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.ServiceBranch, "Delete : ", ex.ToString());
            }
            return result;
        }

        public MessageModel Create(BranchModel model)
        {
            var msg = new MessageModel();
         
            try
            {
                msg = ValidateBranch(model);
                if (msg.result.Equals(false))
                {
                    return msg;
                }



                var mapperEntity = Mapper.Map<BranchModel, BranchEntity>(model);
                var msgEntity = _branchRepository.Create(mapperEntity);
                msg = Mapper.Map<MessageEntity, MessageModel>(msgEntity);
            }
            catch (Exception ex)
            {
                msg.result = false;
                msg.message = ConstantsHandler.ErrorMessage.Message_EX;
                Logger.ErrorLog(ConstantsHandler.ForderLogName.ServiceBranch, "Create : ", ex.ToString());
            }
            return msg;
        }

        public MessageModel Update(BranchModel model)
        {
            var msg = new MessageModel();
         
            try
            {
                if (model.Id <= 0)
                {
                    msg.result = false;
                    msg.message = "Id Incorrect !";
                    return msg;
                }

                msg = ValidateBranch(model);
                if (msg.result.Equals(false))
                {
                    return msg;
                }

                var mapperEntity = Mapper.Map<BranchModel, BranchEntity>(model);
                var msgEntity = _branchRepository.Update(mapperEntity);
                msg = Mapper.Map<MessageEntity, MessageModel>(msgEntity);
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.ServiceBranch, "Update : ", ex.ToString());
            }
            return msg;
        }

        public List<BranchModel> GetBranch(bool bActived)
        {
            var list = new List<BranchModel>();
            try
            {
                var data = _branchRepository.GetBranch(bActived);
                list = Mapper.Map<List<BranchEntity>, List<BranchModel>>(data);
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.ServiceBranch, "GetBranch : ", ex.ToString());
            }
            return list;
        }

        private MessageModel ValidateBranch(BranchModel model)
        {
            var msg = new MessageModel();

            if (model.Name == "")
            {
                msg.message = "Please Input Branch Name !";
                msg.result = false;
            }
            else if (model.Address == "")
            {
                msg.message = "Please Input Branch Address !";
                msg.result = false;
            }
            else
            {
                msg.message = ConstantsHandler.ErrorMessage.Message_OK;
                msg.result = true;
            }
            return msg;
        }

    }
}
