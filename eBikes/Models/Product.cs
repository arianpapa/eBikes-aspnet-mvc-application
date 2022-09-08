using eBikes.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Models
{
    public class Product : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        public double Price { get; set; }
        [MaxLength(255)]
        public string imageName { get; set; }

        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public int Quantity { get; set; }


        //Category
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        
    }
}

