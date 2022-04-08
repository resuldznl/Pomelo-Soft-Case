using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PomeloSoftCaseWepApp.Attributes;
using PomeloSoftCaseWepApp.Models;
using PomeloSoftCaseWepApp.RequestCreator.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomeloSoftCaseWepApp.Controllers
{
    [UserAuthenticationControl]
    public class CategoryController : Controller
    {
        private readonly IApiRequest _apiRequest;
        public CategoryController(IApiRequest apiRequest)
        {
            _apiRequest = apiRequest;
        }
        [Route("/CreateCategory")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategory category)
        {
            var response = await _apiRequest.PostRequestAsync(category, "https://localhost:44313/api/Category", HttpContext.Session.GetString("token").ToString());
            TempData["info"] = response != null ? "Kategori Oluşturma Başarılı" : "Kategori Oluşturma Hatalı";
            return RedirectToAction("Index", "Home");
        }
    }
}
