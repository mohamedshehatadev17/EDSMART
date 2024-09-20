using EduSmart.Application.Interfaces;
using EduSmart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        EDContext _context;
       public CategoryRepository(EDContext context)
        {
            _context = context;
        }
        public async Task AddCategoryByName(string name)
        {
            Category category = new Category()
            {
                Name = name
            };
             _context.Categories.Add(category);
           await _context.SaveChangesAsync();
        }
    }
}
