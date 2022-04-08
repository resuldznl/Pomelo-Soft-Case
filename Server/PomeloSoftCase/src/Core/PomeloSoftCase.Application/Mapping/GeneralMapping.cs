using AutoMapper;
using PomeloSoftCase.Application.DTOs;
using PomeloSoftCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomeloSoftCase.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<GetBlogDto, Blog>();
            CreateMap<Blog, GetBlogDto>();
            CreateMap<GetCategoryDto, Category>();
            CreateMap<Category, GetCategoryDto>();
            CreateMap<CreateBlogDto, Blog>();
            CreateMap<Blog, CreateBlogDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<User, CreateUserDto>();
            CreateMap<GetUserDto, User>();
            CreateMap<User, GetUserDto>();
            CreateMap<CreateCategory, Category>();
            CreateMap<Category, CreateCategory>();
        }
    }
}
