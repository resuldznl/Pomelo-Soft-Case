using AutoMapper;
using PomeloSoftCase.Application.DTOs;
using PomeloSoftCase.Application.Interfaces.Repositories;
using PomeloSoftCase.Application.Interfaces.Services;
using PomeloSoftCase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomeloSoftCase.Persistence.Concrete.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCategoryDto>> GetActiveCategories()
            => _mapper.Map<List<GetCategoryDto>>(await _categoryRepository.GetAllAsync(p => p.Active == true));
        public async Task<bool> CreateCategory(CreateCategory createCategory)
            => await _categoryRepository.AddAsync(_mapper.Map<Category>(createCategory));
        public async Task<GetCategoryDto> GetCategoryById(int id)
            => _mapper.Map<GetCategoryDto>(await _categoryRepository.GetByIdAsync(id));
        public async Task<bool> UpdateCategory(GetCategoryDto getCategoryDto)
        {
            var categoryControl = await _categoryRepository.GetByIdAsync(getCategoryDto.Id);
            categoryControl.CategoryName = getCategoryDto.CategoryName;

            return await _categoryRepository.UpdateAsync(categoryControl);
        }
    }
}
