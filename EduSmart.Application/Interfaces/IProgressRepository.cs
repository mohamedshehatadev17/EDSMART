using EduSmart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.Interfaces
{
    public interface IProgressRepository
    {
        Task<IEnumerable<Progress>> GetProgressByStudentIdAsync(int studentId);
        Task<Progress> GetProgressByIdAsync(int id);
        Task AddProgressAsync(Progress progress);
        Task UpdateProgressAsync(Progress progress);
        Task DeleteProgressAsync(int id);
        Task<bool> SaveChangesAsync();
    }
}
