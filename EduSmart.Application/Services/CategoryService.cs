using EduSmart.Application.Interfaces;
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
            _categoryRepository.AddCategoryByName(categoryName);
            return Task.CompletedTask;
        }
    }
}
