using E_Learning.Domain;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace E_Learning.ViewModel.ViewCourse
{
    public class AddCourseViewModel
    {
        public Course Course { get; set; }
        public List<Section> Sections { get; set; }
        public List<IFormFile> Files { get; set; }
        
    }
}
