using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task AddCategoryByName(string Name);
    }
}
