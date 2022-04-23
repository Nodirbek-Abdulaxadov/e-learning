using E_Learning.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.ViewModel
{
    public class IndexViewModel
    {
        public Course Course { get; set; }
        public List<Course> Courses { get; set; }
        public Chapter Chapter { get; set; }
    }
}
