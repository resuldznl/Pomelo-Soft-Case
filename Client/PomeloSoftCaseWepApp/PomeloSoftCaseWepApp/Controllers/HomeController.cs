using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PomeloSoftCaseWepApp.Models;
using PomeloSoftCaseWepApp.RequestCreator.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using X.PagedList;

namespace PomeloSoftCaseWepApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiRequest _apiRequest;
        public HomeController(IApiRequest apiRequest)
        {
            _apiRequest = apiRequest;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var blogs = JsonSerializer.Deserialize<List<Blogs>>(await _apiRequest.GetRequestAsync("https://localhost:44313/api/Blog", null)).ToPagedList(page, 10);
            var categories = JsonSerializer.Deserialize<List<Categories>>(await _apiRequest.GetRequestAsync("https://localhost:44313/api/Category",null));
            var topBlogs = JsonSerializer.Deserialize<List<Blogs>>(await _apiRequest.GetRequestAsync("https://localhost:44313/GetTopBlogs",null));
            return View((blogs,categories,topBlogs));
        }
        [Route("/Blogs")]
        public async Task<IActionResult> Blogs(int category)
        {
            var blogs = JsonSerializer.Deserialize<List<Blogs>>(await _apiRequest.GetRequestAsync("https://localhost:44313/GetBlogByCategory?category="+category,null));
            return View(blogs);
        }
        [Route("/Blog")]
        public async Task<IActionResult> Blog(int id)
        {
            var blog = JsonSerializer.Deserialize<Blogs>(await _apiRequest.GetRequestAsync("https://localhost:44313/BlogRead?id=" + id,null)); 
            return View(blog);
        }
        [Route("/Login")]
        public IActionResult Login() 
        {
            if(HttpContext.Session.GetString("token") == null)
                return View();

            return RedirectToAction("Index", "Home");
        }
        [Route("/Login")]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            string response = await _apiRequest.PostRequestAsync(loginModel, "https://localhost:44313/Login", null);
            if (response != null)
            {
                var userloginModel = JsonSerializer.Deserialize<UserLoginModel>(response);
                HttpContext.Session.SetInt32("user", userloginModel.id);
                HttpContext.Session.SetString("token", userloginModel.token);
                return RedirectToAction("Index", "Home");
            }
            TempData["info"] = "Kullanıcı adı veya şifre hatalı";
            return View();

        }
        [Route("/SignUp")]
        public IActionResult SignUp()
        {
            if (HttpContext.Session.GetString("token") == null)
                return View();

            return RedirectToAction("Index", "Home");
        }
        [Route("/SignUp")]
        [HttpPost]
        public async Task<IActionResult> SignUp(CreateUser createUser)
        {
            string status = await _apiRequest.PostRequestAsync(createUser, "https://localhost:44313/SignUp",null);
            if (status != null)
                return RedirectToAction("Login", "Home");

            TempData["info"] = "Kullanıcı Oluşturma İşlemi Hatalı";
            return View();
        }
    }
}
