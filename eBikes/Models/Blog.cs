using System.ComponentModel.DataAnnotations;

namespace eBikes.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(255)]
        public string Title { get; set; }
        [Display(Name = "Author")]
        [Required(ErrorMessage = "Author is required")]
        [MaxLength(255)]
        public string Author { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [MaxLength(255)]
        [Display(Name = "Image Name")]
        [Required(ErrorMessage = "Image Name is required")]
        public string imageName { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
