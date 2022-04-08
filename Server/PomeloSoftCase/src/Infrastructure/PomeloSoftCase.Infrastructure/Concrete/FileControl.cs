using Microsoft.AspNetCore.Http;
using PomeloSoftCase.Infrastructure.Abstract;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomeloSoftCase.Infrastructure.Concrete
{
    public class FileControl : IFileControl
    {
        public async Task<string> AddFile(IFormFile formFile , string path)
        {
            string name = null;
            string extension = Path.GetExtension(formFile.FileName);
            name = Guid.NewGuid() + extension;
            string location = Path.Combine(path + name);
            using(var stream = new FileStream(location, FileMode.Create))
            {
                await formFile.CopyToAsync(stream);
            }
            return name;
        }
    }
}
