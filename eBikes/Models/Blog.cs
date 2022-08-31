using System.ComponentModel.DataAnnotations;

namespace eBikes.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Title { get; set; }
        [MaxLength(255)]
        public string Author { get; set; }
        public string Description { get; set; }
        [MaxLength(255)]
        public string imageName { get; set; }
        [MaxLength(255)]
        public string imageSize { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
