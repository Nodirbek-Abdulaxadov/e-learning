using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Learning.Domain
{
    public class Theme
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
        [Required]
        public Guid SectionId { get; set; }
    }
}
