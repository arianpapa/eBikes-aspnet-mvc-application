using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public double Price { get; set; }
        [MaxLength(255)]
        public string Status { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
