using E_Learning.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.ViewModel.ViewChapter
{
    public class EditChapterViewModel
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        public static explicit operator EditChapterViewModel(Chapter v)
        {
            return new EditChapterViewModel()
            {
                Id = v.Id,
                Name = v.Name
            };
        }
        public static explicit operator Chapter(EditChapterViewModel v)
        {
            return new Chapter()
            {
                Id  = v.Id,
                Name = v.Name
            };
        }
    }
}
