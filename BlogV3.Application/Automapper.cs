using AutoMapper;
using BlogV3.Application.Dtos;
using BlogV3.Domain.Entities;

namespace BlogV3.Application
{
    internal class AutomapperProfile : Profile
    {
        #region Public Constructors

        public AutomapperProfile()
        {
            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Module, ModuleDto>().ReverseMap();
            CreateMap<User, UserDto>()
            .ForMember(dest => dest.UserRoles,
                opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.Role)))
            .ReverseMap()
            .ForMember(dest => dest.UserRoles, opt => opt.Ignore());
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<Permission, PermissionDto>().ReverseMap();
        }

        #endregion Public Constructors
    }
}