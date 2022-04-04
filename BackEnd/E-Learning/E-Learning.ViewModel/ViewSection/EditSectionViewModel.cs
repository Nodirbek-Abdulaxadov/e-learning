using E_Learning.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Learning.ViewModel.ViewSection
{
    public class EditSectionViewModel
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Guid newChapterId { get; set; }

        public static explicit operator EditSectionViewModel(Section v)
        {
            return new EditSectionViewModel()
            {
                Id = v.Id,
                Name = v.Name,
                newChapterId = v.ChapterId
            };
        }
        public static explicit operator Section(EditSectionViewModel v)
        {
            return new Section()
            {
                Id = v.Id,
                Name = v.Name,
                ChapterId = v.newChapterId
            };
        }
    }
}
