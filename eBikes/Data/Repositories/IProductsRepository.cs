using eBikes.Data.Base;
using eBikes.Data.ViewModels;
using eBikes.Models;

namespace eBikes.Data.Repositories
{
    public interface IProductsRepository : IEntityBaseRepository<Product>
    {
        Task<Product> GetMovieByIdAsync(int id);
        Task<NewProductDropdownsVM> GetNewProductDropdownsValues();
        Task AddNewProductAsync(NewProductVM data);
        //Task UpdateMovieAsync(NewMovieVM data);
    }
}
