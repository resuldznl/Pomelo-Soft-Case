using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomeloSoftCase.Infrastructure.Abstract
{
    public interface IFileControl
    {
        Task<string> AddFile(IFormFile formFile, string path);
    }
}
