using eBikes.Data.Base;
using eBikes.Models;

namespace eBikes.Data.Repositories
{
    public class CategoriesRepository : EntityBaseRepository<Category>, ICategoriesRepository
    {
        public CategoriesRepository(AppDbContext context) : base(context)
        {
        }
    }
}

