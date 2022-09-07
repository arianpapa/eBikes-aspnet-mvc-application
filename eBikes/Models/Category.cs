using System.ComponentModel.DataAnnotations;

namespace eBikes.Models
{
    public class Category
    {
            [Key]
            public int Id { get; set; }
            [MaxLength(255)]
            [Display(Name = "Category Image")]
            public string Name { get; set; }
            [Display(Name = "Category Name")]
            public string Description { get; set; }
            [MaxLength(255)]
            [Display(Name = "Category Description")]
            public string imageName { get; set; }
            public DateTime Created_at { get; set; }
            public DateTime Updated_at { get; set; }

        
    }
}
