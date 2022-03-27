using System.ComponentModel.DataAnnotations;

namespace E_Learning.Domain
{
    public class FileModel
    {
        [Key]
        public int id { get; set; }
        public string file { get; set; }
        public string file_name { get; set; }
        public string file_type { get; set; }
        public string file_size { get; set; }
    }
}
