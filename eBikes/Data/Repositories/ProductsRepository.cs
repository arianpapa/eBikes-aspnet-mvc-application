using eBikes.Data.Base;
using eBikes.Data.ViewModels;
using eBikes.Models;
using Microsoft.EntityFrameworkCore;

namespace eBikes.Data.Repositories
{
    public class ProductsRepository : EntityBaseRepository<Product>, IProductsRepository
    {
        private readonly AppDbContext _context;
        public ProductsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewProductAsync(NewProductVM data)
        {
            var newProduct = new Product()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                imageName = data.imageName,
                CategoryId = data.CategoryId,
                Created_at = data.Created_at,
                Quantity = data.Quantity
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = await _context.Products
                .Include(c => c.Category)
                .FirstOrDefaultAsync(n => n.Id == id);

            return productDetails;
        }

        public async Task<NewProductDropdownsVM> GetNewProductDropdownsValues()
        {
            var response = new NewProductDropdownsVM()
            {
                Categories = await _context.Categories.OrderBy(n => n.Name).ToListAsync()
            };

            return response;
        }

        public async Task UpdateProductAsync(NewProductVM data)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbProduct != null)
            {
                dbProduct.Name = data.Name;
                dbProduct.Description = data.Description;
                dbProduct.Price = data.Price;
                dbProduct.imageName = data.imageName;
                dbProduct.CategoryId = data.CategoryId;
                dbProduct.Created_at = data.Created_at;
                dbProduct.Quantity = data.Quantity;
                await _context.SaveChangesAsync();
            }

            //    //Remove existing actors
            //    var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
            //    _context.Actors_Movies.RemoveRange(existingActorsDb);
            //    await _context.SaveChangesAsync();

            //    //Add Movie Actors
            //    foreach (var actorId in data.ActorIds)
            //    {
            //        var newActorMovie = new Actor_Movie()
            //        {
            //            MovieId = data.Id,
            //            ActorId = actorId
            //        };
            //        await _context.Actors_Movies.AddAsync(newActorMovie);
            //    }
            //    await _context.SaveChangesAsync();

        }
    }
}

