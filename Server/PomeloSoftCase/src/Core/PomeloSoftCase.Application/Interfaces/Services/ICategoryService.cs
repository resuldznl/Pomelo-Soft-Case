using PomeloSoftCase.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomeloSoftCase.Application.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<List<GetCategoryDto>> GetActiveCategories();
        Task<bool> CreateCategory(CreateCategory createCategory);
        Task<GetCategoryDto> GetCategoryById(int id);
        Task<bool> UpdateCategory(GetCategoryDto getCategoryDto);

    }
}
