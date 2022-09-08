using eBikes.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eBikes.Models
{
    public class Category : IEntityBase
    {
            [Key]
            public int Id { get; set; }

            [MaxLength(255)]
            [Display(Name = "Category Name")]
            [Required(ErrorMessage = "Category name is required")]
            public string Name { get; set; }

            [MaxLength(255)]
            [Display(Name = "Category Description")]
            [Required(ErrorMessage = "Category description is required")]
            public string Description { get; set; }
            
            [Display(Name = "Category Image")]
            [Required(ErrorMessage = "Category image is required")]
            public string imageName { get; set; }

            public DateTime Created_at { get; set; }
            public DateTime Updated_at { get; set; }

        
    }
}
