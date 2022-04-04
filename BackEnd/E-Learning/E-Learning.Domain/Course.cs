using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_Learning.Domain
{
    public class Course
    {
        public Course()
        {
            Sources = new List<FileModel>();
        }
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string VideoLink { get; set; }
        public string ContentBody { get; set; }
        public List<FileModel> Sources { get; set; }
        [Required]
        public Guid SectionId { get; set; }
    }
}
