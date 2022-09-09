using eBikes.Data.Base;
using eBikes.Data.ViewModels;
using eBikes.Models;

namespace eBikes.Data.Repositories
{
    public interface IProductsRepository : IEntityBaseRepository<Product>
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<NewProductDropdownsVM> GetNewProductDropdownsValues();
        Task AddNewProductAsync(NewProductVM data);
        Task UpdateProductAsync(NewProductVM data);
    }
}
