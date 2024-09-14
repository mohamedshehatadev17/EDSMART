using EduSmart.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSmart.Application.Interfaces
{
    public interface ILessonCompletion
    {
        void AddLessonCompletion(LessonCompletion lessonCompletion);
        Task<bool> SaveChangesAsync();



    }
}
