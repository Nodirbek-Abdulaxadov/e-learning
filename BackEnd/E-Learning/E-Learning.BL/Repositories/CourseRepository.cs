using E_Learning.BL.Interfaces;
using E_Learning.Data;
using E_Learning.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.BL.Repositories
{
    public class CourseRepository : ICourseInterface
    {
        private readonly ApplicationDbContext _dbContext;

        public CourseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Course> AddCourse(Course Course)
        {
            _dbContext.Courses.Add(Course);
            _dbContext.SaveChanges();
            return Task.FromResult(Course);
        }

        public Task<Course> GetCourse(Guid id) => 
            Task.FromResult(_dbContext.Courses.FirstOrDefault(c => c.Id == id));

        public Task<List<Course>> GetCourses(Guid themeId) =>
            Task.FromResult(_dbContext.Courses.Where(c => c.ThemeId == themeId).ToList());

        public Task<List<Course>> GetCourses() =>
            Task.FromResult(_dbContext.Courses.ToList());

        public void RemoveCourse(Guid id)
        {
            var course = _dbContext.Courses.FirstOrDefault(course => course.Id == id);
            _dbContext.Courses.Remove(course);
            _dbContext.SaveChanges();
        }

        public Task<Course> UpdateCourse(Course Course)
        {
            _dbContext.Courses.Update(Course);
            _dbContext.SaveChanges();
            return Task.FromResult(Course);
        }
    }
}
