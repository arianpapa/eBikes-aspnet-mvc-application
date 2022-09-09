using Microsoft.Azure.Documents;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string Status { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        //User
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public List<OrderItem> OrderItems { get; set; }
    }
}
