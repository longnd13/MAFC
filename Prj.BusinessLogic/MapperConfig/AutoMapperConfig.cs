using AutoMapper;
using Prj.BusinessLogic.Models;
using Prj.Respositories.Entity;
using Prj.Utilities;
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

                // Mapper Account
                cfg.CreateMap<AccountEntity, AccountModel>();
                cfg.CreateMap<AccountModel, AccountEntity>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => Globals.GetMD5FromString(src.UserName + src.Password).ToLower()));
                cfg.CreateMap<AccountListEntity, AccountListModel>();
                cfg.CreateMap<AccountListModel, AccountListEntity>();
                cfg.CreateMap<AccountChangePassEntity, AccountChangePassModel>();
                cfg.CreateMap<AccountChangePassModel, AccountChangePassEntity>()
                .ForMember(dest => dest.PassOld, opt => opt.MapFrom(src => Globals.GetMD5FromString(src.UserName + src.PassOld).ToLower()))
                .ForMember(dest => dest.PassNew, opt => opt.MapFrom(src => Globals.GetMD5FromString(src.UserName + src.PassNew).ToLower()));

                // Permission
                cfg.CreateMap<PermissionEntity, PermissionModel>();
                cfg.CreateMap<PermissionModel, PermissionEntity>();

                // Mapper Branch
                cfg.CreateMap<BranchEntity, BranchModel>();
                cfg.CreateMap<BranchModel, BranchEntity>();
                cfg.CreateMap<BranchListEntity, BranchListModel>();
                cfg.CreateMap<BranchListModel, BranchListEntity>();

                // Mapper Department
                cfg.CreateMap<DepartmentEntity, DepartmentModel>();
                cfg.CreateMap<DepartmentModel, DepartmentEntity>();
                
            });
        }
    }
}
