using System.ComponentModel.DataAnnotations;

namespace eBikes.Models
{
    public class Category
    {
            [Key]
            public int Id { get; set; }
            [MaxLength(255)]
            public string Name { get; set; }
            public string Description { get; set; }
            [MaxLength(255)]
            public string imageName { get; set; }
            [MaxLength(255)]
            public string imageSize { get; set; }
            [MaxLength(255)]
            public DateTime Created_at { get; set; }
            public DateTime Updated_at { get; set; }

        
    }
}
