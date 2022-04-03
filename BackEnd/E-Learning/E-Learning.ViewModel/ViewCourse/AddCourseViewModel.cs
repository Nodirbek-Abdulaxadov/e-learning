using E_Learning.Domain;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace E_Learning.ViewModel.ViewCourse
{
    public class AddCourseViewModel
    {
        public Course Course { get; set; }
        public List<Theme> Themes { get; set; }
        public IFormFile File1 { get; set; }
    }
}
