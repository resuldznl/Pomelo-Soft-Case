using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PomeloSoftCaseWepApp.RequestCreator.Abstract
{
    public interface IApiRequest
    {
        Task<string> GetRequestAsync(string url, string token);
        Task<string> PostRequestAsync(object postModel, string url, string token);
        Task<string> PostFileRequestAsync(object postModel, IFormFile file, string url, string token);
        Task<string> PutFileRequestAsync(object postModel, IFormFile file, string url, string token);
    }
}
