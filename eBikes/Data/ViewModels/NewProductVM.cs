using eBikes.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eBikes.Models
{
    public class NewProductVM
    {
        public int Id { get; set; }
        [Display(Name = "Product name")]
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Display(Name = "Product description")]
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(255)]
        public string Description { get; set; }

        [Display(Name = "Product price")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Product ImageURL")]
        [Required(ErrorMessage = "Image is required")]
        [MaxLength(255)]
        public string imageName { get; set; }

        [Display(Name = "Product created date")]
        [Required(ErrorMessage = "Created date is required")]
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        [Display(Name = "Product quantity")]
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }


        //Category
        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Product category is required")]
        public int CategoryId { get; set; }
        
    }
}

