using E_Learning.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.ViewModel.ViewCourse
{
    public class EditCourseViewModel
    {
        public Course course { get; set; }
        public List<Section> sections { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<FileModel> Sources { get; set; }
    }
}
