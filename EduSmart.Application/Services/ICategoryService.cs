using EduSmart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.Services
{
    public interface ICategoryService
    {
        Task AddCategory(string categoryName);
        Task<List<Category>> GetAllCategory();

    }
}
