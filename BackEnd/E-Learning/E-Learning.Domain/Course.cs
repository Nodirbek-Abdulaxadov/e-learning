using System;
using System.ComponentModel.DataAnnotations;

namespace E_Learning.Domain
{
    public class Course
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string PageLink { get; set; }
        [Required]
        public Guid SectionId { get; set; }
    }
}
