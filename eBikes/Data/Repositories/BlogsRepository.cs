using eBikes.Data.Base;
using eBikes.Data.Repositories;
using eBikes.Models;
using Microsoft.EntityFrameworkCore;

namespace eBikes.Data.Repositories
{
    public class BlogsRepository : EntityBaseRepository<Blog>, IBlogsRepository
    {
        public BlogsRepository(AppDbContext context) : base(context) { }
    }
}
