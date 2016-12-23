using AutoMapper;
using Prj.Respositories.Entity;
using Prj.Respositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.BusinessLogic.MapperConfig
{
   public class AutoMapperConfig
    {
        public static void ConfigureMapper()
        {
            ConfigureMapping();
        }
        private static void ConfigureMapping()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<MessageEntity, MessageModel>();
                cfg.CreateMap<MessageModel, MessageEntity>();

             


            });
        }
    }
}
