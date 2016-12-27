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
    public class GroupPageService : IGroupPageService
    {
        private readonly IGroupPageRepository _groupPageRepository;
        public GroupPageService(IGroupPageRepository groupPageRepository)
        {
            _groupPageRepository = groupPageRepository;
        }

        public GroupPageListModel GetAll(GroupPageModel model, long pageIndex, long pageSize)
        {
            var list = new GroupPageListModel();
            try
            {
                var mapper = Mapper.Map<GroupPageModel, GroupPageEntity>(model);
                var data = _groupPageRepository.GetAll(mapper, pageIndex, pageSize);
                list = Mapper.Map<GroupPageListEntity, GroupPageListModel>(data);
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.ServiceGroupPage, "GetAll : ", ex.ToString());
            }

            return list;
        }

        public GroupPageModel GetById(int id)
        {
            var model = new GroupPageModel();
            try
            {
                var data = _groupPageRepository.GetById(id);
                model = Mapper.Map<GroupPageEntity, GroupPageModel>(data);
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.ServiceGroupPage, "GetById : ", ex.ToString());
            }

            return model;
        }

        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                result = _groupPageRepository.Delete(id);
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.ServiceGroupPage, "Delete : ", ex.ToString());
            }
            return result;
        }

        public MessageModel Create(GroupPageModel model)
        {
            var msg = new MessageModel();
            try
            {
                msg = ValidateGroupPage(model);
                if (msg.result.Equals(false))
                {
                    return msg;
                }
                var mapperEntity = Mapper.Map<GroupPageModel, GroupPageEntity>(model);
                var msgEntity = _groupPageRepository.Create(mapperEntity);
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

        public MessageModel Update(GroupPageModel model)
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

                msg = ValidateGroupPage(model);
                if (msg.result.Equals(false))
                {
                    return msg;
                }

                var mapperEntity = Mapper.Map<GroupPageModel, GroupPageEntity>(model);
                var msgEntity = _groupPageRepository.Update(mapperEntity);
                msg = Mapper.Map<MessageEntity, MessageModel>(msgEntity);
            }
            catch (Exception ex)
            {
                Logger.ErrorLog(ConstantsHandler.ForderLogName.ServiceGroupPage, "Update : ", ex.ToString());
            }
            return msg;
        }

        private MessageModel ValidateGroupPage(GroupPageModel model)
        {
            var msg = new MessageModel();

            if (model.Name == "")
            {
                msg.message = "Please Input GroupPage Name !";
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
