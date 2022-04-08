using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PomeloSoftCaseWepApp.Attributes;
using PomeloSoftCaseWepApp.Models;
using PomeloSoftCaseWepApp.RequestCreator.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace PomeloSoftCaseWepApp.Controllers
{
    [UserAuthenticationControl]
    public class BlogController : Controller
    {
        private readonly IApiRequest _apiRequest;
        public BlogController(IApiRequest apiRequest)
        {
            _apiRequest = apiRequest;
        }
        [Route("/CreateBlog")]
        public async Task<IActionResult> CreateBlog()
        {
            ViewBag.categories = JsonSerializer.Deserialize<List<Categories>>(await _apiRequest.GetRequestAsync("https://localhost:44313/api/Category",null));
            return View();
        }
        [Route("/CreateBlog")]
        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlog createBlog, IFormFile file)
        {
            string response = await _apiRequest.PostFileRequestAsync(createBlog, file, "https://localhost:44313/api/Blog",HttpContext.Session.GetString("token").ToString());
            if(response != null)
            {
                TempData["info"] = "Blog Oluşturma Başarılı";
                return RedirectToAction("Index", "Home");
            }

            TempData["info"] = "Blog Oluşturma Hatalı";
            return RedirectToAction("CreateBlog", "Home");
        }
        [Route("/UpdateBlog")]
        public async Task<IActionResult> UpdateBlog(int id)
        {
            var blog = JsonSerializer.Deserialize<Blogs>(await _apiRequest.GetRequestAsync("https://localhost:44313/api/Blog/" + id, null));
            ViewBag.categories = JsonSerializer.Deserialize<List<Categories>>(await _apiRequest.GetRequestAsync("https://localhost:44313/api/Category", null));
            return View(blog);
        }
        [Route("/UpdateBlog")]
        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlog updateBlog , IFormFile file)
        {
            string response = await _apiRequest.PutFileRequestAsync(updateBlog, file, "https://localhost:44313/api/Blog", HttpContext.Session.GetString("token").ToString());
            if (response != null)
            {
                TempData["info"] = "Blog Güncelleme Başarılı";
                return RedirectToAction("Index", "Home");
            }

            TempData["info"] = "Blog Güncelleme Başarılı";
            return RedirectToAction("UpdateBlog", "Home", new { id=updateBlog.id});
        }
        [Route("/DeleteBlog")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            string response = await _apiRequest.GetRequestAsync("https://localhost:44313/DeleteBlog?id="+id, HttpContext.Session.GetString("token").ToString());
            TempData["info"] = response != null ? "Blog Silme Başarılı" : "Blog Silme Hatalı";
            return RedirectToAction("Index", "Home");
        }
    }
}
