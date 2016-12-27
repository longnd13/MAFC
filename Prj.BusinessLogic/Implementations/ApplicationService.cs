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
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        public ApplicationService(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public ApplicationListModel GetAll(ApplicationModel model, long pageIndex, long pageSize)
        {
            var list = new ApplicationListModel();
            try
            {
                var mapper = Mapper.Map<ApplicationModel, ApplicationEntity>(model);
                var data = _applicationRepository.GetAll(mapper, pageIndex, pageSize);
                list = Mapper.Map<ApplicationListEntity, ApplicationListModel>(data);
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.ServiceBranch, "GetAll : ", ex.ToString());
            }

            return list;
        }

        public ApplicationModel GetById(int id)
        {
            var model = new ApplicationModel();
            try
            {
                var data = _applicationRepository.GetById(id);
             
                model = Mapper.Map<ApplicationEntity, ApplicationModel>(data);
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
                result = _applicationRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.ServiceBranch, "Delete : ", ex.ToString());
            }
            return result;
        }

        public MessageModel Create(ApplicationModel model)
        {
            var msg = new MessageModel();

            try
            {
                msg = ValidateApplication(model);
                if (msg.result.Equals(false))
                {
                    return msg;
                }



                var mapperEntity = Mapper.Map<ApplicationModel, ApplicationEntity>(model);
                var msgEntity = _applicationRepository.Create(mapperEntity);
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

        public MessageModel Update(ApplicationModel model)
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

                msg = ValidateApplication(model);
                if (msg.result.Equals(false))
                {
                    return msg;
                }

                var mapperEntity = Mapper.Map<ApplicationModel, ApplicationEntity>(model);
                var msgEntity = _applicationRepository.Update(mapperEntity);
                msg = Mapper.Map<MessageEntity, MessageModel>(msgEntity);
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.ServiceBranch, "Update : ", ex.ToString());
            }
            return msg;
        }

        public List<ApplicationModel> GetBranch(bool bActived)
        {
            var list = new List<ApplicationModel>();
            try
            {
                var data = _applicationRepository.GetBranch(bActived);
                list = Mapper.Map<List<ApplicationEntity>, List<ApplicationModel>>(data);
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.ServiceBranch, "GetBranch : ", ex.ToString());
            }
            return list;
        }

        private MessageModel ValidateApplication(ApplicationModel model)
        {
            var msg = new MessageModel();

            if (model.Name == "")
            {
                msg.message = "Please Input Application Name !";
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
