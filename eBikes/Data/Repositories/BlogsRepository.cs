using eBikes.Data.Repositories;
using eBikes.Models;
using Microsoft.EntityFrameworkCore;

namespace eBikes.Data.Repositories
{
    public class BlogsRepository : IBlogsRepository
    {
        private readonly AppDbContext _context;
        public BlogsRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Blog blog)
        {
            _context.Blogs.Add(blog);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Blog>> GetAllBlogs()
        {
            var result =await _context.Blogs.ToListAsync();
            return result;
        }

        public Blog GetBlogById(int id)
        {
            throw new NotImplementedException();
        }

        public Blog Update(int id, Blog newBlog)
        {
            throw new NotImplementedException();
        }
    }
}
