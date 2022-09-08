using eBikes.Models;

namespace eBikes.Data.ViewModels
{
    public class NewProductDropdownsVM
    {
        public NewProductDropdownsVM()
        {
            Categories = new List<Category>();
        }

        public List<Category> Categories { get; set; }

    }
}