using EduSmart.Application.Interfaces;
using EduSmart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.Services
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task AddCategory(string categoryName)
        {
            return _categoryRepository.AddCategoryByName(categoryName);
        }

        public Task<List<Category>> GetAllCategory()
        {
            return _categoryRepository.GetAllCategory();
        }
    }
}
