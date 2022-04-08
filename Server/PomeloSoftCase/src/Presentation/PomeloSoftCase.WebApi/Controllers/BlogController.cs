using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PomeloSoftCase.Application.DTOs;
using PomeloSoftCase.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PomeloSoftCase.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;
        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            var blogs = await _blogService.GetActiveBlogs();
            return blogs != null ? Ok(blogs) : NotFound();
        }
        [AllowAnonymous]
        [Route("/GetBlogByCategory")]
        [HttpGet]
        public async Task<IActionResult> GetBlogByCategory(int category)
        {
            var blogs = await _blogService.GetBlogsByCategory(category);
            return blogs != null ? Ok(blogs) : NotFound();
        }
        [AllowAnonymous]
        [Route("/BlogRead")]
        [HttpGet]
        public async Task<IActionResult> BlogRead(int id)
        {
            var blog = await _blogService.GetBlogById(id);
            if(blog != null)
                await _blogService.BlogRead(blog.Id);

            return blog != null ? Ok(blog) : NotFound();
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id)
        {
            var blog = await _blogService.GetBlogById(id);
            return blog != null ? Ok(blog) : NotFound();
        }
        [AllowAnonymous]
        [Route("/GetTopBlogs")]
        [HttpGet]
        public async Task<IActionResult> GetTopBlogs()
        {
            var blogs = await _blogService.GetTopBlogs();
            return blogs != null ? Ok(blogs) : NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog([FromForm] IFormFile file , [FromForm] string postModel)
        {
            var blogDto = JsonSerializer.Deserialize<CreateBlogDto>(postModel);
            blogDto.file = file;

            return await _blogService.CreateBlog(blogDto) == true ? Ok() : BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBlog([FromForm] IFormFile file, [FromForm] string postModel)
        {
            var blogDto = JsonSerializer.Deserialize<UpdateBlogDto>(postModel);
            blogDto.file = file;

            return await _blogService.UpdateBlog(blogDto) == true ? Ok() : BadRequest();
        }
        [Route("/DeleteBlog")]
        [HttpGet]
        public async Task<IActionResult> DeleteBlog(int id)
            => await _blogService.ChangeStatus(id) == true ? Ok() : BadRequest();
    }
}
