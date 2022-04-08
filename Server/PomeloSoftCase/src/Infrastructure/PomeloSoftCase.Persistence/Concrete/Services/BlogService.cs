using AutoMapper;
using PomeloSoftCase.Application.DTOs;
using PomeloSoftCase.Application.Interfaces.Repositories;
using PomeloSoftCase.Application.Interfaces.Services;
using PomeloSoftCase.Domain.Entities;
using PomeloSoftCase.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PomeloSoftCase.Persistence.Concrete.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;
        private readonly IFileControl _fileControl;
        
        public BlogService(IBlogRepository blogRepository, IMapper mapper, IFileControl fileControl)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
            _fileControl = fileControl;
        }

        public async Task<List<GetBlogDto>> GetAllBlogs()
            => _mapper.Map<List<GetBlogDto>>(await _blogRepository.GetAllAsync());
        public async Task<List<GetBlogDto>> GetActiveBlogs()
            => _mapper.Map<List<GetBlogDto>>(await _blogRepository.GetAllInclude("User",p=>p.Active == true));
        public async Task<bool> CreateBlog(CreateBlogDto createBlog)
        {
            Blog blog = new()
            {
                CategoryId = createBlog.categoryId,
                UserId = createBlog.userId,
                Title = createBlog.title,
                Description = createBlog.description,
                CoverImage = $"blogImg/{await _fileControl.AddFile(createBlog.file, Directory.GetCurrentDirectory() + "/wwwroot/blogImg/")}",
            };
            return await _blogRepository.AddAsync(blog);
        }
        public async Task<GetBlogDto> GetBlogById(int Id)
            => _mapper.Map<GetBlogDto>(await _blogRepository.GetInclude("User",p=>p.Id == Id));
        public async Task<List<GetBlogDto>> GetTopBlogs()
            => _mapper.Map<List<GetBlogDto>>(await _blogRepository.GetAllAsync(p => p.Active == true)).OrderByDescending(p => p.ReadCount).Take(5).ToList();
        public async Task<List<GetBlogDto>> GetBlogsByCategory(int categoryId)
           => _mapper.Map<List<GetBlogDto>>(await _blogRepository.GetAllInclude("User", p => p.CategoryId == categoryId));
        public async Task BlogRead(int id)
        {
            var blog = await _blogRepository.GetAsync(p => p.Id == id);
            blog.ReadCount += 1;
            await _blogRepository.UpdateAsync(blog);
        }
        public async Task<bool> ChangeStatus(int Id)
        {
            var blogControl = await _blogRepository.GetAsync(p => p.Id == Id);
            blogControl.Active = false;
            return await _blogRepository.UpdateAsync(blogControl);
        }
        public async Task<bool> UpdateBlog(UpdateBlogDto updateBlogDto)
        {
            var blogControl = await _blogRepository.GetAsync(p => p.Id == updateBlogDto.id);
            if (updateBlogDto.file != null)
                blogControl.CoverImage = $"blogImg/{await _fileControl.AddFile(updateBlogDto.file, Directory.GetCurrentDirectory() + "/wwwroot/blogImg/")}";
            blogControl.CategoryId = updateBlogDto.categoryId;
            blogControl.Title = updateBlogDto.title;
            blogControl.Description = updateBlogDto.description;
            return await _blogRepository.UpdateAsync(blogControl);
        }

    }
}
