using AutoMapper;
using Prj.BusinessLogic.Models;
using Prj.Respositories.Entity;
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

                // Mapper Branch
                cfg.CreateMap<BranchEntity, BranchModel>();
                cfg.CreateMap<BranchModel, BranchEntity>();
                cfg.CreateMap<BranchListEntity, BranchListModel>();
                cfg.CreateMap<BranchListModel, BranchListEntity>();


                cfg.CreateMap<DepartmentEntity, DepartmentModel>();
                cfg.CreateMap<DepartmentModel, DepartmentEntity>();
                
            });
        }
    }
}
