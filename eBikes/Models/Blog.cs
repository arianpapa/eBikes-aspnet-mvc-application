using System.ComponentModel.DataAnnotations;

namespace eBikes.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Title")]
        [MaxLength(255)]
        public string Title { get; set; }
        [Display(Name = "Author")]
        [MaxLength(255)]
        public string Author { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [MaxLength(255)]
        [Display(Name = "Image Name")]
        public string imageName { get; set; }
        [MaxLength(255)]
        [Display(Name = "Image Size")]
        public string imageSize { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
