using System;
using System.ComponentModel.DataAnnotations;

namespace E_Learning.Domain
{
    public class FileModel
    {
        [Key]
        public int Id { get; set; }
        public string FileLink { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileSize { get; set; }
        public Guid CourseId { get; set; }
    }
}
