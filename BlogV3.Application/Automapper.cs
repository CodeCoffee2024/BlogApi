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
        }

        #endregion Public Constructors
    }
}