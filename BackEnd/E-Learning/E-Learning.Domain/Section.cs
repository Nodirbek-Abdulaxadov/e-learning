using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Learning.Domain
{
    public class Section
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Guid ChapterId { get; set; }
        List<Course> Courses { get; set; }
    }
}
