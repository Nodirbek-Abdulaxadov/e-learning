using E_Learning.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Learning.BL.Interfaces
{
    public interface ICourseInterface
    {
        Task<List<Course>> GetCourses(Guid themeId);
        Task<List<Course>> GetCourses();
        Task<Course> GetCourse(Guid id);
        Task<Course> AddCourse(Course Course);
        Task<Course> UpdateCourse(Course Course);
        void RemoveCourse(Guid id);
    }
}
