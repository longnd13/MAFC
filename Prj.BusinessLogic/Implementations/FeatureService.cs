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
   public class  FeatureService : IFeatureService
    {
        private readonly IFeatureRepository _featureRepository;
        public FeatureService(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public FeatureListModel GetAll(FeatureModel model, long pageIndex, long pageSize)
        {
            var list = new FeatureListModel();
            try
            {
                var mapper = Mapper.Map<FeatureModel, FeatureEntity>(model);
                var data = _featureRepository.GetAll(mapper, pageIndex, pageSize);
                list = Mapper.Map<FeatureListEntity, FeatureListModel>(data);
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.ServiceFeature, "GetAll : ", ex.ToString());
            }

            return list;
        }

        public FeatureModel GetById(int id)
        {
            var model = new FeatureModel();
            try
            {
                var data = _featureRepository.GetById(id);
                model = Mapper.Map<FeatureEntity, FeatureModel>(data);
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.ServiceFeature, "GetById : ", ex.ToString());
            }

            return model;
        }

        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                result = _featureRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.ServiceFeature, "Delete : ", ex.ToString());
            }
            return result;
        }

        public MessageModel Create(FeatureModel model)
        {
            var msg = new MessageModel();
            try
            {
                msg = ValidateFeature(model);
                if (msg.result.Equals(false))
                {
                    return msg;
                }
                var mapperEntity = Mapper.Map<FeatureModel, FeatureEntity>(model);
                var msgEntity = _featureRepository.Create(mapperEntity);
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

        public MessageModel Update(FeatureModel model)
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

                msg = ValidateFeature(model);
                if (msg.result.Equals(false))
                {
                    return msg;
                }

                var mapperEntity = Mapper.Map<FeatureModel, FeatureEntity>(model);
                var msgEntity = _featureRepository.Update(mapperEntity);
                msg = Mapper.Map<MessageEntity, MessageModel>(msgEntity);
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.ServiceBranch, "Update : ", ex.ToString());
            }
            return msg;
        }
      
        private MessageModel ValidateFeature(FeatureModel model)
        {
            var msg = new MessageModel();

            if (model.Name == "")
            {
                msg.message = "Please Input Feature Name !";
                msg.result = false;
            }
            else if (model.Url == "")
            {
                msg.message = "Please Input Feature Url !";
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
