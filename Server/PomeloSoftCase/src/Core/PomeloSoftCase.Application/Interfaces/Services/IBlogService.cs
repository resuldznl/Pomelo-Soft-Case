using PomeloSoftCase.Application.DTOs;
using PomeloSoftCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PomeloSoftCase.Application.Interfaces.Services
{
    public interface IBlogService
    {
        Task<List<GetBlogDto>> GetActiveBlogs();
        Task<bool> CreateBlog(CreateBlogDto createBlog);
        Task<bool> UpdateBlog(UpdateBlogDto updateBlogDto);
        Task<GetBlogDto> GetBlogById(int Id);
        Task<List<GetBlogDto>> GetTopBlogs();
        Task<List<GetBlogDto>> GetAllBlogs();
        Task<List<GetBlogDto>> GetBlogsByCategory(int categoryId);
        Task<bool> ChangeStatus(int Id);
        Task BlogRead(int id);
    }
}
