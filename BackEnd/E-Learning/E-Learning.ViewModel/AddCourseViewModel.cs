using E_Learning.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.ViewModel
{
    public class AddCourseViewModel
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string VideoLink { get; set; }
        public string ContentBody { get; set; }
        public FileModel filemodel { get; set; }
        [Required]
        public Guid ThemeId { get; set; }
    }
}
